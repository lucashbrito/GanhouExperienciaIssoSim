using GanhouExperienciaIssoSim.Repository;
using GanhouExperienciaIssoSim.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace GanhouExperienciaIssoSim.Common
{
    public static class Injection
    {
        public static void InjectAzureDepencies(this IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<IGameServices, GameServices>();
            builder.Services.AddScoped<IBetRepository, BetRepository>();
        }

        //public static void InjectWebDepencies(this WebApplicationBuilder builder)
        //{
        //    builder.Services.AddScoped<IGameServices, GameServices>();
        //    builder.Services.AddScoped<IBetRepository, BetRepository>();
        //}

        
    }
}