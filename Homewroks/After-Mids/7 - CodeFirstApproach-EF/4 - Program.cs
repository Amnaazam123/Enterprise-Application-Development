//where Product is your table name.

using System;
using System.Linq;

namespace Code_First_Approach_EF.Models
{
    class Program
    {
        static void Main(string[] args)
        {
            //creating instances for both classes
            var context = new ShopContext();
            Product p = new Product();


            //initializing your table attributes
            p.Id = 2;
            p.Name = "Mobile";

            //adding in tabble
            //see here context is using to add your data in table.
            context.Product.Add(p);
            context.SaveChanges();

            //Did you noticed there was no insert query!!! OMG, ORM naughty you here.

            //Now let see for updation
            //get data which you want to update.
            var product = context.Product.First();         //using Linq here
            Console.WriteLine(product);

            //for getting any other product(not first)
            //var product1 = context.Product.Where(product => product.Id == 5);
            product.Name = "Laptop";
            context.SaveChanges();

            //deleting or removing data
            context.Product.Remove(product);
            context.SaveChanges();


            //data retrieval
            var query = context.Product.Where(p => p.Id == 10);         //any condtion in where clause for data retrieval






        }
    }
}
