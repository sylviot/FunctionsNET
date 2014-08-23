using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FunctionsNET
{
    public static class Thumbnail
    {
        public static Image GetThumbnail(int width, int height, Color backgroundColor)
        {
            Bitmap bitmap = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(backgroundColor);

            return bitmap;
        }

        public static Image GetThumbnail(Image image, int width, int height, Color backgroundColor)
        {
            try
            {
                if (image == null)
                {
                    throw new Exception("Imagem nula!");
                }

                int imgWidth = image.Width,
                    imgHeight = image.Height;

                decimal fator = Math.Min((decimal)width / imgWidth, (decimal)height / imgHeight);

                int xWidth = (int)(imgWidth * fator),
                    xHeight = (int)(imgHeight * fator),
                    xMarginX = (width - xWidth) / 2,
                    xMarginY = (height - xHeight) / 2;

                Bitmap bitmap = new Bitmap(width, height);

                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.Clear(backgroundColor);
                graphics.DrawImage(
                    image,
                    new Rectangle(xMarginX, xMarginY, xWidth, xHeight),
                    new Rectangle(0, 0, imgWidth, imgHeight),
                    GraphicsUnit.Pixel);

                return bitmap;
            }
            catch (Exception)
            {
                return GetThumbnail(width, height, backgroundColor);
            }
        }

        public static void ApllyGrayScale(ref Image image, byte b = 3)
        {

            Bitmap bitmap = (Bitmap)image.Clone();
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                                 ImageLockMode.ReadWrite,
                                                 PixelFormat.Format32bppRgb);

            int numberPixels = image.Width * image.Height;
            int numberBytes = numberPixels * 4;
            byte[] rgb = new byte[numberBytes];
            IntPtr ptr = bmpData.Scan0;

            Marshal.Copy(ptr, rgb, 0, numberBytes);

            for (int i = 0; i < rgb.Length; i += 4)
            {
                int red = rgb[i + 2];
                int green = rgb[i + 1];
                int blue = rgb[i + 0];

                rgb[i + 2] = (byte)Math.Min((red + green + blue) / b, 255.0); // RED
                rgb[i + 1] = (byte)Math.Min((red + green + blue) / b, 255.0); // GREEN
                rgb[i + 0] = (byte)Math.Min((red + green + blue) / b, 255.0); // BLUE
            }

            Marshal.Copy(rgb, 0, ptr, numberBytes);
            bitmap.UnlockBits(bmpData);
            image = bitmap;
        }

        public static void ApllySepia(ref Image image)
        {
            Bitmap bitmap = (Bitmap)image.Clone();
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                                                 ImageLockMode.ReadWrite,
                                                 PixelFormat.Format32bppRgb);

            int numberPixels = image.Width * image.Height;
            int numberBytes = numberPixels * 4;
            byte[] rgb = new byte[numberBytes];
            IntPtr ptr = bmpData.Scan0;

            Marshal.Copy(ptr, rgb, 0, numberBytes);

            for (int i = 0; i < rgb.Length; i += 4)
            {
                int red = rgb[i + 2];
                int green = rgb[i + 1];
                int blue = rgb[i + 0];

                rgb[i + 2] = (byte)Math.Min((.393 * red) + (.769 * green) + (.189 * blue), 255.0); // RED
                rgb[i + 1] = (byte)Math.Min((.349 * red) + (.686 * green) + (.168 * blue), 255.0); // GREEN
                rgb[i + 0] = (byte)Math.Min((.272 * red) + (.534 * green) + (.131 * blue), 255.0); // BLUE
            }

            Marshal.Copy(rgb, 0, ptr, numberBytes);
            bitmap.UnlockBits(bmpData);
            image = bitmap;
        }

    }
}