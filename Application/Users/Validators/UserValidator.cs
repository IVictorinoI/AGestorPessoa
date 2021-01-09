using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Data;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Validators
{
    public class UserValidator : IUserValidator
    {
        private readonly DataContext _context;
        public UserValidator(DataContext context)
        {
            _context = context;
        }

        public void Validate(User user)
        {
            ValidateDuplicity(user);
        }

        private void ValidateDuplicity(User user)
        {
            var other = _context.Users.FirstOrDefault(p => p.Email == user.Email && p.Id != user.Id);

            if (other != null)
                throw new Exception("Já existe outro usuário com este email.");
        }
    }
}
