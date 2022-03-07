using System;
using System.Collections.Generic;
using System.Text;

namespace calculator
{
    public delegate int MathOperation(int x, int y);
    public class myCalculator
    {
        public int Add(int x,int y)
        {
            return x + y;
        }
        public int Subtract(int x, int y)
        {
            return x - y;
        }
        public int Multiplication(int x, int y)
        {
            return x * y;
        }
        public int Division(int x, int y)
        {
            return x / y;
        }

        public MathOperation getFunctionality(int userInput)
        {
            MathOperation d = null;
            if (userInput == 1)
            {
                d = Add;
            }
            else if (userInput == 2)
            {
                d = Subtract;
            }
            else if (userInput == 3)
            {
                d = Multiplication;
            }
            else if (userInput == 4)
            {
                d = Division;
            }
            return d;
        }
    }
}
