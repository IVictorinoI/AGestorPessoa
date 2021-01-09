using Domain.Models.Users;

namespace Application.Users.Current
{
    public interface ICurrentUser
    {
        User Get();
    }
}