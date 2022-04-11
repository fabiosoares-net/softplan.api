using Microsoft.Extensions.DependencyInjection;
using Softplan.Projeto2.Api.Interface;
using Softplan.Projeto2.Api.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softplan.Projeto2.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IJurosService, JurosService>();
            services.AddScoped<IWebApiClientService, WebApiClientService>();
        }
    }
}
