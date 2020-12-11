using Projeto02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto02.Domain.Interfaces.Services
{
    public interface ITarefaDomainService : IBaseDomainService<TarefaEntity>
    {
        List<TarefaEntity> GetByDatas(DateTime dataMin, DateTime dataMax, Guid usuarioId);
        TarefaEntity Get(Guid tarefaId, Guid usuarioId);
    }
}
