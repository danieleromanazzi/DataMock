using System;
using System.Drawing;
using System.Globalization;
using System.Text;

namespace DataMock.Console.Demo.Model
{
    public class Person
    {
        public string Name { get; set; }
        public int FavoriteNumber { get; set; }
        public Animal FavoriteAnimal { get; set; }
        public DateTime BirthDate { get; set; }
        public Color FavoritColor { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("My name is ");
            builder.Append(Name);
            builder.Append(", and i was born on ");
            builder.Append(BirthDate.ToString("dd MMMM yyyy", CultureInfo.CreateSpecificCulture("en-US")));
            builder.AppendLine(".");
            builder.Append("My favorite number is ");
            builder.Append(FavoriteNumber);
            builder.AppendLine(".");
            builder.Append("My favorite animal is ");
            builder.Append(FavoriteAnimal);
            builder.AppendLine(".");
            builder.Append("My favorite color is ");
            builder.Append(FavoritColor.ToColorName());
            builder.Append('.');
            return builder.ToString();
        }
    }

    public enum Animal
    {
        Cat,
        Dog,
        Rabbit,
        Parot,

    }
}
