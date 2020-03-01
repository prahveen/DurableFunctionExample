using DurableFunctionExample.Repository;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using System;
using System.Threading.Tasks;

namespace DurableFunctionExample.Activities
{
    class QueueActivity
    {
        public QueueActivity(IUserRepo userRepo)
        {
            this.UserRepo = userRepo;
        }

        private IUserRepo UserRepo { get; }

        [FunctionName(nameof(QueueActivity.ShowMessage))]
        public async Task ShowMessage([ActivityTrigger] IDurableActivityContext context)
        {
                int userId = context.GetInput<int>();
                var result = await this.UserRepo.Get(userId);
                Console.WriteLine($"Name = {result.Name}, Email = {result.Email}");
        }
    }
}
