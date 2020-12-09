using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto02.Application.Commands.Usuarios;
using Projeto02.Application.Interfaces;

namespace Projeto02.Presentation.Api.Controllers
{
    [EnableCors("DefaultCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioApplicationService usuarioApplicationService;

        public UsuariosController(IUsuarioApplicationService usuarioApplicationService)
        {
            this.usuarioApplicationService = usuarioApplicationService;
        }

        [HttpPost]
        [ProducesResponseType(201)] //criado
        [ProducesResponseType(400)] //requisição inválida
        [ProducesResponseType(500)] //erro interno de servidor
        public async Task<IActionResult> Post(UsuarioCreateCommand command)
        {
            try
            {
                await usuarioApplicationService.Create(command);

                return StatusCode(201, new
                {
                    message = "Usuário cadastrado com sucesso."
                });
            }
            catch(Exception e)
            {
                return StatusCode(500, new
                {
                    e.Message
                });
            }
        }
    }
}
