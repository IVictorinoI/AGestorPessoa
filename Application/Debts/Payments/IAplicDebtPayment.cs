using System.Collections.Generic;
using Application.Debts.Payments.Dto;
using Application.Debts.Payments.View;
using System.Threading.Tasks;

namespace Application.Debts.Payments
{
    public interface IAplicDebtPayment
    {
        Task<DebtPaymentView> Insert(DebtPaymentDto dto);
        Task<DebtPaymentView> Delete(int id);
        Task<List<DebtPaymentView>> GetByCustomer(string cpf);
        Task<List<DebtPaymentView>> GetByDebt(int id);
    }
}
