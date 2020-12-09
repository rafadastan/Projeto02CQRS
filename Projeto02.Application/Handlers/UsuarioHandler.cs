using AutoMapper;
using MediatR;
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
    public class UsuarioHandler : INotificationHandler<UsuarioNotification>
    {
        //atributo
        private readonly IUsuarioCache usuarioCache;
        private readonly IMapper mapper;

        //construtor para injeção de dependência
        public UsuarioHandler(IUsuarioCache usuarioCache, IMapper mapper)
        {
            this.usuarioCache = usuarioCache;
            this.mapper = mapper;
        }

        public Task Handle(UsuarioNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                //montar o objeto DTO que será enviado para o MongoDB
                var usuarioDTO = mapper.Map<UsuarioDTO>(notification.Usuario);

                switch(notification.Action)
                {
                    case ActionNotification.Create:
                        usuarioCache.Create(usuarioDTO);
                        break;
                }
            });
        }
    }
}
