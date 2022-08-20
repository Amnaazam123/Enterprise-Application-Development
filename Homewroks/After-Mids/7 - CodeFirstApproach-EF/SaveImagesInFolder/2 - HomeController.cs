/*on uploading image, it will create folder named uploads in wwwroot directory with image named abc.jpg*/

using Code_First_Approach_EF.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Code_First_Approach_EF.Controllers
{
    public class HomeController : Controller
    {

        private IWebHostEnvironment Enviornment;
        public HomeController(IWebHostEnvironment _e)
        {
            Enviornment = _e;
        }

        public ViewResult Index(List<IFormFile> postedFiles)
        {
            string wwwPath = this.Enviornment.WebRootPath;
            string path = Path.Combine(wwwPath, "Images");
            path = Path.Combine(wwwPath, "uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            foreach (IFormFile file in postedFiles)
            {
                using (FileStream stream = new FileStream(Path.Combine(path, "abc.jpg"),FileMode.OpenOrCreate))
                {
                    file.CopyTo(stream);

                }
            }
            return View();
        }
    }
}
