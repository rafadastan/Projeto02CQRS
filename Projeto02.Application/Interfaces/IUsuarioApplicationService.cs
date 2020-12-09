using Projeto02.Application.Commands.Usuarios;
using Projeto02.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Projeto02.Application.Interfaces
{
    public interface IUsuarioApplicationService
    {
        Task Create(UsuarioCreateCommand command);
    }
}
