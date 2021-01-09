using Domain.Models.Debts;

namespace Application.Debts.Validators
{
    public interface IDebtValidator
    {
        void Validate(Debt reg);
    }
}