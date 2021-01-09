using Domain.Models.Users;

namespace Application.Users.Validators
{
    public interface IUserValidator
    {
        void Validate(User user);
    }
}