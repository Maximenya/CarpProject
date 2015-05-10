using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Carp.Models
{
    public class LoginUser
    {
        [Required]
        [MinLength(6)]
        [MaxLength(15)]
        public string Password { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
