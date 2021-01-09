using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;
using Domain.Models.Users;

namespace Application.Users.View
{
    public class UserView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public static UserView New(User p)
        {
            return new UserView()
            {
                Id = p.Id,
                Email = p.Email,
                Name = p.Name
            };
        }
    }
}
