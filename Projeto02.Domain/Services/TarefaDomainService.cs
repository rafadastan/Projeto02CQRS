using Projeto02.Domain.Entities;
using Projeto02.Domain.Interfaces.Repositories;
using Projeto02.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
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
    }
}
