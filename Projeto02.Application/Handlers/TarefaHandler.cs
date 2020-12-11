using AutoMapper;
using Projeto02.Application.Notifications;
using Projeto02.Domain.DTOs;
using Projeto02.Domain.Interfaces.Caches;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto02.Application.Handlers
{
    public class TarefaHandler
    {
        //atributo
        private readonly ITarefaCache tarefaCache;
        private readonly IMapper mapper;

        //construtor para injeção de dependência
        public TarefaHandler(ITarefaCache tarefaCache, IMapper mapper)
        {
            this.tarefaCache = tarefaCache;
            this.mapper = mapper;
        }

        public Task Handle(TarefaNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                //montar o objeto DTO que será enviado para o MongoDB
                var tarefaDTO = mapper.Map<TarefaDTO>(notification.Tarefa);

                switch (notification.Action)
                {
                    case ActionNotification.Create:
                        tarefaCache.Create(tarefaDTO);
                        break;

                    case ActionNotification.Update:
                        tarefaCache.Update(tarefaDTO);
                        break;

                    case ActionNotification.Delete:
                        tarefaCache.Delete(tarefaDTO);
                        break;
                }
            });
        }
    }
}
