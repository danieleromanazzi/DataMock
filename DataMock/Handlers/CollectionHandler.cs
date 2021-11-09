using DataMock.Behaviors;
using System;
using System.Collections;
using System.Reflection;

namespace DataMock.Handlers
{
    public class CollectionHandler : HandleProvider, IHandler
    {
        public object GetValue<T>(PropertyInfo property)
        {
            var configuration = BehaviorProvider.Current.Get<CollectionBehavior>(property) as CollectionBehavior;

            return Collection<T>(property, configuration);
        }

        public object Collection<T>(PropertyInfo property, CollectionBehavior configurator)
        {
            return Collection<T>(property, configurator.Lenght, configurator.IndexField);
        }

        public object Collection<T>(PropertyInfo collectionProperty, int lenght, string indexField)
        {
            var result = System.Activator.CreateInstance(typeof(T)) as IList;
            Type itemType = typeof(T).GetGenericArguments()[0];

            for (int i = 0; i < lenght; i++)
            {
                if (!itemType.HasDefaultConstructor())
                {
                    //TODO Integer sequential number of item index by configuration

                    var item = GetRandomValue<T>(itemType, collectionProperty);
                    result.Add(item);

                    continue;
                }

                var instance = System.Activator.CreateInstance(itemType);

                var properties = instance.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (var property in properties)
                {
                    if (property != null && property.CanWrite)
                    {
                        if (indexField != null && indexField.Equals(property.Name))
                        {
                            property.SetValue(instance, i + 1, null);
                        }
                        else
                        {
                            property.SetValue(instance, GetRandomValue(property), null);
                        }
                    }
                }

                result.Add(instance);
            }

            return result;
        }
    }
}
