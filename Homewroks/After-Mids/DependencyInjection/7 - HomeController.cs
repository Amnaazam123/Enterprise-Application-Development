using DependencyInjection.Models;
using DependencyInjection.Models.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployee employee;              //passing reference of interface class in controller

        public HomeController(IEmployee e)
        {
            employee = e;
        }

        public IActionResult Index()
        {
            return View(employee.GetAllEmployees());         //sending employees list in view
        }

    }
}
//RUN CODE, YOU WILL SEE EXCEPTIONS HERE!!!!
