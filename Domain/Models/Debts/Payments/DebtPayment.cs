using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Domain.Infra;

namespace Domain.Models.Debts.Payments
{
    public class DebtPayment : Identificator
    {
        public DebtPayment()
        {
            Status = EnumDebtPaymentStatus.Completed;
        }
        public int DebtId { get; set; }

        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public EnumDebtPaymentStatus Status { get; private set; }

        public virtual Debt Debt { get; set; }

        public void Cancel()
        {
            Status = EnumDebtPaymentStatus.Canceled;
        }

        public override string ToString()
        {
            return string.Format("Pagamento no valor de {0}", Value);
        }
    }

    public enum EnumDebtPaymentStatus
    {
        Completed = 0,
        Canceled = 1
    }
}
