
using DataMock.Configuration;

namespace DataMock.Behaviors
{
    public class ImageBehavior : IBehavior
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int PixelArtSize { get; set; }

        public void Default()
        {
            if (!Configure.Current.TryGetBehavior<ImageBehavior>(out var behavior))
            {
                Width = 300;
                Height = 300;
                PixelArtSize = 30;
                return;
            }

            if (behavior is ImageBehavior image)
            {
                Width = image.Width;
                Height = image.Height;
                PixelArtSize = image.PixelArtSize;
            }
        }
    }
}
