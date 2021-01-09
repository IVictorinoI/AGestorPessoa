using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Customers.Dto;
using Application.Customers.View;

namespace Application.Customers
{
    public interface IAplicCustomer
    {
        Task<CustomerView> Insert(CustomerDto dto);
        Task<CustomerView> Update(int id, CustomerDto dto);
        Task<List<CustomerView>> Get();
        Task<List<CustomerView>> GetByCpf(string cpf);
        Task<CustomerView> Delete(int id);
    }
}
