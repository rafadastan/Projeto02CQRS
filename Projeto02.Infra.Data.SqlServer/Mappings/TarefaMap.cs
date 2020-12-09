using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto02.Infra.Data.SqlServer.Mappings
{
    public class TarefaMap : IEntityTypeConfiguration<TarefaEntity>
    {
        public void Configure(EntityTypeBuilder<TarefaEntity> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nome)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(t => t.Descricao)
               .HasMaxLength(500)
               .IsRequired();

            builder.Property(t => t.DataInicio)
               .HasColumnType("date")
               .IsRequired();

            builder.Property(t => t.HoraInicio)
               .HasColumnType("time")
               .IsRequired();

            builder.Property(t => t.DataFim)
               .HasColumnType("date")
               .IsRequired();

            builder.Property(t => t.HoraFim)
               .HasColumnType("time")
               .IsRequired();

            builder.Property(t => t.UsuarioId)
              .IsRequired();

            #region Relacionamentos

            builder.HasOne(t => t.Usuario)
                .WithMany(u => u.Tarefas)
                .HasForeignKey(t => t.UsuarioId);

            #endregion
        }
    }
}
