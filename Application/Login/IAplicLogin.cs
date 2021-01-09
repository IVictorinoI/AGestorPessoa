using System.Threading.Tasks;
using Application.Login.Dto;
using Application.Login.View;

namespace Application.Login
{
    public interface IAplicLogin
    {
        Task<LoginView> Login(LoginDto dto);
    }
}