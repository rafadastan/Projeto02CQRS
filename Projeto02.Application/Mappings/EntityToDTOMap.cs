using AutoMapper;
using Projeto02.Domain.DTOs;
using Projeto02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto02.Application.Mappings
{
    public class EntityToDTOMap : Profile
    {
        //construtor -> ctor + 2x[tab]
        public EntityToDTOMap()
        {
            CreateMap<UsuarioEntity, UsuarioDTO>();
        }
    }
}
