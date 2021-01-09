using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Base;
using Application.Data;
using Application.Debts.Dto;
using Application.Debts.Mapper;
using Application.Debts.Validators;
using Application.Debts.View;
using Domain.Models.Customers;
using Domain.Models.Debts;
using Microsoft.EntityFrameworkCore;

namespace Application.Debts
{
    public class AplicDebt : Aplic, IAplicDebt
    {
        private readonly IDebtValidator _customerValidator;
        private readonly IDebtMapper _debtMapper;
        public AplicDebt(DataContext context, IDebtValidator customerValidator, IDebtMapper debtMapper) : base(context)
        {
            _customerValidator = customerValidator;
            _debtMapper = debtMapper;
        }

        public async Task<DebtView> Insert(DebtDto dto)
        {
            var reg = new Debt();
            _debtMapper.Map(reg, dto);

            _customerValidator.Validate(reg);

            await Context.Debts.AddAsync(reg);
            await Context.SaveChangesAsync();

            return DebtView.New(reg);
        }

        public async Task<DebtView> Update(int id, DebtDto dto)
        {
            var reg = await Context.Debts.FindAsync(id);
            _debtMapper.Map(reg, dto);

            _customerValidator.Validate(reg);

            await Context.SaveChangesAsync();

            return DebtView.New(reg);
        }

        public async Task<DebtView> Delete(int id)
        {
            var reg = await Context.Debts.FindAsync(id);

            reg.Cancel();

            await Context.SaveChangesAsync();

            return DebtView.New(reg);
        }

        public async Task<List<DebtView>> GetByCustomer(string cpf)
        {
            var regs = await Context.Debts
                .Where(p => p.Status != EnumDebtStatus.Canceled &&
                            p.Customer.Cpf == cpf &&
                            p.Customer.Active)
                .AsNoTracking()
                .ToListAsync();

            return regs.Select(DebtView.New).ToList();
        }
    }
}
