using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Data;
using Domain.Models.Customers;
using Domain.Models.Debts;
using Domain.Models.Debts.Payments;

namespace Application.Debts.Payments.Validators
{
    public class DebtPaymentValidator : IDebtPaymentValidator
    {
        private readonly DataContext _context;
        public DebtPaymentValidator(DataContext context)
        {
            _context = context;
        }


        public void Validate(DebtPayment reg)
        {
            ValidateNegativeValue(reg);
            ValidateDebt(reg);
        }

        private void ValidateDebt(DebtPayment reg)
        {
            if(reg.Debt == null)
                throw new Exception(string.Format("Débito {0} não existe.", reg.DebtId));

            if(reg.Debt.Status == EnumDebtStatus.Canceled)
                throw new Exception(string.Format("Débito {0} Está cancelado e não pode mais receber pagamentos.", reg.Debt));

            if (reg.Debt.Status == EnumDebtStatus.Pay)
                throw new Exception(string.Format("Débito {0} Está pago e não pode mais receber pagamentos.", reg.Debt));
        }

        private void ValidateNegativeValue(DebtPayment reg)
        {
            if (reg.Value < 0)
                throw new Exception("Não é permitido valor negativo.");
        }
    }
}
