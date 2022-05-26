//CLASS TASK - Make a partail view which prints data in the form of rows => Assuming that you have one class and you have to print its attributes in one row for each intance using partial views.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace partial_views_final.Models
{
    public class Student
    {
        public string rollNumber;
        public string name;
        public double cgpa;
        public Student(string n,string r,double c)
        {
            rollNumber = r;
            name = n;
            cgpa = c;
        }

    }
}
