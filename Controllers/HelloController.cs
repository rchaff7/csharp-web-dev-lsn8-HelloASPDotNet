using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloASPDotNet.Controllers
{
    [Route("/helloworld")]
    public class HelloController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            string html = 
                "<form method='post' action='/helloworld/'>" +
                "<input type='text' name='name' placeholder='enter name' required/>" +
                "<select name='language'>" +
                    "<option value='english'>English</option>" +
                    "<option value='spanish'>Spanish</option>" +
                    "<option value='french'>French</option>" +
                    "<option value='german'>German</option>" +
                    "<option value='italian'>Italian</option>" +
                "</select>" +
                "<input type='submit' value='Greet Me!' />" +
                "</form>";

            return Content(html, "text/html");
        }

        // GET: /<controller>/<action>/<optional parameter>
        // [HttpGet]
        // [Route("/helloworld/welcome/{name?}")]

        [HttpGet("welcome/{name?}")]
        [HttpPost]
        public IActionResult Welcome(string name="World", string language="english")
        {
            return Content("<h1>"+ CreateMessage(name, language) + "!</h1>", "text/html");
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
