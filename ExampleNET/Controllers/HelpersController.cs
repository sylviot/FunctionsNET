using FunctionsNET.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExampleNET.Controllers
{
    public class HelpersController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegexSample()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegexSample(string email)
        {
            ViewBag.IsValid = RegexHelper.IsEmail(email);

            return View();
        }
    }
}
