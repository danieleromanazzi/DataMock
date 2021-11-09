using DataMock.Generators;
using System.Reflection;

namespace DataMock.Handlers
{
    public class BooleanHandler : IHandler
    {
        public object GetValue<T>(PropertyInfo property)
        {
            return BooleanGenerator.Boolean();
        }
    }
}
