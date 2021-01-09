using System;
using Application.Base;
using Domain.Models.Customers;
using Domain.Models.Debts.Payments;

namespace Application.Debts.Payments.View
{
    public class DebtPaymentView : IdView
    {
        public int DebtId { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public EnumDebtPaymentStatus Status { get; set; }

        public static DebtPaymentView New(DebtPayment reg)
        {
            return new DebtPaymentView()
            {
                Id = reg.Id,
                DebtId = reg.DebtId,
                Date = reg.Date,
                Value = reg.Value,
                Status = reg.Status,
            };
        }
    }
}
