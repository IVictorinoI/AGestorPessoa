using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Customers.Dto;
using Application.Customers.View;
using Application.Debts.Dto;
using Application.Debts.View;

namespace Application.Debts
{
    public interface IAplicDebt
    {
        Task<DebtView> Insert(DebtDto dto);
        Task<DebtView> Update(int id, DebtDto dto);
        Task<DebtView> Delete(int id);
        Task<List<DebtView>> GetByCustomer(string cpf);
    }
}
