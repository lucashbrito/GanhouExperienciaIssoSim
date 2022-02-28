using GanhouExperienciaIssoSim.Common;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;

[assembly: FunctionsStartup(typeof(GanhouExperienciaIssoSim.Function.Startup))]
namespace GanhouExperienciaIssoSim.Function
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.InjectAzureDepencies();

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
