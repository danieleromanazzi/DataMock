using DataMock.Behaviors;
using DataMock.Customization;
using DataMock.Handlers;
using System;
using System.Reflection;

namespace DataMock.Configuration
{
    public static class ConfigureExtensions
    {
        public static IConfigure AddHandler(this IConfigure configure, Type type, IHandler handler)
        {
            configure.RegisterHandle(type, handler);
            return configure;
        }

        public static IConfigure AddBehavior<T>(this IConfigure configure, IBehavior behavior) where T : IBehavior
        {
            configure.RegisterBehavior<T>(behavior);
            return configure;
        }

        public static IConfigure Configure(this Activator activator)
        {
            return Configuration.Configure.Current;
        }

        public static object MockingData(this Activator activator, Type type, ICustomization configuration = null)
        {
            var method = typeof(Activator).GetMethod(nameof(Activator.Mock), BindingFlags.Instance | BindingFlags.NonPublic);
            var generic = method.MakeGenericMethod(type);
            return generic.Invoke(activator, new[] { configuration });
        }

        public static T MockingData<T>(this IConfigure configure, ICustomization configuration = null)
        {
            return (T)Activator.CreateMock.Mock<T>(configuration);
        }
    }
}
