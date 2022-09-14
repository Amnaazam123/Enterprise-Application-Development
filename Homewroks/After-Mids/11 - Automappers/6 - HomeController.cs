//Use mappers here.

using AutoMapper;
using Automappers.Models;
using Automappers.Models.UserViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Automappers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //----------------------------------------------------------------------------- LOOK HERE!!!!
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }
        //---------------------------------------------------------------------------- LOOK HERE!!!!
        public IActionResult Index()
        {
            User user = new User()
            {
                Id = 1,
                FirstName = "Amna",
                LastName = "Azam",
                Email = "amna.azam@gmail.com",

            };

            UserViewModel userViewModel = _mapper.Map<UserViewModel>(user);
            return View(userViewModel);
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
