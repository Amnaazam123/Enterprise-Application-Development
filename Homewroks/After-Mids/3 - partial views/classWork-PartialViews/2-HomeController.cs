using myProjectName.Models;                          //is line ki wja se saray models ki classes access ho jati controller me 
 .
 .
 .
 .
 .
 .
 
 public ViewResult addStudent()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("Amna", "BSEF19M009", 3.61));
            students.Add(new Student("Laiba", "BSEF19M003", 3.62));
            students.Add(new Student("Iqra", "BSEF19M012", 3.63));
            students.Add(new Student("Ameena", "BSEF19M032", 3.64));

            return View(students);
        }
.
.
.
.
.
.
.
