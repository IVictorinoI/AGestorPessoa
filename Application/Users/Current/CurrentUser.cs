using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Data;
using Domain.Models.Users;
using Microsoft.AspNetCore.Http;

namespace Application.Users.Current
{
    public class CurrentUser : ICurrentUser
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUser(DataContext context, 
                           IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public User Get()
        {
            var claimValue = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(p => p.Type == "Id")?.Value;

            int.TryParse(claimValue, out int userId);

            var user = _context.Users.Find(userId);

            if(user == null)
                throw new Exception("Usuário não encontrado no Claim.");

            return user;
        }
    }
}
