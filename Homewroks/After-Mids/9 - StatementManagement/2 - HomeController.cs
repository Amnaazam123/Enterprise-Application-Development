// create MVC project
// give a look into Controller (index action method)

using cookies.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace cookies.Controllers
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
            //if cookies against key "firstRequest" in not created
            if (!HttpContext.Request.Cookies.ContainsKey("firstRequest"))
            {
                //do you want to set expirey time for cookie, set it before creating cookie.
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(1);

                //creating cookies against "firstRequest" key.
                HttpContext.Response.Cookies.Append("firstRequest", DateTime.Now.ToString());
            }
            else
            {
                DateTime firstVisitedDateTime = DateTime.Parse(HttpContext.Request.Cookies["firstRequest"]);
                object data = "welcome back user, you first visited on " + firstVisitedDateTime.ToString();
                
                //if you want to delete cookies againt any key
                HttpContext.Response.Cookies.Delete("firstRequest");

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

