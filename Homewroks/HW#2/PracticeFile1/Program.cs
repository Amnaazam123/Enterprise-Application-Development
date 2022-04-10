//BENEFITS of delgates:
/*
 1- runtime function invocation(we are not sure which function will be called, all depends on user input)
 2- function in the paramenter of other function
 */


using System;
using calculator;

namespace delegates
{
    delegate void delegate1();
    delegate int delegate2(int x, int y);
    delegate int delegate3(int x,int y);

    class Program
    {
        //Benefit 1: see fun1 and fun2
        static public void fun1()
        {
            Console.WriteLine("I am being called from delegate 1");
        }
        static public int fun2(int x,int y)
        {
            Console.WriteLine("I am being called from delegate 2");
            return x + y;
        }
        //Benefit 2: see fun3
        static public int fun3(delegate3 d3,int num1,int num2)
        {
            //after assiging delgator, we are calling func with delegate 3
            return d3(num1,num2);              //or d3.Invoke(num1,num2);
        }
        static void Main(string[] args)
        {
            
            delegate1 d1 = new delegate1(fun1);
            d1();                                  
            /* OR delegate1 d1 = fun1;
                  d1.Invoke();*/

            delegate2 d2 = new delegate2(fun2);
            d2(1, 2);
            /* OR delegate2 d2 = fun2;
                  d2(1,2);*/

            Console.WriteLine("BENEFIT - 2:");
            Console.WriteLine("1---Add\n2---Subtract\n3---Multiply\n4---Division\n");
            int input;
            Console.Write("Enter your choice : ");
            input=int.Parse(Console.ReadLine());
            Console.Write("Enter num1 : ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Enter num2 : ");
            int num2 = int.Parse(Console.ReadLine());
            int result;

            myCalculator cal = new myCalculator();                            //to access the function from calculator class
            if (input == 1)
            {
               result = fun3(cal.Add, num1, num2);                        //Add fun is being assigned to delegate 3.
            }
            else if (input == 2)
            {
                result = fun3(cal.Subtract, num1, num2);                    //subtract fun is being assigned to delegate 3.
            }
            else if (input == 3)
            {
                result = fun3(cal.Multiplication, num1, num2);              //mul fun is being assigned to delegate 3.
            }
            else if (input == 4)
            {
                result = fun3(cal.Division, num1, num2);                   //div fun is being assigned to delegate 3.
            }
            else
            {
                return;
            }
            Console.WriteLine("Result : " + result);
           
        }
    }
}
