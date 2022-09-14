// In model create folder named as "Mappers" or "ViewModels" or "DTO(Data Transfer Objects)"
// In that folder create class named as UserViewModel.cs
// This is the class to which an other class be mapped.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automappers.Models.UserViewModels
{
    public class UserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
