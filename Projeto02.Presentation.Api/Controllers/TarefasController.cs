using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto02.Application.Commands.Tarefas;
using Projeto02.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto02.Presentation.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaApplicationService tarefaApplicationService;

        public TarefasController(ITarefaApplicationService tarefaApplicationService)
        {
            this.tarefaApplicationService = tarefaApplicationService;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post(TarefaCreateCommand command)
        {
            try
            {
                await tarefaApplicationService.Create(command);

                return StatusCode(201, new
                {
                    message = "Tarefa cadastrada com sucesso."
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    e.Message
                });
            }
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Put(TarefaUpdateCommand command)
        {
            try
            {
                await tarefaApplicationService.Update(command);

                return StatusCode(200, new
                {
                    message = "Tarefa atualizada com sucesso."
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    e.Message
                });
            }
        }

        [HttpDelete("{tarefaId}/{usuarioId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Delete(Guid tarefaId, Guid usuarioId)
        {
            try
            {
                var command = new TarefaDeleteCommand { TarefaId = tarefaId, UsuarioId = usuarioId };

                await tarefaApplicationService.Delete(command);

                return StatusCode(200, new
                {
                    message = "Tarefa excluída com sucesso."
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    e.Message
                });
            }
        }

        [HttpGet("{dataMin}/{dataMax}/{usuarioId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult GetAll(DateTime dataMin, DateTime dataMax, Guid usuarioId)
        {
            try
            {
                var consulta = tarefaApplicationService.GetAll(dataMin, dataMax, usuarioId);

                return StatusCode(200, consulta);
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    e.Message
                });
            }
        }

        [HttpGet("{tarefaId}/{usuarioId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Get(Guid tarefaId, Guid usuarioId)
        {
            try
            {
                var item = tarefaApplicationService.Get(tarefaId, usuarioId);

                return StatusCode(200, item);
            }
            catch (Exception e)
            {
                return StatusCode(500, new
                {
                    e.Message
                });
            }
        }
    }
}
