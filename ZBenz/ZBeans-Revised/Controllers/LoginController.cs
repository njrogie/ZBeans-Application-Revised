
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


using ZBeansApplication.Data;
using ZBeansApplication.Models;

namespace ZBeansApplication.Controllers
{
    public class LoginController : Controller
    {
        private ILogger _logger;


        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;

        }

        public IActionResult Index()
        {
            ViewData["ZBeansLogo"] = "/images/SMALL_1500x.png";
            return View();
        }

        // TODO: 
        // This method tells the backend to pull the password from the server, check it against the
        // submitted password, redirect to certain pages based on that info.
        public IActionResult Submit()
        {
            _logger.LogInformation("Username: ");




            return View();
        }
    }
}