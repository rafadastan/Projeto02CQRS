using Projeto02.Domain.Entities;
using Projeto02.Domain.Interfaces.Repositories;
using Projeto02.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto02.Domain.Services
{
    public class TarefaDomainService : BaseDomainService<TarefaEntity>, ITarefaDomainService
    {
        //atributo
        private readonly IUnitOfWork unitOfWork;

        //construtor para injeção de dependêncoa
        public TarefaDomainService(IUnitOfWork unitOfWork)
            : base(unitOfWork.TarefaRepository)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<TarefaEntity> GetByDatas(DateTime dataMin, DateTime dataMax, Guid usuarioId)
        {
            return unitOfWork.TarefaRepository
                    .GetAll(t => t.DataInicio >= dataMin
                              && t.DataInicio <= dataMax
                              && t.UsuarioId == usuarioId)
                    .OrderByDescending(t => t.DataInicio)
                    .ToList();
        }

        public TarefaEntity Get(Guid tarefaId, Guid usuarioId)
        {
            return unitOfWork.TarefaRepository
                    .Get(t => t.Id == tarefaId
                           && t.UsuarioId == usuarioId);
        }
    }
}
