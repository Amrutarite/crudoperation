using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CrudOperation.Models;

namespace CrudOperation.Controllers
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
            _logger.LogInformation("Index page accessed.");
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("Privacy page accessed.");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.LogError("Error page accessed.");
            return View(new ErrorViewModel { RequestId = HttpContext.TraceIdentifier });
        }
    }
}
