using Microsoft.AspNetCore.Mvc;  //to use ViewComponent    
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace viewComponents.Components
{
    public class studentViewComponent : ViewComponent  //must inherit from ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
