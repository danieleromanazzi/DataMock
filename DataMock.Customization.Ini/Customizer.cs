using DataMock.Behaviors;
using DataMock.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DataMock.Customization.Ini
{
    public class Customizer : ICustomization
    {
        private readonly string name;
        private readonly Assembly assemblyView;

        public Customizer(Assembly assemblyView, string filename)
        {
            this.assemblyView = assemblyView;
            name = filename;
        }

        private string[] ReadFromFile()//TODO
        {
            var iniPath = Path.Combine(Environment.CurrentDirectory, "Resources", name);
            return System.IO.File.ReadAllLines(iniPath);
        }

        private string[] ReadFromResource()
        {
            var iniPath = Path.Combine(Environment.CurrentDirectory, "Resources", name);
            if (!File.Exists(iniPath))//TODO
            {
                return Resource.GetExternalResourceAsString(assemblyView, name);
            }

            return System.IO.File.ReadAllLines(iniPath);
        }

        public string Read<T>(string section, string key) where T : IBehavior
        {
            var lines = ReadFromResource();

            var range = SectionRange<T>(lines, section);
            if (range != null)
            {
                var sectionContent = lines.Skip(range.Item1).Take(range.Item2 - range.Item1);
                var keys = SectionKeys(sectionContent);

                if (keys.TryGetValue(key, out string result))
                {
                    return result;
                }
            }

            return string.Empty;
        }

        public IBehavior Read<T>(string section) where T : IBehavior
        {
            var lines = ReadFromResource();

            var range = SectionRange<T>(lines, section);
            if (range != null)
            {
                var sectionContent = lines.Skip(range.Item1).Take(range.Item2 - range.Item1);

                var keys = SectionKeys(sectionContent);

                if (keys.TryGetValue("Configurator", out string configuratorName))
                {
                    keys.Remove("Configurator");

                    if (typeof(T).Name.Equals(configuratorName))
                    {
                        var type = Type.GetType($"{(nameof(DataMock))}.Behaviors.{configuratorName}, {(nameof(DataMock))}");
                        var configurator = (IBehavior)System.Activator.CreateInstance(type);
                        foreach (var key in keys)
                        {
                            if (keys.TryGetValue(key.Key, out string value))
                            {
                                var propertyInfo = configurator.GetType().GetProperty(key.Key);
                                if (propertyInfo != null)
                                {
                                    propertyInfo.SetValue(configurator, Convert.ChangeType(value, propertyInfo.PropertyType), null);
                                }
                            }
                        }
                        return configurator;
                    }
                }
            }

            return null;
        }

        private Dictionary<string, string> SectionKeys(IEnumerable<string> lines)
        {
            var result = new Dictionary<string, string>();
            foreach (var line in lines)
            {
                var splitted = line.Split('=');
                result.Add(splitted.FirstOrDefault(), splitted.LastOrDefault());
            }
            return result;
        }

        private Tuple<int, int> SectionRange<T>(string[] lines, string Section)
        {
            int? startIndex = null;
            int? endIndex = null;
            for (var index = 0; index < lines.Length; index++)
            {
                if (startIndex.HasValue &&
                    lines[index].StartsWith("[") &&
                    lines[index].EndsWith("]"))
                {
                    endIndex = index;
                    break;
                }

                if (lines[index].Equals($"[{Section}]"))
                {
                    var configuratorType = lines[index + 1].Split('=').LastOrDefault();
                    if (typeof(T).Name.Equals(configuratorType))
                    {
                        startIndex = index + 1;
                    }
                }
            }

            if (!startIndex.HasValue)
            {
                return null;
            }

            if (startIndex.HasValue && !endIndex.HasValue)
            {
                endIndex = lines.Length;
            }

            return new Tuple<int, int>(startIndex.Value, endIndex.Value);
        }
    }
}
