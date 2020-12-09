using Projeto02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto02.Domain.Interfaces.Services
{
    public interface IUsuarioDomainService : IBaseDomainService<UsuarioEntity>
    {
        UsuarioEntity Get(string email, string senha);
    }
}
