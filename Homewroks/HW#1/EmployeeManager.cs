using System;
using System.Collections.Generic;
using System.Text;
using BusinessObjects;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class EmployeeManager
    {
        public List<EmployeeBusinessObjects> saveEmployee(EmployeeBusinessObjects EBO)
        {
            if (EBO.Salary >= 100)
            {
                EBO.Tax = EBO.Salary * 0.2f;
            }
            else
            {
                EBO.Tax = EBO.Salary * 0.1f;
            }
            EmpolyeeDataLayer EDL = new EmpolyeeDataLayer();
            EDL.TakeData(EBO);
            List<EmployeeBusinessObjects> list = EDL.readData();
            return list;
        }
    }
}
