using Application.DTOs.Users;
using Application.Features.Authenticate.Command.AuthenticateCommand;
using Application.Features.Authenticate.Command.RegisterCommand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseApiController
    {
        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await Mediator.Send(new AuthenticateCommand
            {
                Email=request.Email,
                Password=request.Password,
                IpAddress=GenerateIpAddres()
            }));
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterRequest request)
        {
            return Ok(await Mediator.Send(new RegisterCommand
            {
                Name=request.Name,
                Email = request.Email,
                Password = request.Password,
                ConfirmPassword=request.ConfirmPassword,
                UserName=request.UserName,
                Origin = Request.Headers["origin"]
            }));
        }

        private string GenerateIpAddres()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}
