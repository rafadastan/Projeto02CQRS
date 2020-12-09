using AutoMapper;
using MediatR;
using Projeto02.Application.Commands.Usuarios;
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
    public class UsuarioRequestHandler : IRequestHandler<UsuarioCreateCommand>
    {
        //atributos
        private readonly IMediator mediator;        
        private readonly IUsuarioDomainService usuarioDomainService;
        private readonly IMapper mapper;

        //construtor para injeção de dependência..
        public UsuarioRequestHandler(IMediator mediator, IUsuarioDomainService usuarioDomainService, IMapper mapper)
        {
            this.mediator = mediator;
            this.usuarioDomainService = usuarioDomainService;
            this.mapper = mapper;
        }

        //método que será executado para cadastrar um usuario no CQRS
        public async Task<Unit> Handle(UsuarioCreateCommand request, CancellationToken cancellationToken)
        {
            var usuarioEntity = mapper.Map<UsuarioEntity>(request);

            //gravando no dominio (sqlserver)
            usuarioDomainService.Create(usuarioEntity);

            //gravando no mongodb
            await mediator.Publish(new UsuarioNotification {
                Usuario = usuarioEntity,
                Action = ActionNotification.Create
            });

            return Unit.Value;
        }
    }
}
