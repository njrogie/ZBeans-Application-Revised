using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZBeansApplication.Models;
using ZBeansApplication.Data;
using Microsoft.Extensions.Logging;

namespace ZBeansApplication.Controllers
{
    public class EmployeeController : Controller
    {
        private ILogger _logger;

        public EmployeeController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Schedule()
        {
            return View(new WeekScheduleModel());
        }


    }
}