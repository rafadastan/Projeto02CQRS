using AutoMapper;
using Projeto02.Application.Commands.Tarefas;
using Projeto02.Application.Commands.Usuarios;
using Projeto02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto02.Application.Mappings
{
    public class CommandToEntityMap : Profile
    {
        //ctor + 2x[tab]
        public CommandToEntityMap()
        {
            #region Usuarios

            CreateMap<UsuarioCreateCommand, UsuarioEntity>()
                .AfterMap(
                    (src, dest) =>
                    {
                        dest.Id = Guid.NewGuid();
                        dest.DataCriacao = DateTime.Now;
                    }
                );

            #endregion

            #region Tarefas

            CreateMap<TarefaCreateCommand, TarefaEntity>()
                .AfterMap(
                    (src, dest) =>
                    {
                        dest.Id = Guid.NewGuid();
                    }
                );

            CreateMap<TarefaUpdateCommand, TarefaEntity>();

            #endregion
        }
    }
}
