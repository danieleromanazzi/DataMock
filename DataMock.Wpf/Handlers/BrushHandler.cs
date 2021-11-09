using DataMock.Generators;
using System.Reflection;

namespace DataMock.Handlers
{
    public class BrushGeneratorHandler : IHandler
    {
        public object GetValue<T>(PropertyInfo property)
        {
            return BrushGenerator.Brush();
        }
    }
}
