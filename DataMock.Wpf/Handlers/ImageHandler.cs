using DataMock.Behaviors;
using DataMock.Generators;
using DataMock.Handlers;
using System.Reflection;

namespace DesignTimeMock.Handlers
{
    public class ImageGeneratorHandler : IHandler
    {
        public object GetValue<T>(PropertyInfo property)
        {
            var configuration = BehaviorProvider.Current.Get<ImageBehavior>(property) as ImageBehavior;

            return ImageGenerator.Image(configuration);
        }
    }
}
