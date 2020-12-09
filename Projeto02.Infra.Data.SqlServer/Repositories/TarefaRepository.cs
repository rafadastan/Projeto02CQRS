using Projeto02.Domain.Entities;
using Projeto02.Domain.Interfaces.Repositories;
using Projeto02.Infra.Data.SqlServer.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto02.Infra.Data.SqlServer.Repositories
{
    public class TarefaRepository : BaseRepository<TarefaEntity>, ITarefaRepository
    {
        private readonly SqlServerContext sqlContext;

        public TarefaRepository(SqlServerContext sqlContext)
            : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }
    }
}
