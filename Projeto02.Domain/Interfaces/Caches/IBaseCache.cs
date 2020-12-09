using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto02.Domain.Interfaces.Caches
{
    public interface IBaseCache<T>
        where T : class
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

        List<T> GetAll();
        T GetById(Guid id);
    }
}
