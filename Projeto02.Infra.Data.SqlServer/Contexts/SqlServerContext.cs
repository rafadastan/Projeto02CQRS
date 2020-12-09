using Microsoft.EntityFrameworkCore;
using Projeto02.Domain.Entities;
using Projeto02.Infra.Data.SqlServer.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto02.Infra.Data.SqlServer.Contexts
{
    //REGRA 1: Herdar DbContext
    public class SqlServerContext : DbContext
    {
        //REGRA 2: Construtor que possa receber os parametros
        //de configuração necessários para ativar o DbContext
        public SqlServerContext(DbContextOptions<SqlServerContext> options)
            : base(options) //construtor da superclasse
        {

        }

        //REGRA 3: Declarar uma propriedade DbSet para cada
        //entidade mapeada neste contexto de banco de dados
        public DbSet<TarefaEntity> Tarefa { get; set; }
        public DbSet<UsuarioEntity> Usuario { get; set; }

        //REGRA 4: Sobrescrever o método OnModelCreating e adicionar
        //cada classe de mapeamento criada para o banco de dados
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TarefaMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());

            #region Índices

            modelBuilder.Entity<UsuarioEntity>(entity => {
                entity.HasIndex(u => u.Email).IsUnique();
            });

            #endregion
        }
    }
}
