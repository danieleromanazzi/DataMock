using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;

namespace DataMock
{
    public static class Extensions
    {
        public static bool HasDefaultConstructor(this Type t)
        {
            return t.IsValueType || t.GetConstructor(Type.EmptyTypes) != null;
        }

        /// <summary>
        /// Return Color name of closest X11 Unix
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static string ToColorName(this Color color)
        {
            var predefined = typeof(Color).GetProperties(BindingFlags.Public | BindingFlags.Static);
            var match = (from p in predefined where ((Color)p.GetValue(null, null)).ToArgb() == color.ToArgb() select (Color)p.GetValue(null, null));
            if (match.Any())
            {
                return match.First().Name;
            }

            var colorLookup = typeof(Color)
               .GetProperties(BindingFlags.Public | BindingFlags.Static)
               .Select(f => (Color)f.GetValue(null, null))
               .Where(c => c.IsNamedColor)
               .ToLookup(c => c.ToArgb());

            var colorsNamed = colorLookup.Select(x => x.First()).ToList();

            var index = ClosestColor(colorsNamed, color);

            return colorsNamed.ElementAt(index).Name;
        }

        /// <summary>
        /// Closed match in RGB space
        /// </summary>
        /// <param name="colors"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private static int ClosestColor(List<Color> colors, Color target)
        {
            var colorDiffs = colors.Select(n => ColorDiff(n, target)).Min(n => n);
            return colors.FindIndex(n => ColorDiff(n, target) == colorDiffs);
        }

        /// <summary>
        /// Distance in RGB space
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        private static int ColorDiff(Color c1, Color c2)
        {
            return (int)Math.Sqrt((c1.R - c2.R) * (c1.R - c2.R)
                                   + (c1.G - c2.G) * (c1.G - c2.G)
                                   + (c1.B - c2.B) * (c1.B - c2.B));
        }
    }
}
