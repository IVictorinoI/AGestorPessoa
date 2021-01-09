using Domain.Models.Customers;

namespace Application.Customers.Validators
{
    public interface ICustomerValidator
    {
        void Validate(Customer reg);
    }
}