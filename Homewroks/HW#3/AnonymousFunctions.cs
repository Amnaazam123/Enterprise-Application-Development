//anonymous function - jahan function sirf delegate k liye hi use  kia jana ho, we come up with anonymous funnction
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
            count1 d1 = delegate
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
            d1 += delegate
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
            count2 d2 = delegate (int to)
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
            count3 d3 = delegate (int to)
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
        }
    }
}
