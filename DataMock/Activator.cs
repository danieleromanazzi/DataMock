using DataMock.Behaviors;
using DataMock.Configuration;
using DataMock.Customization;
using DataMock.Handlers;
using System;
using System.Collections;
using System.Drawing;
using System.Reflection;

namespace DataMock
{
    public class Activator : HandleProvider
    {
        private static readonly Lazy<Activator> obj = new Lazy<Activator>(() => new Activator());
        protected Activator()
        {
            Configure.Current.AddHandler(typeof(string), new StringHandler())
                             .AddHandler(typeof(int), new IntegerHandler())
                             .AddHandler(typeof(DateTime), new DateTimeHandler())
                             .AddHandler(typeof(bool), new BooleanHandler())
                             .AddHandler(typeof(Enum), new EnumerationHandler())
                             .AddHandler(typeof(IEnumerable), new CollectionHandler())
                             .AddHandler(typeof(Color), new ColorHandler())
                             .AddBehavior<StringBehavior>(new WordsBehavior() { Lenght = 5, Number = 2 });
        }

        public static Activator CreateMock
        {
            get
            {
                return obj.Value;
            }
        }

        internal object Mock<T>(ICustomization configuration = null)
        {
            if (configuration != null)
            {
                BehaviorProvider.Current.Set(configuration);
            }

            var instance = System.Activator.CreateInstance(typeof(T));
            var properties = instance.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                if (property != null && property.CanWrite)
                {
                    var value = GetRandomValue(property);
                    if (value != null)
                    {
                        property.SetValue(instance, value, null);
                    }
                }
            }

            return instance;
        }
    }
}
