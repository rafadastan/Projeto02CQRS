using AutoMapper;
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
            CreateMap<UsuarioCreateCommand, UsuarioEntity>()
                .AfterMap(
                    (src, dest) =>
                    {
                        dest.Id = Guid.NewGuid();
                        dest.DataCriacao = DateTime.Now;
                    }
                );
        }
    }
}
