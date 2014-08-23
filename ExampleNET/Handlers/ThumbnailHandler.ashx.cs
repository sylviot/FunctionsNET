using FunctionsNET;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace ExampleNET.Handlers
{
    public class ThumbnailHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string effect = context.Request.QueryString["effect"] ?? "";
            
            Image image = Image.FromFile(context.Server.MapPath("/Resources/exemplo.jpg"));

            //Obetendo o thumbnail da imag
            Image thumbnail = Thumbnail.GetThumbnail(image, image.Width / 10, image.Height / 8, Color.Blue);
            
            //Aplicando efeitos.
            if (effect.ToLower() == "sepia")
            {
                Thumbnail.ApllySepia(ref thumbnail);
            }
            else if (effect.ToLower() == "grayscale")
            {
                Thumbnail.ApllyGrayScale(ref thumbnail);
            }
            
            //Método de MemoryStream
            MemoryStream ms = new MemoryStream();
            thumbnail.Save(ms, ImageFormat.Jpeg);

            byte[] msByte = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(msByte, 0, (int)ms.Length);

            context.Response.ContentType = "image/jpg";
            context.Response.BinaryWrite(msByte);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}