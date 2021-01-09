using Application.Data;
using Application.Debts.Payments.Dto;
using Domain.Models.Customers;
using Domain.Models.Debts.Payments;

namespace Application.Debts.Payments.Mapper
{
    public class DebtPaymentMapper : IDebtPaymentMapper
    {
        protected readonly DataContext Context;
        public DebtPaymentMapper(DataContext context)
        {
            Context = context;
        }
        public void Map(DebtPayment reg, DebtPaymentDto dto)
        {
            reg.DebtId = dto.DebtId;
            reg.Debt = Context.Debts.Find(dto.DebtId);
            reg.Date = dto.Date;
            reg.Value = dto.Value;
        }
    }
}
