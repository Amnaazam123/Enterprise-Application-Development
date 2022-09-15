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
        //https://localhost:44339/api/Student/abc
        [HttpGet]
        [Route("abc")]
        public List<Student> Get()
        {
            List<Student> list = rep.GetAllStudents();
            return list;
        }

        //https://localhost:44339/api/Student/1
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            Student s = rep.getStudentByID(id);
            return s;
        }
        //HERE IS ONE PROBLEM, through URL only Get request is sent always. To test post requests, either user swaggerUI or Postman

        /*
         * open postman.
         * paste url "https://localhost:44339/api/Student/add" and select method post.
         * In body > raw tab, add student
            * {"id":4,"name":"Ahmed","age":20} 
         * send
         */
        [HttpPost]
        [Route("add")]
        public void AddStudent(Student s)
        {
            rep.AddNewStudent(s);
        }
    }
}
