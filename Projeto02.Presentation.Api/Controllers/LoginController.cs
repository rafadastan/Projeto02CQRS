using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto02.Application.Interfaces;
using Projeto02.Application.Models;
using Projeto02.Presentation.Api.Authorizations;

namespace Projeto02.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //atributos
        private readonly ILoginApplicationService loginApplicationService;
        private readonly JwtToken jwtToken;

        //construtor para injeção de dependência
        public LoginController(ILoginApplicationService loginApplicationService, JwtToken jwtToken)
        {
            this.loginApplicationService = loginApplicationService;
            this.jwtToken = jwtToken;
        }

        [HttpPost]
        public IActionResult Post(LoginModel model)
        {
            try
            {
                var usuario = loginApplicationService.Get(model);
                var token = jwtToken.GenerateToken(usuario.Email);

                return Ok(new 
                { 
                    usuario,
                    token
                });
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
