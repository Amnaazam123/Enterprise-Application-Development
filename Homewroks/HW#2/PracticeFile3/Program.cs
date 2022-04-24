/*
 Multicasting(assigning multiple functions to one delegator)
delegateVar.Method
Params in delegator
 */


using System;
using calculator;

namespace delegates
{

    delegate int delegate1(int x,int y);
    delegate int delegate2(params int[] multiple);
    class Program
    {
        static public int paramFunc(params int[] argss)
        {
            int sum = 0;
            foreach(var i in argss)
            {
                sum += i;
            }
            return sum;
        }
        static void Main(string[] args)
        {
            myCalculator cal = new myCalculator();

            Console.WriteLine("BEFORE::");
            delegate1 d1 = cal.Add;
            d1 += cal.Multiplication;
            d1 += cal.Subtract;
            d1 += cal.Division;

            int result = d1(20, 2);             //all the functions in this order will be executed but result will store last delegate function result i.e division
            Console.WriteLine("Result : " + result);

            Console.WriteLine("\n\nAFTER::");
            d1 -= cal.Multiplication;
            result = d1(20, 2);
            Console.WriteLine("Result : " + result);

            Console.WriteLine("\\nn--Method-- returns last function of delegate.");
            Console.WriteLine(d1.Method);

            Console.WriteLine("\n\nPARAMS:");
            delegate2 d2 = paramFunc;
            Console.WriteLine(d2(1, 2, 3));
            Console.WriteLine(d2(1, 2, 3, 4, 5));
        }
    }
}
