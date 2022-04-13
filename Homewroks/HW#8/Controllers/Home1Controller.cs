using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_First.Controllers
{
    public class Home1Controller : Controller
    {
        public ViewResult Index()
        {
            string s = "dummy variable string";
            return View("index",s);     //you can return data from controller to views as well.
        }
    }
}
