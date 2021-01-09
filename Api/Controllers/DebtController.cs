using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Base;
using Application.Debts;
using Application.Debts.Dto;
using Application.Debts.View;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/v1/debts")]
    public class DebtController : AuthorizationController
    {
        [HttpPost]
        public async Task<ActionResult<DebtView>> Post(
            [FromServices] IAplicDebt aplicDebt,
            [FromBody] DebtDto dto)
        {
            return await aplicDebt.Insert(dto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<DebtView>> Put(
            [FromServices] IAplicDebt aplicDebt,
            int id,
            [FromBody] DebtDto dto)
        {
            return await aplicDebt.Update(id, dto);
        }

        [HttpGet]
        [Route("{cpf}")]
        public async Task<ActionResult<List<DebtView>>> GetByCustomer(
            [FromServices] IAplicDebt aplicDebt,
            string cpf)
        {
            return await aplicDebt.GetByCustomer(cpf);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<DebtView>> Delete(
            [FromServices] IAplicDebt aplicDebt,
            int id)
        {
            return await aplicDebt.Delete(id);
        }
    }
}
