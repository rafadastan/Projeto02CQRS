using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Projeto02.Infra.Data.MongoDB.Contexts;
using Projeto02.Infra.Data.MongoDB.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto02.Presentation.Api.Configurations
{
    public class MongoDBConfiguration
    {
        public static void AddMongoDBSetup(IServiceCollection services, IConfiguration configuration)
        {
            //Ler os parametros mapeados no arquivo 'appsettings.json'
            //e carregar os seus valores na classe MongoDBSettings
            var dbSettings = new MongoDBSettings();
            new ConfigureFromConfigurationOptions<MongoDBSettings>
                (configuration.GetSection("MongoDBSettings"))
                .Configure(dbSettings);

            services.AddSingleton(dbSettings);

            //criando uma injeção de dependência Singleton
            //para a classe MongoDBContext
            services.AddSingleton<MongoDbContext>();
        }
    }
}
