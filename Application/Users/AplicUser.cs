using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Base;
using Application.Data;
using Application.Users.Dto;
using Application.Users.Mapper;
using Application.Users.Validators;
using Application.Users.View;
using Domain.Models;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Users
{
    public class AplicUser : Aplic, IAplicUser
    {
        private readonly IUserValidator _userValidator;
        public AplicUser(DataContext context, IUserValidator userValidator) : base(context)
        {
            _userValidator = userValidator;
        }

        public async Task<UserView> Insert(UserDto dto)
        {
            var reg = new User();
            new UserMapper().Map(reg, dto);

            _userValidator.Validate(reg);

            await Context.Users.AddAsync(reg);
            await Context.SaveChangesAsync();

            return UserView.New(reg);
        }

        public async Task<UserView> Update(int id, UserDto dto)
        {
            var reg = await Context.Users.FindAsync(id);
            new UserMapper().Map(reg, dto);

            _userValidator.Validate(reg);

            await Context.SaveChangesAsync();

            return UserView.New(reg);
        }
    }
}
