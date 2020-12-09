using Projeto02.Application.Models;
using Projeto02.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto02.Application.Interfaces
{
    public interface ILoginApplicationService
    {
        UsuarioDTO Get(LoginModel model);
    }
}
