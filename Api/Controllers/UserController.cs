using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Base;
using Application.Users;
using Application.Users.Dto;
using Application.Users.View;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/v1/users")]
    public class UserController : AuthorizationController
    {
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<UserView>> Put(
            [FromServices] IAplicUser aplicUser,
            int id,
            [FromBody] UserDto dto)
        {
            return await aplicUser.Update(id, dto);
        }

    }
}
