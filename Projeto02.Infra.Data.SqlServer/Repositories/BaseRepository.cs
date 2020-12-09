using Microsoft.EntityFrameworkCore;
using Projeto02.Domain.Interfaces.Repositories;
using Projeto02.Infra.Data.SqlServer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projeto02.Infra.Data.SqlServer.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        private readonly SqlServerContext sqlContext;

        protected BaseRepository(SqlServerContext sqlContext)
        {
            this.sqlContext = sqlContext;
        }

        public virtual void Create(TEntity entity)
        {
            sqlContext.Entry(entity).State = EntityState.Added;
            sqlContext.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            sqlContext.Entry(entity).State = EntityState.Modified;
            sqlContext.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            sqlContext.Entry(entity).State = EntityState.Deleted;
            sqlContext.SaveChanges();
        }

        public virtual List<TEntity> GetAll()
        {
            return sqlContext
                .Set<TEntity>()
                .ToList();
        }

        public virtual List<TEntity> GetAll(Func<TEntity, bool> where)
        {
            return sqlContext
                .Set<TEntity>()
                .Where(where)
                .ToList();
        }

        public virtual TEntity GetById(Guid id)
        {
            return sqlContext
                .Set<TEntity>()
                .Find(id);
        }

        public virtual TEntity Get(Func<TEntity, bool> where)
        {
            return sqlContext
                .Set<TEntity>()
                .FirstOrDefault(where);
        }

        public virtual int Count()
        {
            return sqlContext
                .Set<TEntity>()
                .Count();
        }

        public virtual int Count(Func<TEntity, bool> where)
        {
            return sqlContext
                .Set<TEntity>()
                .Count(where);
        }

        public virtual void Dispose()
        {
            sqlContext.Dispose();
        }
    }
}
