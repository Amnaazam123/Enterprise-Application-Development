using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_First.Controllers
{
    //for html code we use views folder.
    /*
        In views folder, hr controller k against aik folder bnana hota
        jis ka naam samee wahi hota jo controller ka hota.
        Us folder k undar hr action method k against aik view bnta aur 
        us view ka naam same wahi hota jo action method ka hota.
        hr action method ab aik viewResult return kia kry ga.
     */

    public class HomeController : Controller
    {
        public ViewResult index()
        {
            //return "home-index";       it is returning only string, not html code.
            return View("index");        //OR return View();      here view named index is being called from home controller.
        }
        public ViewResult Student()
        {
            //return "home-student";        it is returning only string, not html code.
            return View();        //OR return View("student");        here view named student is being called from home controller.
        }

    }
}
