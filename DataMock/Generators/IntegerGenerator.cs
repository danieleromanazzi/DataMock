using System;

namespace DataMock.Generators
{
    public static class IntegerGenerator
    {
        private static readonly Random random = new Random();

        public static int Integer(int maxValue)
        {
            return random.Next(maxValue);
        }
    }
}
