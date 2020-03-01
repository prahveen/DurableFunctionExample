using System;
using System.Collections.Generic;
using System.Text;
using DurableFunctionExample.DataContext;
using DurableFunctionExample.Repository;
using Microsoft.Azure.Functions.Extensions;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(DurableFunctionExample.Startup))]
namespace DurableFunctionExample
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string SqlConnection = Environment.GetEnvironmentVariable("ConnectionString");
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(SqlConnection));
            builder.Services.AddTransient<IUserRepo, UserRepo>();
        }
    }
}
