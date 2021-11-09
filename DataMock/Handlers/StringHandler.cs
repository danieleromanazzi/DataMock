using DataMock.Behaviors;
using DataMock.Generators;
using System.Reflection;

namespace DataMock.Handlers
{
    public class StringHandler : IHandler
    {
        public object GetValue<T>(PropertyInfo property)
        {
            var configuration = BehaviorProvider.Current.Get<StringBehavior>(property) as StringBehavior;

            if (configuration.ParagraphNumber > 0)
            {
                return StringGenerator.Paragraphs(configuration.ParagraphNumber);
            }

            if (configuration.PhraseNumber > 0)
            {
                return StringGenerator.Phrases(configuration.PhraseNumber);
            }

            return StringGenerator.Words(configuration);
        }
    }
}
