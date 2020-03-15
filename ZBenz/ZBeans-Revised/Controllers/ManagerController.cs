using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZBeansApplication.Models;
using ZBeansApplication.Data;

namespace ZBeansApplication.Controllers
{
    public class ManagerController : Controller
    {
        private ILogger _logger;

        public ManagerController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Location Select";
            return View();
        }

        public IActionResult Schedule()
        {

            return View(new WeekScheduleModel());
        }

        public IActionResult Employees()
        {
            return View();
        }

        public IActionResult CreateEmployee()
        {
            return View();
        }

        public async Task<IActionResult> StoreEmployeeData(User user)
        {
            return RedirectToAction("Employees");
        }

    }
}