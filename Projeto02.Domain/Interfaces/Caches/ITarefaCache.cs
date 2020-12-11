using Projeto02.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto02.Domain.Interfaces.Caches
{
    public interface ITarefaCache : IBaseCache<TarefaDTO>
    {
        List<TarefaDTO> GetByDatas(DateTime dataMin, DateTime dataMax, Guid usuarioId);
        TarefaDTO Get(Guid tarefaId, Guid usuarioId);
    }
}
