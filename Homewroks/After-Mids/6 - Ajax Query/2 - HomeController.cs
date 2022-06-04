using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JQuery_MVC.Controllers
{
    public class HomeController : Controller
    {
        public PartialViewResult newsPartialView()
        {
            List<Student> s = new List<Student>();
            s.Add(new Student("Amna Azam", "BSEF19M009"));
            s.Add(new Student("Arooj Fatima", "BSEF19M001"));
            s.Add(new Student("Ahmed Faraz", "BSEF19M002"));

            return PartialView("newsPartialView",s);
        }

    }
}
