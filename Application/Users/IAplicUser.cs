using System.Threading.Tasks;
using Application.Users.Dto;
using Application.Users.View;
using Domain.Models;
using Domain.Models.Users;

namespace Application.Users
{
    public interface IAplicUser
    {
        Task<UserView> Insert(UserDto dto);
        Task<UserView> Update(int id, UserDto dto);
    }
}