using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Base;
using Application.Debts.Payments;
using Application.Debts.Payments.Dto;
using Application.Debts.Payments.View;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/v1/debts/payments")]
    public class DebtPaymentController : AuthorizationController
    {
        [HttpPost]
        public async Task<ActionResult<DebtPaymentView>> Post(
            [FromServices] IAplicDebtPayment aplicDebtPayment,
            [FromBody] DebtPaymentDto dto)
        {
            return await aplicDebtPayment.Insert(dto);
        }

        [HttpGet]
        [Route("byCustomer/{cpf}")]
        public async Task<ActionResult<List<DebtPaymentView>>> GetByCustomer(
            [FromServices] IAplicDebtPayment aplicDebtPayment,
            string cpf)
        {
            return await aplicDebtPayment.GetByCustomer(cpf);
        }

        [HttpGet]
        [Route("byDebt/{id:int}")]
        public async Task<ActionResult<List<DebtPaymentView>>> GetByDebt(
            [FromServices] IAplicDebtPayment aplicDebtPayment,
            int id)
        {
            return await aplicDebtPayment.GetByDebt(id);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<DebtPaymentView>> Delete(
            [FromServices] IAplicDebtPayment aplicDebtPayment,
            int id)
        {
            return await aplicDebtPayment.Delete(id);
        }
    }
}
