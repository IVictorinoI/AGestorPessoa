using System;
using System.Collections.Generic;
using System.Text;
using Application.Customers.Dto;
using Domain.Models.Customers;

namespace Application.Customers.Mapper
{
    public class CustomerMapper : ICustomerMapper
    {
        public void Map(Customer reg, CustomerDto dto)
        {
            reg.Name = dto.Name;
            reg.Cpf = dto.Cpf;
            reg.BirthDate = dto.BirthDate;
            reg.Address = dto.Address;
            reg.Occupation = dto.Occupation;
            reg.Salary = dto.Salary;
        }
    }
}
