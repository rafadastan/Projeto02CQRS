using Microsoft.EntityFrameworkCore.Storage;
using Projeto02.Domain.Interfaces.Repositories;
using Projeto02.Infra.Data.SqlServer.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto02.Infra.Data.SqlServer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqlServerContext sqlContext;
        private IDbContextTransaction transaction;

        public UnitOfWork(SqlServerContext sqlContext)
        {
            this.sqlContext = sqlContext;
        }

        public ITarefaRepository TarefaRepository
            => new TarefaRepository(sqlContext);

        public IUsuarioRepository UsuarioRepository
            => new UsuarioRepository(sqlContext);

        public void BeginTransaction()
        {
            transaction = sqlContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public void Dispose()
        {
            sqlContext.Dispose();
        }
    }
}
