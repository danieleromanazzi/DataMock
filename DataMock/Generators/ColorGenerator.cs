using System;
using System.Drawing;
using System.Reflection;

namespace DataMock.Generators
{
    public static class ColorGenerator
    {
        private static readonly Random random = new Random();

        public static Color X11Color()
        {
            var colors = typeof(Color).GetProperties(BindingFlags.Public | BindingFlags.Static);
            var number = random.Next(colors.Length);

            var p = (Color)colors[number].GetValue(null, null);
            return p;
        }

        public static Color Color()
        {
            return System.Drawing.Color.FromArgb((byte)random.Next(0, 256), (byte)random.Next(0, 256), (byte)random.Next(0, 256));
        }
    }
}
