using System;
using System.Linq;

namespace DataMock.Generators
{
    public static class EnumerationGenerator
    {
        public static object Enumeration<T>()
        {
            var enums = (T[])Enum.GetValues(typeof(T));
            var size = enums.Distinct().Count();

            return enums.GetValue(IntegerGenerator.Integer(size));
        }
    }
}
