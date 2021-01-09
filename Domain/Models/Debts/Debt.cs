using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Infra;
using Domain.Models.Customers;
using Domain.Models.Debts.Payments;

namespace Domain.Models.Debts
{
    public class Debt : Identificator
    {
        public Debt()
        {
            Status = EnumDebtStatus.Open;
            Payments = new List<DebtPayment>();
        }

        public int CustomerId { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Value { get; set; }
        public decimal PayValue { get; private set; }
        public decimal RemainingValue { get; private set; }
        public bool PaidLate { get; private set; }
        public EnumDebtStatus Status { get; private set; }

        public virtual Customer Customer { get; set; }
        public virtual List<DebtPayment> Payments { get; set; }

        public void Cancel()
        {
            Status = EnumDebtStatus.Canceled;
        }

        public void Calculate()
        {
            var validPayments = Payments.Where(p => p.Status != EnumDebtPaymentStatus.Canceled).ToList();

            PayValue = validPayments.Sum(p => p.Value);
            RemainingValue = Value - PayValue;
            PaidLate = validPayments.Any(p => p.Date > DueDate);
        }

        public override string ToString()
        {
            return Title;
        }
    }

    public enum EnumDebtStatus
    {
        Open = 0,
        Canceled = 1,
        Pay = 2
    }
}
