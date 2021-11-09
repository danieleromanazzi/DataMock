using MaterialDesignThemes.Wpf;
using System.Windows.Media;

namespace DataMock.Wpf.Demo
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Brush Color { get; set; }
        public PackIconKind Icon { get; set; }

        public ImageSource Image { get; set; }

    }
}
