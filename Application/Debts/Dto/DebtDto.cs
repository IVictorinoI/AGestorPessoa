using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Debts.Dto
{
    public class DebtDto
    {
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime DueDate { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public decimal Value { get; set; }
    }
}
