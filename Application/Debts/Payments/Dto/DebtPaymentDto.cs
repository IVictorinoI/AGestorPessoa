using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Debts.Payments.Dto
{
    public class DebtPaymentDto
    {
        public int DebtId { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
    }
}
