using FunctionsNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExampleNET.Controllers
{
    public class FunctionsController : Controller
    {
        private List<string> words = new List<string>()
        {
            "area", 
            "Comic",
            "Competition", 
            "Example",
            "Emotion",
            "Future",
            "Television", 
            "Garage",
            "Human",
            "Important",
            "Latino",
            "Minute",
            "Mission    ",
            "Music",
            "Video",
            "Pages",
        };

        public ActionResult LCS()
        {
            return View(words);
        }

        [HttpPost]
        public ActionResult LCS(string word)
        {
            var lista = Search.LCS(word, words);

            return View(lista);
        }

        public ActionResult Thumbnail()
        {
            return View();
        }

    }
}
