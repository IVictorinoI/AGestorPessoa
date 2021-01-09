using System;
using System.Collections.Generic;
using System.Text;
using Application.Users.Dto;
using Domain.Models;
using Domain.Models.Users;

namespace Application.Users.Mapper
{
    public class UserMapper
    {
        public void Map(User reg, UserDto dto)
        {
            reg.Name = dto.Name;
            reg.Email = dto.Email;
            reg.Password = dto.Password;
        }
    }
}
