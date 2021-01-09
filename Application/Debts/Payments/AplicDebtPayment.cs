using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Base;
using Application.Customers.Dto;
using Application.Customers.Mapper;
using Application.Customers.Validators;
using Application.Customers.View;
using Application.Data;
using Application.Debts.Payments.Dto;
using Application.Debts.Payments.Mapper;
using Application.Debts.Payments.Validators;
using Application.Debts.Payments.View;
using Application.Debts.Validators;
using Domain.Models.Customers;
using Domain.Models.Debts.Payments;
using Microsoft.EntityFrameworkCore;

namespace Application.Debts.Payments
{
    public class AplicDebtPayment : Aplic, IAplicDebtPayment
    {
        private readonly IDebtPaymentValidator _customerValidator;
        private readonly IDebtPaymentMapper _debtPaymentMapper;
        private readonly IDebtValidator _debtValidator;
        public AplicDebtPayment(DataContext context, IDebtPaymentValidator customerValidator, IDebtPaymentMapper debtPaymentMapper, IDebtValidator debtValidator) : base(context)
        {
            _customerValidator = customerValidator;
            _debtPaymentMapper = debtPaymentMapper;
            _debtValidator = debtValidator;
        }

        public async Task<DebtPaymentView> Insert(DebtPaymentDto dto)
        {
            var reg = new DebtPayment();
            _debtPaymentMapper.Map(reg, dto);

            _customerValidator.Validate(reg);

            reg.Debt.Payments.Add(reg);

            reg.Debt.Calculate();

            _debtValidator.Validate(reg.Debt);

            await Context.DebtPayments.AddAsync(reg);
            await Context.SaveChangesAsync();

            return DebtPaymentView.New(reg);
        }

        public async Task<DebtPaymentView> Delete(int id)
        {
            var reg = await Context.DebtPayments.FindAsync(id);

            reg.Cancel();

            reg.Debt.Calculate();

            await Context.SaveChangesAsync();

            return DebtPaymentView.New(reg);
        }

        public async Task<List<DebtPaymentView>> GetByCustomer(string cpf)
        {
            var regs = await Context.DebtPayments
                .Where(p => p.Status != EnumDebtPaymentStatus.Canceled &&
                            p.Debt.Customer.Cpf == cpf &&
                            p.Debt.Customer.Active)
                .AsNoTracking()
                .ToListAsync();

            return regs.Select(DebtPaymentView.New).ToList();
        }

        public async Task<List<DebtPaymentView>> GetByDebt(int id)
        {
            var regs = await Context.DebtPayments
                .Where(p => p.Status != EnumDebtPaymentStatus.Canceled &&
                            p.DebtId == id)
                .AsNoTracking()
                .ToListAsync();

            return regs.Select(DebtPaymentView.New).ToList();
        }

    }
}
