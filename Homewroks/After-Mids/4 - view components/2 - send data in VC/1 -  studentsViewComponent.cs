using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace viewComponents.Components
{
    public class students : ViewComponent
    {
        public string name;
        public string rollNumber;
        public IViewComponentResult Invoke(string name,string rollNumber)
        {
            //DB code can also be written here.
            students s = new students();
            s.name = name;
            s.rollNumber = rollNumber;
            return View(s);
        }
    }
}
