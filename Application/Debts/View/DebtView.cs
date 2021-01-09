using System;
using Application.Base;
using Domain.Models.Customers;
using Domain.Models.Debts;

namespace Application.Debts.View
{
    public class DebtView : IdView
    {
        public int CustomerId { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Value { get; set; }
        public decimal PayValue { get; set; }
        public decimal RemainingValue { get; set; }
        public bool PaidLate { get; set; }
        public EnumDebtStatus Status { get; set; }

        public static DebtView New(Debt reg)
        {
            return new DebtView()
            {
                Id = reg.Id,
                CustomerId = reg.CustomerId,
                Title = reg.Title,
                DueDate = reg.DueDate,
                Value = reg.Value,
                PayValue = reg.PayValue,
                RemainingValue = reg.RemainingValue,
                PaidLate = reg.PaidLate,
                Status = reg.Status,
            };
        }
    }
}
