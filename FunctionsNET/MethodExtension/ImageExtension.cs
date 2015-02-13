using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FunctionsNET.MethodExtension
{
    public static class ImageExtension
    {
        public static Image Crop(this Image image, int width, int height, int x = 0, int y = 0)
        {
            if (width == 0 || height == 0)
            {
                return image;
            }

            Rectangle crop = new Rectangle(x, y, width, height);
            Bitmap bitmap = new Bitmap(width, height);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.DrawImage(image,
                                   new Rectangle(0, 0, width, height),
                                   crop,
                                   GraphicsUnit.Pixel);
            }

            return bitmap;
        }

        public static byte[] ToArrayBytes(this Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);

            return ms.ToArray();
        }
    }
}
