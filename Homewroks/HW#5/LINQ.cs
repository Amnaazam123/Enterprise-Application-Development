/*
 LINQ(language integrated query)
         - query is a part of language. It helps to find error on compile time in query.
         - hr datasource se data retrive krny ka syntax same ho jata is ki badolat. 
 */


using System;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {

            static bool NameLongerThan4(string cityName)
            {
                return cityName.Length > 4;
            }


            //declaring an array of string
            string[] cities = new string[] { "Lhr", "Okara" };

            //query
            var query = cities.Where(NameLongerThan4);

            //printing result
            foreach (var city in query)
            {
                Console.WriteLine(city);
            }
        }
    }
}
