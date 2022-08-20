using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code_First_Approach_EF.Models
{
    public class Product
    {
        //EF will consider ID coloumn primary key, autoincrement.
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
