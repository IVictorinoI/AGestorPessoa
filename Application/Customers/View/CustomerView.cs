using System;
using System.Collections.Generic;
using System.Text;
using Application.Base;
using Domain.Models.Customers;

namespace Application.Customers.View
{
    public class CustomerView : IdView
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Occupation { get; set; }
        public decimal Salary { get; set; }
        public bool Active { get; set; }

        public static CustomerView New(Customer reg)
        {
            return new CustomerView()
            {
                Id = reg.Id,
                Name = reg.Name,
                Cpf = reg.Cpf,
                BirthDate = reg.BirthDate,
                Address = reg.Address,
                Occupation = reg.Occupation,
                Salary = reg.Salary,
                Active = reg.Active
            };
        }
    }
}
