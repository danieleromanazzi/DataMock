using System;
using System.Windows.Media;

namespace DataMock.Generators
{
    public static class BrushGenerator
    {
        private static readonly Random random = new Random();

        public static Brush Brush()
        {
            return new SolidColorBrush(Color.FromRgb((byte)random.Next(0, 256), (byte)random.Next(0, 256), (byte)random.Next(0, 256)));
        }
    }
}
