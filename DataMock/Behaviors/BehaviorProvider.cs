using DataMock.Customization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DataMock.Behaviors
{
    public class BehaviorProvider
    {
        private readonly Dictionary<PropertyInfo, IBehavior> configurationsProperty = new Dictionary<PropertyInfo, IBehavior>();
        private readonly Dictionary<string, IBehavior> configurationsPrimitive = new Dictionary<string, IBehavior>();
        private readonly IList<IBehavior> configurations = new List<IBehavior>();
        private ICustomization ReaderConfiguration
        {
            get; set;
        }

        private static readonly Lazy<BehaviorProvider> obj = new Lazy<BehaviorProvider>(() => new BehaviorProvider());
        private BehaviorProvider()
        {
        }

        public static BehaviorProvider Current
        {
            get
            {
                return obj.Value;
            }
        }

        public void Set(ICustomization reader)
        {
            ReaderConfiguration = reader;
        }

        public IBehavior Get<T>() where T : IBehavior
        {
            var configurator = configurations.FirstOrDefault(x => x.GetType().IsAssignableFrom(typeof(T)));
            if (configurator == null)
            {
                configurator = System.Activator.CreateInstance(typeof(T)) as IBehavior;
                configurator.Default();
                configurations.Add(configurator);
            }

            return configurator;
        }

        public IBehavior Get<T>(string primitiveName) where T : IBehavior
        {
            try
            {
                if (ReaderConfiguration == null)
                {
                    return Get<T>();
                }

                if (configurationsPrimitive.TryGetValue(primitiveName, out var configurator))
                {
                    return configurator;
                }

                configurator = ReaderConfiguration.Read<T>(primitiveName);
                if (configurator != null && !configurationsPrimitive.ContainsKey(primitiveName))
                {
                    configurationsPrimitive.Add(primitiveName, configurator);
                }

                if (configurationsPrimitive.TryGetValue(primitiveName, out configurator))
                {
                    return configurator;
                }

                return configurator;
            }
            catch (Exception)
            {
                return Get<T>();
            }
        }

        public IBehavior Get<T>(PropertyInfo property) where T : IBehavior
        {
            try
            {
                if (ReaderConfiguration == null)
                {
                    return Get<T>();
                }

                var name = $"{property.DeclaringType.Name}.{property.Name}";
                if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType) &&
                    !typeof(CollectionBehavior).IsAssignableFrom(typeof(T)) &&
                    (property.PropertyType.IsValueType || property.PropertyType.GetConstructor(Type.EmptyTypes) != null))
                {
                    name = $"{property.Name}.Value";
                    return Get<T>(name);
                }

                var configurator = ReaderConfiguration.Read<T>(name);
                if (configurator != null && !configurationsProperty.ContainsKey(property))
                {
                    configurationsProperty.Add(property, configurator);
                }

                if (configurationsProperty.TryGetValue(property, out configurator))
                {
                    return configurator;
                }
            }
            catch (Exception ex)
            {
                return Get<T>();
            }

            return Get<T>();

        }
    }
}
