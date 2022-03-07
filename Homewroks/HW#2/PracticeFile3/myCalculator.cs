using System;
using System.Collections.Generic;
using System.Text;

namespace calculator
{
    public class myCalculator
    {
        public int Add(int x,int y)
        {
            Console.WriteLine("Addition called");
            return x + y;
        }
        public int Subtract(int x, int y)
        {
            Console.WriteLine("Subtraction called");
            return x - y;
        }
        public int Multiplication(int x, int y)
        {
            Console.WriteLine("Multiplication called");
            return x * y;
        }
        public int Division(int x, int y)
        {
            Console.WriteLine("Division called");
            return x / y;
        }

      
    }
}
