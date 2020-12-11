using Projeto02.Application.Commands.Tarefas;
using Projeto02.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Projeto02.Application.Interfaces
{
    public interface ITarefaApplicationService
    {
        Task Create(TarefaCreateCommand command);
        Task Update(TarefaUpdateCommand command);
        Task Delete(TarefaDeleteCommand command);

        List<TarefaDTO> GetAll(DateTime dataMin, DateTime dataMax, Guid usuarioId);
        TarefaDTO Get(Guid tarefaId, Guid usuarioId);
    }
}
