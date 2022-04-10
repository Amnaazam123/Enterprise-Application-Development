//Lamda statements -- include multiple statements in function body
//Lamda expressions -- include single statement line in function body

using System;

namespace AnonymousFunctions
{
    delegate void count1();
    delegate void count2(int to);
    delegate int count3(int to);

    class Program
    {
        //no need to write explicitly functions here.
        static void Main(string[] args)
        {

            //--------------------------------------------lamda STATEMENTS
            Console.WriteLine("\nLamda STATEMENTS :: \n");
            count1 d1 = () =>
            {
                Console.Write("sum of first 10 digits: ");
                int i = 1,sum=0;
                while (i != 11)
                {
                    sum += i;
                    i++;
                }
                Console.WriteLine(sum);
            };
            d1 += () =>
            {
                Console.Write("sum of first 5 digits: ");
                int i = 1, sum = 0;
                while (i != 6)
                {
                    sum += i;
                    i++;
                }
                Console.WriteLine(sum);
            };
            d1();
            Console.Write("You want to print sum of numbers between 1 and ____________?\nInput : ");
            int num;
            num=int.Parse(Console.ReadLine());
            count2 d2 = (int to) =>
            {
                Console.Write("sum of first "+num+" digits: ");
                int i = 1, sum = 0;
                while (i != to+1)
                {
                    sum += i;
                    i++;
                }
                Console.WriteLine(sum);
            };
            d2(num);
            count3 d3 = (int to) =>
            {
                 Console.Write("sum of first " + num + " digits: ");
                 int i = 1, sum = 0;
                  while (i != to + 1)
                  {
                      sum += i;
                      i++;
                  }
                  return sum;
            };
            Console.WriteLine(d3(num));

            //---------------------------------------lamda EXPRESSIONS
            Console.WriteLine("\n\nLamda EXPRESSIONS :: \n");
            count1 c1 = () => Console.WriteLine("I am lamda expression");
            c1();

            count2 c2 = (int x) => Console.WriteLine("I am " + x);
            c2(num);

            count3 c3 = (int x)=> x*5;
            Console.WriteLine(c3(num)+" is returned value.");

        }
    }
}
