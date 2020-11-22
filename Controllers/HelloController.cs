using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloASPDotNet.Controllers
{
    public class HelloController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // GET: /<controller>/<action>/<optional parameter>
        // [HttpGet]
        // [Route("/helloworld/welcome/{name?}")]

        //[HttpGet("welcome/{name?}")]
        [HttpPost("hello")]
        public IActionResult Welcome(string name="World", string language="english")
        {
            ViewBag.person = name;
            ViewBag.language = language;
            ViewBag.create = CreateMessage(name, language);
            return View();
            // return Content("<h1>"+ CreateMessage(name, language) + "!</h1>", "text/html");
        }

        public static string CreateMessage(string name, string language)
        {
            Dictionary<string, string> greetings = new Dictionary<string, string>
            {
                { "english", "Hello" },
                { "spanish", "Hola" },
                { "french", "Bonjour" },
                { "german", "Hallo" },
                { "italian", "Ciao" }
            };

            return greetings[language]+" "+name;
        }
    }
}
