using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Projeto02.Presentation.Api.Configurations;

namespace Projeto02.Presentation.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Setup para configura��o do Swagger
            SwaggerConfiguration.AddSwagger(services);

            //Setup para configura��o do EntityFramework
            EntityFrameworkConfiguration.AddEntityFramework(services, Configuration);

            //Setup para configura��o do JWT
            JwtConfiguration.ConfigureServices(services, Configuration);

            //Setup para o MongoDB
            MongoDBConfiguration.AddMongoDBSetup(services, Configuration);

            //Inje��o de depend�ncia
            DependencyInjectionConfiguration.AddDependencyInjection(services);

            //Setup para o MediatR
            MediatRConfiguration.AddMediatRSetup(services);

            //Setup para o AutoMapper
            AutoMapperConfiguration.AddAutoMapperSetup(services);

            //Setup para o CORS
            CorsConfiguration.AddCors(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //Setup para configura��o do CORS
            CorsConfiguration.UseCors(app);

            //Setup para configura��o do JWT
            JwtConfiguration.Configure(app);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Setup para configura��o do Swagger
            SwaggerConfiguration.UseSwagger(app);
        }
    }
}
