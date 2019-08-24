using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Analog_watch.Models;
using SkiaSharp;
using System.IO;

namespace Analog_watch.Models
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            byte[] ba;
            using (FileStream fs = new FileStream(@"C:\Users\User\Desktop\img1.png", FileMode.Open))
            { 
                using (MemoryStream ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    ba = ms.ToArray();
                }
            }

            var bmp = SKBitmap.Decode(ba, new SKImageInfo(1920, 1080));


            SKImage image = SKImage.FromBitmap(bmp);
            Console.WriteLine(image.Height + " " + image.Width);
            
        }

    }
}
