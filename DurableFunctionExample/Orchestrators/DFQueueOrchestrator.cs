using DurableFunctionExample.Activities;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DurableFunctionExample.Orchestrators
{
    class DFQueueOrchestrator
    {
        [FunctionName(nameof(DFQueueOrchestrator))]
        public static async Task Run(
           [OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            int message = context.GetInput<int>();
            await context.CallActivityAsync<string>(nameof(QueueActivity.ShowMessage), message);
        }
    }
}
