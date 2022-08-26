using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Models.interfaces
{
    public interface IEmployee
    {
        //interface has only function declarations
        public List<EmployeeClass> GetAllEmployees();            
    }
}
