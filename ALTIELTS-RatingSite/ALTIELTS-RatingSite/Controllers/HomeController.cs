using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ALTIELTS_RatingSite.Models;
using Microsoft.AspNetCore.Http;
using ALTIELTS_RatingSite.Data;

namespace ALTIELTS_RatingSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly RatingsContext _context;
        public string SessionPasscode = "";
        public string SessionToken = "";
        private readonly ILogger<HomeController> _logger;

        public HomeController(RatingsContext context)
        {
            _context = context;
        }    

        public IActionResult Index()
        {
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


        public IActionResult Login([Bind("Passcode")] Login login)
        {
            var passcodes = _context.Logins.Select(l => l.PassCode);
            if (passcodes.FirstOrDefault(s => s == SessionPasscode) != null)
            {
                return RedirectToAction(nameof(Rate));
            }
            return View("Login");
        }

        public IActionResult Rate(int deptId, string passCode)
        {
            var passcodes = _context.Logins.Select(l => l.PassCode);
            if (passcodes.FirstOrDefault(s => s == passCode) != null)
            {
                return View("Rate");
            }
            return RedirectToAction(nameof(Login));
        }
    }
}
