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

        public HomeController(RatingsContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
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
            SessionPasscode = passCode;
            var passcodes = _context.Departments.Select(l => l.PassCode);
            if (passcodes.FirstOrDefault(s => s == passCode) != null)
            {
                deptId = _context.Departments.FirstOrDefault(dept => dept.PassCode == passCode).ID;
                Rating model = new Rating { DeptId = deptId };
                return View("Rate", model);
            }
            return RedirectToAction(nameof(Login));
        }

        [HttpPost]
        public async Task<IActionResult> Rate([Bind("DeptId,Point,Comment")]Rating rating)
        {
            if(ModelState.IsValid)
            {
                rating.DateTime = DateTime.UtcNow;
                _context.Ratings.Add(rating);
                await _context.SaveChangesAsync();
                return View("RateComplete",rating);
            }
            return View("Rate");
        }
    }
}
