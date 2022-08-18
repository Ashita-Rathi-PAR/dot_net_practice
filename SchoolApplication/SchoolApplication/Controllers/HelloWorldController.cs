using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace SchoolApplication.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/
        public string Index()
        {
            return "Hello World";
        }

        // 
        // GET: /HelloWorld/Welcome/ 
        //public string Welcome()
        //{
        //    return "Welcome to the world";
        //}

        public string WelcomeWorld(string name, int numTimes = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        }

        public IActionResult WelcomeSchool(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}
