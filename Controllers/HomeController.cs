using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AeroLion.Models;
using StockStackApi.Security;

namespace AeroLion.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        LogInViewModel logInViewModel;
        customers customers;
        private dbcontext _context;


        public HomeController(ILogger<HomeController> logger, dbcontext context)
        {
            _logger = logger;
            logInViewModel = new LogInViewModel();
            customers = new customers();
            _context = context;

        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            ViewData["is_logedin"] = false;
            return View("Index");
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
