//create this class in Models folder
//This is the class having all attributes in it, which will be mapped to another class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automappers.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
