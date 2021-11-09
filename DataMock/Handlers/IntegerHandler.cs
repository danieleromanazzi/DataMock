using DataMock.Generators;
using System.Reflection;

namespace DataMock.Handlers
{
    public class IntegerHandler : IHandler
    {
        public object GetValue<T>(PropertyInfo property)
        {
            return IntegerGenerator.Integer(220);
        }
    }
}
