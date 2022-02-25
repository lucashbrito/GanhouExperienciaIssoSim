using GanhouExperienciaIssoSim.Repository;
using GanhouExperienciaIssoSim.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
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

            var azureServiceTokenProvider = new AzureServiceTokenProvider();
            var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(
                    azureServiceTokenProvider.KeyVaultTokenCallback));

            var config = new ConfigurationBuilder()
              .AddEnvironmentVariables();

            var configuration = new ConfigurationBuilder()
             .AddEnvironmentVariables()
             .Build();

            config.AddAzureKeyVault(new AzureKeyVaultConfigurationOptions()
            {
                Client = keyVaultClient,
                Manager = new DefaultKeyVaultSecretManager(),
                Vault = configuration["Azure:KeyVault:Address"]
            });
        }
    }
}
