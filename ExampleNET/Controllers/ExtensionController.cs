using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FunctionsNET.MethodExtension;
using System.Drawing;

namespace ExampleNET.Controllers
{
    public class ExtensionController : Controller
    {
        public ActionResult StringSample()
        {
            string url = "It is a web url";

            ViewBag.URL = url;
            ViewBag.URLSLUG = url.Slug();

            return View();
        }

        public ActionResult ValidationEmail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValidationEmail(string email)
        {
            ViewBag.IsValid = email.IsEmail();

            return View();
        }

        public ActionResult ValidationUrl()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValidationUrl(string url)
        {
            ViewBag.IsValid = url.IsUrl();

            return View();
        }

        // ImageExtension
        public ActionResult Crop()
        {
            return View();
        }
    }
}