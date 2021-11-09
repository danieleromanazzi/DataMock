using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DataMock.Resources
{
    public static class Resource
    {
        /// <summary>
        /// Get resource content as string from name
        /// </summary>
        /// <param name="name">Format: "{Namespace}.{Folder}.{filename}.{Extension}" or "{filename}.{Extension}" if resource is in the same project</param>
        /// <returns></returns>
        public static string[] GetInternalResourceAsString(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourcePath = name;

            if (!name.StartsWith(nameof(DataMock)))
            {
                resourcePath = assembly.GetManifestResourceNames()
                    .Single(str => str.EndsWith(name));
            }

            using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    var content = reader.ReadToEnd();
                    var splitted = content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    return splitted;
                }
            }
        }

        public static string[] GetExternalResourceAsString(Assembly assembly, string name)
        {
            string resourcePath = name;

            if (!name.StartsWith(assembly.GetName().Name))
            {
                resourcePath = assembly.GetManifestResourceNames()
                    .Single(str => str.EndsWith(name));
            }

            using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    var content = reader.ReadToEnd();
                    var splitted = content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    return splitted;
                } 
            }
        }
    }
}
