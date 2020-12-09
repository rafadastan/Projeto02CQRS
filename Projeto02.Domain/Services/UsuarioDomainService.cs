using Projeto02.Domain.Entities;
using Projeto02.Domain.Exceptions;
using Projeto02.Domain.Interfaces.Repositories;
using Projeto02.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto02.Domain.Services
{
    public class UsuarioDomainService : BaseDomainService<UsuarioEntity>, IUsuarioDomainService
    {
        //atributo
        private readonly IUnitOfWork unitOfWork;

        //construtor para injeção de deoendência..
        public UsuarioDomainService(IUnitOfWork unitOfWork)
            : base(unitOfWork.UsuarioRepository)
        {
            this.unitOfWork = unitOfWork;
        }

        public override void Create(UsuarioEntity entity)
        {
            #region Email deve ser unico por usuário

            if (unitOfWork.UsuarioRepository.Get(u => u.Email.Equals(entity.Email)) != null)
                throw new EmailDeveSerUnicoException(entity.Email);

            #endregion

            base.Create(entity);
        }

        public UsuarioEntity Get(string email, string senha)
        {
            return unitOfWork.UsuarioRepository
                .Get(u => u.Email.Equals(email)
                       && u.Senha.Equals(senha));
        }
    }
}
