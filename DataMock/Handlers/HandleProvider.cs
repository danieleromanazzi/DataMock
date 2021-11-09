using DataMock.Configuration;
using System;
using System.Collections;
using System.Reflection;

namespace DataMock.Handlers
{
    public abstract class HandleProvider
    {
        protected HandleProvider()
        {
        }

        private bool TryGetHandler(Type type, out IHandler handler)
        {
            return Configure.Current.TryGetHandler(type, out handler);
        }

        public object GetRandomValue(PropertyInfo property)
        {
            var type = property.PropertyType;
            var method = typeof(IHandler).GetMethod("GetValue");
            var genericMethod = method.MakeGenericMethod(type);

            if (TryGetHandler(type, out var handle))
            {
                return genericMethod.Invoke(handle, new[] { property });
            }

            if (type.IsEnum && TryGetHandler(typeof(Enum), out handle))
            {
                return genericMethod.Invoke(handle, new[] { property });
            }

            if (typeof(IEnumerable).IsAssignableFrom(type) &&
                TryGetHandler(typeof(IEnumerable), out handle))
            {
                return genericMethod.Invoke(handle, new[] { property });
            }

            return null;
        }

        public object GetRandomValue<T>(Type type, PropertyInfo parentPropertyInfo)
        {
            var method = typeof(IHandler).GetMethod("GetValue");
            var genericMethod = method.MakeGenericMethod(type);

            if (TryGetHandler(type, out var handle))
            {
                return genericMethod.Invoke(handle, new[] { parentPropertyInfo });
            }

            if (type.IsEnum && TryGetHandler(typeof(Enum), out handle))
            {
                return genericMethod.Invoke(handle, new[] { parentPropertyInfo });
            }

            if (typeof(IEnumerable).IsAssignableFrom(type) &&
                TryGetHandler(typeof(IEnumerable), out handle))
            {
                return genericMethod.Invoke(handle, new[] { parentPropertyInfo });
            }

            return null;
        }
    }
}
