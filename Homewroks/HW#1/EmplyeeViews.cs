using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjects;
using BusinessLogicLayer;

namespace PresentationLayer
{
    public class EmployeeViews
    {
        public void InputData()
        {
            EmployeeManager EM = new EmployeeManager();
            EmployeeBusinessObjects EBO = new EmployeeBusinessObjects();
            Console.Write("Enter Name:");
            string name = Console.ReadLine();
            Console.Write("Enter Age:");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter salary:");
            float salary = float.Parse(Console.ReadLine());


            /*need of business object
                => PL me add kia reference, business objects ka*/
            EBO.Name = name;
            EBO.Age = age;
            EBO.Salary = salary;

            List<EmployeeBusinessObjects> l = EM.saveEmployee(EBO);
            foreach(EmployeeBusinessObjects emp in l)
            {
                Console.Write("\nName : "+emp.Name);
                Console.Write("\nAge : " + emp.Age);
                Console.Write("\nSalary : " + emp.Salary);
                Console.Write("\nTax : " + emp.Tax);
                Console.Write("\n\n");
            }
        }
    }
}
