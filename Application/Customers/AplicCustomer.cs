using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Base;
using Application.Customers.Dto;
using Application.Customers.Mapper;
using Application.Customers.Validators;
using Application.Customers.View;
using Application.Data;
using Domain.Models.Customers;
using Microsoft.EntityFrameworkCore;

namespace Application.Customers
{
    public class AplicCustomer : Aplic, IAplicCustomer
    {
        private readonly ICustomerValidator _customerValidator;
        private readonly ICustomerMapper _customerMapper;
        public AplicCustomer(DataContext context, ICustomerValidator customerValidator, ICustomerMapper customerMapper) : base(context)
        {
            _customerValidator = customerValidator;
            _customerMapper = customerMapper;
        }

        public async Task<CustomerView> Insert(CustomerDto dto)
        {
            var reg = new Customer();
            _customerMapper.Map(reg, dto);

            _customerValidator.Validate(reg);

            await Context.Customers.AddAsync(reg);
            await Context.SaveChangesAsync();

            return CustomerView.New(reg);
        }

        public async Task<CustomerView> Update(int id, CustomerDto dto)
        {
            var reg = await Context.Customers.FindAsync(id);
            _customerMapper.Map(reg, dto);

            _customerValidator.Validate(reg);

            await Context.SaveChangesAsync();

            return CustomerView.New(reg);
        }

        public async Task<List<CustomerView>> Get()
        {
            var regs = await Context.Customers
                .Where(p => p.Active)
                .AsNoTracking()
                .ToListAsync();

            return regs.Select(CustomerView.New).ToList();
        }

        public async Task<List<CustomerView>> GetByCpf(string cpf)
        {
            var regs = await Context.Customers
                .Where(p => p.Cpf == cpf)
                .AsNoTracking()
                .ToListAsync();

            return regs.Select(CustomerView.New).ToList();
        }

        public async Task<CustomerView> Delete(int id)
        {
            var reg = await Context.Customers.FirstOrDefaultAsync(p => p.Id == id);

            reg.Inactive();

            await Context.SaveChangesAsync();

            return CustomerView.New(reg);
        }
    }
}
