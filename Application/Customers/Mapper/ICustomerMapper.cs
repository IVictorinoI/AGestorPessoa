using Application.Customers.Dto;
using Domain.Models.Customers;

namespace Application.Customers.Mapper
{
    public interface ICustomerMapper
    {
        void Map(Customer reg, CustomerDto dto);
    }
}