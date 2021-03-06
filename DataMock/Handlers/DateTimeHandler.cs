using DataMock.Generators;
using System.Reflection;

namespace DataMock.Handlers
{
    public class DateTimeHandler : IHandler
    {
        public object GetValue<T>(PropertyInfo property)
        {
            return DateTimeGenerator.Date();
        }
    }
}
