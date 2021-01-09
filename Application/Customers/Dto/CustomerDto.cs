using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.Customers.Dto
{
    public class CustomerDto
    {
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(100, ErrorMessage = "Este campo deve ter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve ter entre 3 e 60 caracteres")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(11, ErrorMessage = "Este campo deve ter 11 caracteres")]
        [MinLength(11, ErrorMessage = "Este campo deve ter 11 caracteres")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        [MaxLength(100, ErrorMessage = "Este campo deve ter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve ter entre 3 e 60 caracteres")]
        public string Occupation { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public decimal Salary { get; set; }
    }
}
