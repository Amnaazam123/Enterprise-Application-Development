using DependencyInjection.Models.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Models.repositories
{
    public class EmployeeRepository : IEmployee
    {
        public List<EmployeeClass> GetAllEmployees()
        {
            var Employees = new List<EmployeeClass>();
            Employees.Add(new EmployeeClass(1,"Amna",50000));
            Employees.Add(new EmployeeClass(2, "Laiba", 50000));
            Employees.Add(new EmployeeClass(3, "Ameena", 50000));
            return Employees;

        }
    }
}
