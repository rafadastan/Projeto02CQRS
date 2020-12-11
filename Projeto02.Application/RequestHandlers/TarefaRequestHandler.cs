using AutoMapper;
using MediatR;
using Projeto02.Application.Commands.Tarefas;
using Projeto02.Application.Notifications;
using Projeto02.Domain.Entities;
using Projeto02.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto02.Application.RequestHandlers
{
    public class TarefaRequestHandler :
        IRequestHandler<TarefaCreateCommand>,
        IRequestHandler<TarefaUpdateCommand>,
        IRequestHandler<TarefaDeleteCommand>
    {
        private readonly IMediator mediator;
        private readonly ITarefaDomainService tarefaDomainService;
        private readonly IMapper mapper;

        public TarefaRequestHandler(IMediator mediator, ITarefaDomainService tarefaDomainService, IMapper mapper)
        {
            this.mediator = mediator;
            this.tarefaDomainService = tarefaDomainService;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(TarefaCreateCommand request, CancellationToken cancellationToken)
        {
            var tarefaEntity = mapper.Map<TarefaEntity>(request);

            //gravando no dominio (sqlserver)
            tarefaDomainService.Create(tarefaEntity);

            //gravando no mongodb
            await mediator.Publish(new TarefaNotification
            {
                Tarefa = tarefaEntity,
                Action = ActionNotification.Create
            });

            return Unit.Value;
        }

        public async Task<Unit> Handle(TarefaUpdateCommand request, CancellationToken cancellationToken)
        {
            var tarefaEntity = mapper.Map<TarefaEntity>(request);

            //atualizando no dominio (sqlserver)
            tarefaDomainService.Update(tarefaEntity);

            //atualizando no mongodb
            await mediator.Publish(new TarefaNotification
            {
                Tarefa = tarefaEntity,
                Action = ActionNotification.Update
            });

            return Unit.Value;
        }

        public async Task<Unit> Handle(TarefaDeleteCommand request, CancellationToken cancellationToken)
        {
            var tarefaEntity = tarefaDomainService.Get(request.TarefaId, request.UsuarioId);

            //excluindo no dominio (sqlserver)
            tarefaDomainService.Delete(tarefaEntity);

            //excluindo no mongodb
            await mediator.Publish(new TarefaNotification
            {
                Tarefa = tarefaEntity,
                Action = ActionNotification.Delete
            });

            return Unit.Value;

        }
    }
}
