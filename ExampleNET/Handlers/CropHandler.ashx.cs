using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using FunctionsNET.Extension;

namespace ExampleNET.Handlers
{
    public class CropHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            Image imageOriginal = Image.FromFile(context.Server.MapPath("/Resources/exemplo.jpg"));
            Image cropImage = imageOriginal.Crop(800, 400, 500, 700);

            context.Response.ContentType = "image/jpg";
            context.Response.BinaryWrite(cropImage.ToArrayBytes());
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