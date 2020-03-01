using DurableFunctionExample.DataContext.Entity;
using DurableFunctionExample.Repository;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DurableFunctionExample.Activities
{
    class HttpActivity
    {
        public HttpActivity(IUserRepo userRepo)
        {
            this.UserRepo = userRepo;
        }

        private IUserRepo UserRepo { get; }


        [FunctionName(nameof(HttpActivity.AddUser))]
        [return: Queue("example-queue", Connection = "DurableFunctionQueue")]
        public async Task<string> AddUser([ActivityTrigger] IDurableActivityContext context)
        {
            (string Name, string Email) inputs = context.GetInput<(string, string)>();
            Console.WriteLine($"{inputs.Name}");
            var result = await this.UserRepo.Add(new User() { Name = inputs.Name, Email = inputs.Email });
            await this.UserRepo.SaveChanges();
            return result.Id.ToString();
        }
    }
}