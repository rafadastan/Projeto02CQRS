using MediatR;
using Projeto02.Application.Commands.Tarefas;
using Projeto02.Application.Interfaces;
using Projeto02.Domain.DTOs;
using Projeto02.Domain.Interfaces.Caches;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Projeto02.Application.Services
{
    public class TarefaApplicationService : ITarefaApplicationService
    {
        private readonly IMediator mediator;
        private readonly ITarefaCache tarefaCache;

        public TarefaApplicationService(IMediator mediator, ITarefaCache tarefaCache)
        {
            this.mediator = mediator;
            this.tarefaCache = tarefaCache;
        }

        public async Task Create(TarefaCreateCommand command)
        {
            await mediator.Send(command);
        }

        public async Task Update(TarefaUpdateCommand command)
        {
            await mediator.Send(command);
        }

        public async Task Delete(TarefaDeleteCommand command)
        {
            await mediator.Send(command);
        }

        public List<TarefaDTO> GetAll(DateTime dataMin, DateTime dataMax, Guid usuarioId)
        {
            return tarefaCache.GetByDatas(dataMin, dataMax, usuarioId);
        }

        public TarefaDTO Get(Guid tarefaId, Guid usuarioId)
        {
            return tarefaCache.Get(tarefaId, usuarioId);
        }
    }
}
