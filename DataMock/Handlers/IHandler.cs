using System.Reflection;

namespace DataMock.Handlers
{
    public interface IHandler
    {
        object GetValue<T>(PropertyInfo property);
    }
}
