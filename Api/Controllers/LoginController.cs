using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Login;
using Application.Login.Dto;
using Application.Login.View;
using Application.Users;
using Application.Users.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/v1/login")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<LoginView>> Authenticate([FromServices] IAplicLogin aplicLogin, [FromBody] LoginDto dto)
        {
            return await aplicLogin.Login(dto);
        }

        [HttpPost("SignIn")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginView>> SignIn([FromServices] IAplicLogin aplicLogin, [FromServices] IAplicUser aplicUser, [FromBody] UserDto dto)
        {
            await aplicUser.Insert(dto);

            return await aplicLogin.Login(new LoginDto()
            {
                Password = dto.Password,
                Email = dto.Email
            });
        }
    }
}
