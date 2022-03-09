// microsoft built-in delegates
/*
        1-Action (refers to method which has void return type)
        2-Func (refers to method which has some return type )
        3-predicate (will be defined later)
*/
//Max numbers of paramteres passed to these built in delegates are 17
using System;

namespace AnonymousFunctions
{
    //no need to explicitly write delegates
    class Program
    {
        //you can write explicitly functions here too. but we are going to use anonymous function here.
        static void Main(string[] args)
        {
            Action d1 = () => Console.WriteLine("I am parameterless Action");
            d1();
            Action<int,string> d3 = (int x,string s) => Console.WriteLine("I am "+s+" with roll no "+x);
            d3(9,"Amna");

            Func<int, int, int, int, string> d2 = (int a, int b, int c, int d) =>
            {
                    int sum = a + b + c + d;
                    string s = "sum: " + sum;
                    return s;

            };
            d2(1, 1, 1, 1);
            Func<string> d4 = () => "i am returned string.";
            Console.WriteLine(d4());
        }
    }
}
