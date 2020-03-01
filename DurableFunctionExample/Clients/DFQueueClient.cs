using System;
using System.Threading.Tasks;
using DurableFunctionExample.Activities;
using DurableFunctionExample.Orchestrators;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Extensions.Logging;

namespace DurableFunctionExample
{
    public static class DFQueueClient
    {
        [FunctionName(nameof(DFQueueClient))]
        public static async Task Run([
            QueueTrigger("example-queue", Connection = "DurableFunctionQueue")]string queueMessge,
            [DurableClient] IDurableOrchestrationClient starter,
            ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {queueMessge}");
            await starter.StartNewAsync<string>(nameof(DFQueueOrchestrator), queueMessge);
        }
    }
}
