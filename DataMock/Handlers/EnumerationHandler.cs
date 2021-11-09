using DataMock.Generators;
using System.Reflection;

namespace DataMock.Handlers
{
    public class EnumerationHandler : IHandler
    {
        public object GetValue<T>(PropertyInfo property)
        {
            return EnumerationGenerator.Enumeration<T>();
        }
    }
}
