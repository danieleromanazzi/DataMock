using DataMock.Generators;
using System.Reflection;

namespace DataMock.Handlers
{
    public class ColorHandler : IHandler
    {
        public object GetValue<T>(PropertyInfo property)
        {
            return ColorGenerator.Color();
        }
    }
}
