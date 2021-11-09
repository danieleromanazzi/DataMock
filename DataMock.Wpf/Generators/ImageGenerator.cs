using DataMock.Behaviors;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DataMock.Generators
{
    public static class ImageGenerator
    {
        public static ImageSource Image(ImageBehavior configuration)
        {
            int width = configuration.Width, height = configuration.Height;
            int pixelArtSize = configuration.PixelArtSize;

            return Image(width, height, pixelArtSize);
        }

        public static ImageSource Image(int width, int height, int pixelArtSize)
        {
            var dv = new DrawingVisual();
            using (DrawingContext dc = dv.RenderOpen())
            {
                Random rand = new Random();
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        byte a = (byte)rand.Next(256);
                        byte r = (byte)rand.Next(256);
                        byte g = (byte)rand.Next(256);
                        byte b = (byte)rand.Next(256);

                        var color = Color.FromArgb(a, r, g, b);
                        var rect = new Rect(x, y, pixelArtSize, pixelArtSize);
                        var brush = new SolidColorBrush(color);
                        Pen pen = new Pen(brush, 5);
                        dc.DrawRectangle(brush, pen, rect);
                        x += pixelArtSize;
                    }
                    y += pixelArtSize;
                }

                dc.Close();
            }
            RenderTargetBitmap rtb = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Pbgra32);
            rtb.Render(dv);
            return rtb;
        }
    }
}
