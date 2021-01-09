using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Base;
using Application.Customers;
using Application.Customers.Dto;
using Application.Customers.View;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/v1/customers")]
    public class CustomerController : AuthorizationController
    {
        [HttpPost]
        public async Task<ActionResult<CustomerView>> Post(
            [FromServices] IAplicCustomer aplicCustomer,
            [FromBody] CustomerDto dto)
        {
            return await aplicCustomer.Insert(dto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<CustomerView>> Put(
            [FromServices] IAplicCustomer aplicCustomer,
            int id,
            [FromBody] CustomerDto dto)
        {
            return await aplicCustomer.Update(id, dto);
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerView>>> Get(
            [FromServices] IAplicCustomer aplicCustomer)
        {
            return await aplicCustomer.Get();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<CustomerView>> Delete(
            [FromServices] IAplicCustomer aplicCustomer,
            int id)
        {
            return await aplicCustomer.Delete(id);
        }
    }
}
