
/*
 * 
 * -------------This is method syntax to use LINQ.
 * -------------Next we will see query syntax to use LINQ.
 * 
 LINQ(Language Integrated Query):
       It includes three steps:
            - Define data source
            - Define Query
            - Query Execution (Query execute tb hoti hai jb us ko use kia ja ra ho)

Note: agr kisi input pe where condition false result day tou
wo udr hi us ko ignore kr k us condition ko next pe test krny lg jata hai.

LINQ uses extension method, it means that it seems like that some methods are defined
in that class with which we used "." but it is not. They are defined
in some other space or library.
e.g., WHERE method is not defined in any string class but in System.Linq library. 
 */


using System;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {


            //1 - define data source
            string[] cities = new string[] { "Lhr", "Okaraaa" };

            //2 - query using lamda expression
            //lamda expression do not use return keyword and we do not need to specify the parameter data type as well.
            var query = cities.Where(cityName => cityName.Length > 5);     //extension method - Where is not any method defined in string array but in system.linq space.


            //Here query has its data type IEnumerator because it is not executing,just defined. Query executes when you explicitly
            //define data collection. i.e. toList. This method defines and executes query as well.
            //var query = cities.Where(cityName => cityName.Length > 5).ToList();


            //where clause se jo result filter ho k aya us ko kis tarha ap print krwana chah ry? (yahan wo pehle 3 characters hen)
            var query2 = cities
                         .Where(cityName => cityName.Length > 5)
                         .Select(cityName => cityName.Substring(0, 3));

            //3 - execution of query
            foreach (var city in query)
            {
                Console.WriteLine(city);
            }
            //3 - execution of query
            foreach (var city in query2)
            {
                Console.WriteLine(city);
            }
        }
    }
}
