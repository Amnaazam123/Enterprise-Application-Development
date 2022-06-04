using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JQuery_MVC.Models
{
    public class Student
    {
        public string Name { get; set; }
        public string RollNumber { get; set; }
        public Student(string n,string r)
        {
            Name = n;
            RollNumber = r;
        }
    }
}
