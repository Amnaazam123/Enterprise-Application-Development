using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code_First_Approach_EF.Models
{
    //inherit class from DBContext(using Microsoft.EntityFrameworkCore;)
    public class ShopContext : DbContext
    {
        
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
       => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CodeFirstDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        //click on localdb server in which you want to create database. (Properties > connection string)
        //catalog="yahan wo naam likhen jis naam ki DB ap create krna chahty hen" (here we are crating DB named as CodeFirstDB)


    }
}



//After creating both classes run these commands:
//Add-Migration AnyMigrationName -> it willl generate Migration folder which will help in creating DB. 
//Update-Database -> This command will create/show DB mntion in catalog="______" in connection string.
