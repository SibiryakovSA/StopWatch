using System;
using System.Collections.Generic;
using System.Text;
using SkiaSharp;
using Xamarin.Forms;
using System.IO;

namespace Analog_watch.Models
{
    class ImgConverter
    {
        public static Image SkImageToXamarinImage(SKImage image)
        {
            SKData data = image.Encode();
            Stream stream = data.AsStream();

            Image res = new Image();
            res.Source = ImageSource.FromStream(() => stream);
            return res;
        }

        public static SKImage XamarinImageToSkImage(Image image)
        {
            

            return null;
        }
    }

    class ImgCroper
    {
        public static Image Crop(Image image, int x1, int y1, int x2, int y2)
        {
            var skImage = ImgConverter.XamarinImageToSkImage(image);
            return ImgConverter.SkImageToXamarinImage(
                skImage.Subset(new SKRectI(x1, y1, x2, y2)));
        }
    }
}
