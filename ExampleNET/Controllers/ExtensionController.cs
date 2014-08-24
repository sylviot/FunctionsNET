using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FunctionsNET.Extension;

namespace ExampleNET.Controllers
{
    public class ExtensionController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult String()
        {
            string url = "URL amigável para a WEB";

            ViewBag.URL = url;
            ViewBag.URLSLUG = url.Slug();

            return View();
        }
    }
}