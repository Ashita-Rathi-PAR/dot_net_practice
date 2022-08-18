using Microsoft.AspNetCore.Mvc;
using SchoolApplication.Models;
using System.Diagnostics;
using Serilog;

namespace SchoolApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //using (var log = new LoggerConfiguration()
            //    .WriteTo.Console()
            //    .CreateLogger())
            //{
            //    log.Information("Hello");
            //    log.Warning("World");
            //}
            _logger.LogInformation("\n\nHello\n\n");
            //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.UtcNow);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}