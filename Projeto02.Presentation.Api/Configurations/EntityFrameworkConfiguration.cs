using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Projeto02.Infra.Data.SqlServer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto02.Presentation.Api.Configurations
{
    public class EntityFrameworkConfiguration
    {
        public static void AddEntityFramework(IServiceCollection services, IConfiguration configuration)
        {
            //ler a connectionstring no appsettings.json
            var connectionString = configuration.GetConnectionString("Projeto02CQRS");

            //configurando a classe SqlContext do projeto Infra.Data
            services.AddDbContext<SqlServerContext>
                (options => options.UseSqlServer(connectionString));
        }
    }
}
