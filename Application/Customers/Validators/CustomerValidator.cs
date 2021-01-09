using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Application.Data;
using Domain.Models.Customers;

namespace Application.Customers.Validators
{
    public class CustomerValidator : ICustomerValidator
    {
        private readonly DataContext _context;
        public CustomerValidator(DataContext context)
        {
            _context = context;
        }

        public void Validate(Customer reg)
        {
            ValidateDuplicity(reg);
        }

        private void ValidateDuplicity(Customer reg)
        {
            var other = _context.Customers.FirstOrDefault(p => p.Cpf == reg.Cpf &&
                                                               p.Active &&
                                                               p.Id != reg.Id);

            if (other != null)
                throw new Exception(string.Format("Já existe outro cliente com este CPF {0}.", other));
        }
    }
}
