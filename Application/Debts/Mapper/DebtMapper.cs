using System;
using System.Collections.Generic;
using System.Text;
using Application.Customers.Dto;
using Application.Data;
using Application.Debts.Dto;
using Domain.Models.Customers;
using Domain.Models.Debts;

namespace Application.Debts.Mapper
{
    public class DebtMapper : IDebtMapper
    {
        protected readonly DataContext Context;
        public DebtMapper(DataContext context)
        {
            Context = context;
        }

        public void Map(Debt reg, DebtDto dto)
        {
            reg.CustomerId = dto.CustomerId;
            reg.Customer = Context.Customers.Find(dto.CustomerId);
            reg.Title = dto.Title;
            reg.DueDate = dto.DueDate;
            reg.Value = dto.Value;
        }
    }
}
