using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sessions.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace sessions.Controllers
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
            //if session against key "firstRequest" in not created
            if (!HttpContext.Session.Keys.Contains("firstRequest"))
            {
                //do you want to set expirey time for session, set it before creating session.
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(1);

                //creating session against "firstRequest" key.
                HttpContext.Session.SetString("firstRequest", DateTime.Now.ToString());
            }
            else
            {
                DateTime firstVisitedDateTime = DateTime.Parse(HttpContext.Session.GetString("firstRequest"));
                object data = "welcome back user, you first visited on " + firstVisitedDateTime.ToString();

                //if you want to delete session againt any key
                HttpContext.Session.Remove("firstRequest");

                return View(data);

            }
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
