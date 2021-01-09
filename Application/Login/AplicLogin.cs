using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Base;
using Application.Data;
using Application.Login.Config;
using Application.Login.Dto;
using Application.Login.View;
using Application.Users.View;
using Microsoft.EntityFrameworkCore;

namespace Application.Login
{
    public class AplicLogin : Aplic, IAplicLogin
    {

        public AplicLogin(DataContext context) : base(context)
        {
        }

        public async Task<LoginView> Login(LoginDto dto)
        {
            var reg = await Context.Users.FirstOrDefaultAsync(p => p.Email == dto.Email && p.Password == dto.Password);

            if(reg == null)
                throw new Exception("Usuário/Senha inválidos.");

            var token = TokenService.GenerateToken(reg);

            return new LoginView()
            {
                Token = token,
                User = UserView.New(reg)
            };
        }
    }
}
