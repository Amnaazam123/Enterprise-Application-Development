/* you will write this link to run app: 
    baseURL/api/Controller/abc
*/

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_Services.Models;

namespace Web_Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        StudentRepository rep;
        public StudentController()
        {
            rep = new StudentRepository();
        }

        //this method should be called when you have get method in REST API.
        [HttpGet]
        [Route("abc")]
        public List<Student> Get()
        {
            List<Student> list = rep.GetAllStudents();
            return list;
        }
    }
}
