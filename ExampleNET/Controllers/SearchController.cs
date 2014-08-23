using FunctionsNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExampleNET.Controllers
{
    public class SearchController : Controller
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



        public ActionResult Index()
        {
            return View(words);
        }

        [HttpPost]
        public ActionResult Index(string word)
        {
            var lista = Search.LCS(word, words);

            return View(lista);
        }
    }
}
