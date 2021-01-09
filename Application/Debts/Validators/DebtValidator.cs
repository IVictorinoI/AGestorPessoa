using System;
using System.Linq;
using Application.Customers.Validators;
using Application.Data;
using Domain.Models.Debts;
using Domain.Models.Debts.Payments;

namespace Application.Debts.Validators
{
    public class DebtValidator : IDebtValidator
    {
        private readonly DataContext _context;
        public DebtValidator(DataContext context)
        {
            _context = context;
        }

        public void Validate(Debt reg)
        {
            ValidateNegativeValue(reg);
            ValidatePayments(reg);
            ValidateCustomer(reg);
        }

        private void ValidateCustomer(Debt reg)
        {
            if(reg.Customer == null)
                throw new Exception("Cliente não informado.");

            if(!reg.Customer.Active)
                throw new Exception(string.Format("O cliente {0} está inativo e não pode receber movimentações.", reg.Customer));
        }

        private void ValidatePayments(Debt reg)
        {
            if (reg.PayValue > reg.Value)
                throw new Exception(string.Format("Não é permitido pagar um valor maior do que o valor da dívida. Valor pago:'{0}' Valor dívida: '{1}'.", reg.PayValue, reg.Value));
        }

        private void ValidateNegativeValue(Debt reg)
        {
            if (reg.Value < 0)
                throw new Exception("Não é permitido valor negativo.");
        }
    }
}
