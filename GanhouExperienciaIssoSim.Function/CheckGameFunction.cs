using GanhouExperienciaIssoSim.Function.Model;
using GanhouExperienciaIssoSim.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace GanhouExperienciaIssoSim.Function
{
    public class CheckGameFunction
    {
        public IGameServices GameServices { get; set; }

        public CheckGameFunction(IGameServices gameServices)
        {
            GameServices = gameServices;
        }

        [FunctionName("CheckGameFunction")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            var requestCheckGame = JsonConvert.DeserializeObject<RequestCheckGame>(requestBody);

            var bets = GameServices.VerifyBets(requestCheckGame.Numbers, requestCheckGame.Name);

            foreach (var bet in bets)
            {
                bet.GetFormatNumbers(!string.IsNullOrEmpty(requestCheckGame.SplitType) ? requestCheckGame.SplitType : ",");
            }

            log.LogInformation($"Numbers:{requestCheckGame.Numbers}, Name:{requestCheckGame.Name}. Total Bets{bets.Count}");

            return new OkObjectResult(new ResponseCheckGame() { Bets = bets });
        }
    }
}
