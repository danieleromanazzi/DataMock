using System;

namespace DataMock.Generators
{
    public static class BooleanGenerator
    {
        private static readonly Random random = new Random();

        public static bool Boolean()
        {
            return random.Next(2) == 1;
        }
    }
}
