using AutoMapper;
using Projeto02.Application.Interfaces;
using Projeto02.Application.Models;
using Projeto02.Domain.DTOs;
using Projeto02.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto02.Application.Services
{
    public class LoginApplicationService : ILoginApplicationService
    {
        //atributo
        private readonly IUsuarioDomainService usuarioDomainService;
        private readonly IMapper mapper;

        //construtor para injeção de dependência
        public LoginApplicationService(IUsuarioDomainService usuarioDomainService, IMapper mapper)
        {
            this.usuarioDomainService = usuarioDomainService;
            this.mapper = mapper;
        }

        public UsuarioDTO Get(LoginModel model)
        {
            var usuario = usuarioDomainService.Get(model.Email, model.Senha);

            //verificar se o usuario não foi encontrado..
            if (usuario == null)
                throw new Exception("Usuário não encontrado.");

            //retornar os dados do UsuarioDTO
            return mapper.Map<UsuarioDTO>(usuario);
        }
    }
}
