using Application.Services.Visitante;
using Infra.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.CrossCutting.Ioc
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Application
            services.AddScoped<IVisitanteAppService, VisitanteAppService>();

            // Infra - Data
            services.AddScoped<IContextBase, ContextBase>();
        }
    }
}