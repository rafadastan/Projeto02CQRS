using Microsoft.Extensions.DependencyInjection;
using Projeto02.Application.Interfaces;
using Projeto02.Application.Services;
using Projeto02.Domain.Interfaces.Caches;
using Projeto02.Domain.Interfaces.Repositories;
using Projeto02.Domain.Interfaces.Services;
using Projeto02.Domain.Services;
using Projeto02.Infra.Data.MongoDB.Caches;
using Projeto02.Infra.Data.SqlServer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto02.Presentation.Api.Configurations
{
    public class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection(IServiceCollection services)
        {
            #region Application

            services.AddTransient<IUsuarioApplicationService, UsuarioApplicationService>();
            services.AddTransient<ILoginApplicationService, LoginApplicationService>();

            #endregion

            #region Domain

            services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
            services.AddTransient<ITarefaDomainService, TarefaDomainService>();

            #endregion

            #region InfraStructure

            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<ITarefaRepository, TarefaRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IUsuarioCache, UsuarioCache>();
            services.AddTransient<ITarefaCache, TarefaCache>();

            #endregion

        }
    }
}
