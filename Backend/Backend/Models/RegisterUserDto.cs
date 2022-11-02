using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class RegisterUserDto 
    {
      
       public string Password { get; set; }

        public string ConfirmPassword { get; set; }
       
       public string Login { get; set; }
    }
}
