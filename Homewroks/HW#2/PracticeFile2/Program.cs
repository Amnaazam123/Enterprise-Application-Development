/*FOCUS : you do not want to change main.
you add functions in class library i.e. class library named Calculator has one delegate, some functions and one function returning special delegate depending on user input.
Benefit:
Later on you just add functions in class library and add those functions in delegate too to return that particular delegate without changing main. 
 */


using System;
using calculator;

namespace delegates
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1---Add\n2---Subtract\n3---Multiply\n4---Division\n");
            int input;
            Console.Write("Enter your choice : ");
            input=int.Parse(Console.ReadLine());
            Console.Write("Enter num1 : ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Enter num2 : ");
            int num2 = int.Parse(Console.ReadLine());

            myCalculator cal = new myCalculator();                              //to access the function from calculator class
            var d = cal.getFunctionality(input);                                //getting delegate against userInput
            int result = d(num1, num2);                                         //invoking function with delegate(this is such delegate which takes 2 parameters and return one integer)
            Console.WriteLine("Result : " + result);
           
        }
    }
}
