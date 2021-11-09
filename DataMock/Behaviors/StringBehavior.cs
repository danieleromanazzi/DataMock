using DataMock.Configuration;

namespace DataMock.Behaviors
{
    public class StringBehavior : IBehavior
    {
        public int WordLenght { get; set; }
        public int WordNumber { get; set; }
        public int PhraseNumber { get; set; }
        public int ParagraphNumber { get; set; }


        public void Default()
        {
            if (!Configure.Current.TryGetBehavior<StringBehavior>(out var behavior))
            {
                WordLenght = 5;
                WordNumber = 2;
                return;
            }

            if (behavior is WordsBehavior words)
            {
                WordNumber = words.Number;
                WordLenght = words.Lenght;
            }
        }
    }
}
