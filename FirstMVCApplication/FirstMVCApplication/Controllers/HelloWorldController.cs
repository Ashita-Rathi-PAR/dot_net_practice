using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using FirstMVCApplication.Models;


namespace FirstMVCApplication.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/Index

        //public string Index()
        //{
        //    return "Default action";
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Index()
        {
            ViewData["Countries"] = new List<string>{
            "India",
            "Malaysia",
            "Dubai",
            "USA",
            "UK"
         };
            return View();
        }

        public IActionResult Dog()
        {
            Dog dog = new Dog() { Name = "Tommy", Age = 2 };
            return View(dog);
        }

        // 
        // GET: /HelloWorld/Welcome?name=Ashita&&numtimes=5

        //public string Welcome(string name, int numTimes = 1)
        //{
        //    return $"Hello {name}, NumTimes is: {numTimes}";
        //}

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}
