/*
SQL queries are used against those data objects that implements the IEnumerable interfaces.

----------WHAT IS IENUMERABLE INTERFACE??
IEnumerable interface is used when we want to iterate among our classes using a foreach loop.
The IEnumerable interface has one method, GetEnumerator,
that returns an IEnumerator interface that helps us to iterate among the class using the foreach loop.
It only readonly. We can not manipulate it.

This is Query syntax in LINQ.

var query = from data in dataset
            where (filter condtion)
            orderby (sort)
            select things

foreach (var value in query)
{
    //process
}
*/





using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Student
    {
        public string name;
        public string rollNumber;
        public double CGPA;
        public Student(string name,string rollNumber,double CGPA)
        {
            this.name = name;
            this.rollNumber = rollNumber;
            this.CGPA = CGPA;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {


            // 1 - define data source
            string[] cities = new string[] { "Lhr", "Okaraaa","karachi" };

            // 2 - define query1
            var query1 = from c in cities
                        select c[0];              //first character of all cities

            // 2 - define query
            var query2 = from c in cities
                         where c.Length > 5
                         select c;


            // 3 - execution of query
            foreach (var city in query1)
            {
                Console.WriteLine(city);
            }

            // 3 - execution of query2
            foreach (var city in query2)
            {
                Console.WriteLine(city);
            }


            /*
            * - Class Activity - Make a class Student with attributes i.e., Name, RollNo and Cgpa. Use it as
            * - Data Source and Print those Student's Names whose CGPA is less than 3.5.
            */
            List<Student> list = new List<Student>();
            list.Add(new Student("Amna","BSEF19M009",3.88));
            list.Add(new Student("Laiba", "BSEF19M003", 3.4));
            list.Add(new Student("Hurmain", "BSEF19M004", 3.2));
            list.Add(new Student("Ameena", "BSEF19M032", 3.88));


            //method syntax
            var q = list
                .Where(s => s.CGPA < 3.5)
                .Select(s => s.name);
                
            //query syntax
            var query = from student in list
                        where student.CGPA < 3.5
                        select student.name;

            Console.WriteLine("Method syntax:");
            foreach (var student in q)
                Console.WriteLine(student);
            Console.WriteLine("Query syntax:");
            foreach (var student in query)
                Console.WriteLine(student);
        }
    }
}



