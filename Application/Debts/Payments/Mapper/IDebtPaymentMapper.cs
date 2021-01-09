using Application.Debts.Payments.Dto;
using Domain.Models.Debts.Payments;

namespace Application.Debts.Payments.Mapper
{
    public interface IDebtPaymentMapper
    {
        void Map(DebtPayment reg, DebtPaymentDto dto);
    }
}