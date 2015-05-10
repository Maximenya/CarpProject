using Carp.Logic.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Carp.Models
{
    public class RegisterUser : LoginUser
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; }


        [Range(1915, 2015)]
        public int BirthYear { get; set; }

        [Required]
        public string Gender { get; set; }


        public User ToUser()
        {
            return new User
            {
                BirthYear = BirthYear,
                Email = Email,
                Gender = Gender == "M" ? Logic.Entities.Gender.Male :
                    Logic.Entities.Gender.Female,
                Name = Name
            };
        }
    }
}
