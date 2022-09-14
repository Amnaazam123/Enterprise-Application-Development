// To map data from one class to other, we need to create profiles.
// Create folder "MappingConfigurations" in your project.
// Add class "userProfile.cs" in that folder.

//add this namespace
using AutoMapper;

using Automappers.Models;
using Automappers.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automappers.MappingConfigurations
{
    //inherit it from Profile(provided by installed AutoMapper package)
    public class UserProfile : Profile
    {
        //Make constructor
        public UserProfile()
        {
            // Default mapping when property names are same
            // Here we are mapping User class objects to UserViewModel class objects.

            CreateMap<User, UserViewModel>();

            // Mapping when property names are different
            //Actually we are explicitly mentioning here that which attribute should be mapped to which. 
            /* CreateMap<User, UserViewModel>()
                 .ForMember(dest =>
                 dest.FName,+
                 opt => opt.MapFrom(src => src.FirstName))
                 .ForMember(dest =>
                 dest.LName,
                 opt => opt.MapFrom(src => src.LastName));*/

        }

    }
}
