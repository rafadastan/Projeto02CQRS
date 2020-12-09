using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto02.Presentation.Api.Configurations
{
    public class CorsConfiguration
    {
        public static void AddCors(IServiceCollection services)
        {
            services.AddCors(
                s => s.AddPolicy("DefaultCors", builder => 
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                })
                );
        }

        public static void UseCors(IApplicationBuilder app)
        {
            app.UseCors("DefaultCors");
        }
    }
}
