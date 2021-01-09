using Application.Debts.Dto;
using Domain.Models.Debts;

namespace Application.Debts.Mapper
{
    public interface IDebtMapper
    {
        void Map(Debt reg, DebtDto dto);
    }
}