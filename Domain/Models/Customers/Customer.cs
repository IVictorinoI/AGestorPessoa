using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain.Infra;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Domain.Models.Customers
{
    public class Customer : Identificator
    {
        public Customer()
        {
            Active = true;
        }

        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Occupation { get; set; }
        public decimal Salary { get; set; }
        public bool Active { get; private set; }

        public void Inactive()
        {
            Active = false;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, Cpf);
        }
    }
}
