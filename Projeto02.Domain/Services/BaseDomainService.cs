using Projeto02.Domain.Interfaces.Repositories;
using Projeto02.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto02.Domain.Services
{
    public abstract class BaseDomainService<TEntity> : IBaseDomainService<TEntity>
        where TEntity : class
    {
        //atributo..
        private readonly IBaseRepository<TEntity> baseRepository;

        //construtor para injeção de dependência..
        protected BaseDomainService(IBaseRepository<TEntity> baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public virtual void Create(TEntity entity)
        {
            baseRepository.Create(entity);
        }

        public virtual void Update(TEntity entity)
        {
            baseRepository.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            baseRepository.Delete(entity);
        }

        public virtual List<TEntity> GetAll()
        {
            return baseRepository.GetAll();
        }

        public virtual TEntity GetById(Guid id)
        {
            return baseRepository.GetById(id);
        }

        public virtual void Dispose()
        {
            baseRepository.Dispose();
        }
    }
}
