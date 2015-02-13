using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;

using FunctionsNET.Functions;
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
            switch (effect.ToLower())
            {
                case "sepia":
                    Thumbnail.ApllySepia(ref thumbnail);
                    break;
                case "grayscale":
                    Thumbnail.ApllyGrayScale(ref thumbnail);
                    break;
            }
            
            //Método de MemoryStream
            var ms = new MemoryStream();
            thumbnail.Save(ms, ImageFormat.Jpeg);

            var msByte = new byte[ms.Length];
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