using DurableFunctionExample.Activities;
using DurableFunctionExample.Dtos;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DurableFunctionExample.Orchestrators
{
    class DFHttpOrchestrator
    {
        [FunctionName(nameof(DFHttpOrchestrator))]
        public static async Task Run(
            [OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            UserDto user = context.GetInput<UserDto>();
            await context.CallActivityAsync<string>(nameof(HttpActivity.AddUser), (user.Name, user.Email));
        }
    }
}
