using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain.Infra;

namespace Domain.Models.Users
{
    public class User : Identificator
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string GetRole()
        {
            return "DefaultRole";
        }
    }
}
