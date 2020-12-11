using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto02.Application.Commands.Tarefas
{
    public class TarefaDeleteCommand : IRequest
    {
        public Guid TarefaId { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
