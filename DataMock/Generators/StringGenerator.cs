using DataMock.Behaviors;
using DataMock.Resources;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DataMock.Generators
{
    public static class StringGenerator
    {
        private static readonly Random random = new Random();
        private static readonly TextInfo info = CultureInfo.CurrentCulture.TextInfo;

        public static string String(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string Paragraphs(int paragraph)
        {
           var loremIpsum = Resource.GetInternalResourceAsString("LoremIpsum.txt");
            return string.Join("", loremIpsum.Take(paragraph));
        }

        public static string Phrases(int phrase)
        {
            var loremIpsum = Resource.GetInternalResourceAsString("LoremIpsum.txt");
            return string.Join("", loremIpsum.Take(phrase));
        }

        public static string Words(StringBehavior configurator)
        {
            return Words(configurator.WordNumber, configurator.WordLenght);
        }

        public static string Words(int wordNumber, int wordLenght, bool pascalCase = true)
        {
            var builder = new StringBuilder();

            for (int i = 0; i < wordNumber; i++)
            {
                if (i > 0)
                {
                    builder.Append(' ');
                }
                builder.Append(Word(wordLenght));
            }

            var result = builder.ToString();
            if (pascalCase)
            {
                result = info.ToTitleCase(result);
            }
            return result;
        }

        public static string Word(int lenght)
        {
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z" };
            string[] vowels = { "a", "e", "i", "o", "u" };

            string word = "";

            if (lenght == 1)
            {
                word = Letter(random, vowels);
            }
            else
            {
                for (int i = 0; i < lenght; i += 2)
                {
                    word += Letter(random, consonants) + Letter(random, vowels);
                }

                word = word.Replace("q", "qu").Substring(0, lenght); // We may generate a string longer than requested length, but it doesn't matter if cut off the excess.
            }

            return word;
        }

        private static string Letter(Random rnd, string[] letters)
        {
            return letters[rnd.Next(0, letters.Length - 1)];
        }
    }
}
