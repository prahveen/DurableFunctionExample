using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using DurableFunctionExample.Orchestrators;
using DurableFunctionExample.Dtos;
using System.IO;
using Newtonsoft.Json;

namespace DurableFunctionExample.Clients
{
    public static class DFHttpClient
    {
        [FunctionName(nameof(DFHttpClient))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            [DurableClient] IDurableOrchestrationClient starter,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            UserDto eventData = JsonConvert.DeserializeObject<UserDto>(requestBody);
            log.LogInformation($"C# HTTP trigger function processed a request. {req}");
            await starter.StartNewAsync(nameof(DFHttpOrchestrator), eventData);
            return new OkObjectResult("ok");
        }
    }
}
