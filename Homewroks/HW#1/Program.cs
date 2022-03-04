//Main program
using System;
using PresentationLayer;

namespace EmployeeManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeViews EVs = new EmployeeViews();
            EVs.InputData();
        }
    }
}
