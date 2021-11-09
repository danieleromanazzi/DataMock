using DataMock.Behaviors;

namespace DataMock.Customization
{
    public interface ICustomization
    {
        IBehavior Read<T>(string section) where T : IBehavior;
        string Read<T>(string section, string key) where T : IBehavior;
    }
}