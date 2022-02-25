using GanhouExperienciaIssoSim.Repository;
using GanhouExperienciaIssoSim.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(GanhouExperienciaIssoSim.Function.Startup))]
namespace GanhouExperienciaIssoSim.Function
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<IGameServices, GameServices>();
            builder.Services.AddScoped<IBetRepository, BetRepository>();
        }
    }
}
