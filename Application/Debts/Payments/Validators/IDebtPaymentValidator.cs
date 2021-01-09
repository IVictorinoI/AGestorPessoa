using Domain.Models.Customers;
using Domain.Models.Debts.Payments;

namespace Application.Debts.Payments.Validators
{
    public interface IDebtPaymentValidator
    {
        void Validate(DebtPayment reg);
    }
}