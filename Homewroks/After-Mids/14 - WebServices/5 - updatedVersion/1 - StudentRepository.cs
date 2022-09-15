using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Services.Models
{
    public class StudentRepository

    {
        List<Student> students;
        public StudentRepository()
        {
            students = new List<Student>()
            {
                new Student { ID = 1, Name = "Amna", Age = 20 },
                new Student { ID = 2, Name = "Iqra", Age = 20 },
                new Student { ID = 3, Name = "Laiba", Age = 20 },
                new Student { ID = 4, Name = "Ameena", Age = 20 }

            };
        }
        public List<Student> GetAllStudents()
        {
            return students;
        }
        public Student getStudentByID(int id)
        {
            return students.Find(s => s.ID == id);
        }
        public void AddNewStudent(Student s)
        {
            students.Add(s);

        } 
    }
}
