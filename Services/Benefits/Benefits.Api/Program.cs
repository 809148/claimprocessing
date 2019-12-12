using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CTOCDE.HC.ClaimsProcessing.Services.Benefits.Infrastructure;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using CTOCDE.HC.ClaimsProcessing.Services.Benefits.Api.Infrastructure;

namespace CTOCDE.HC.ClaimsProcessing.Services.Benefits.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = CreateWebHostBuilder(args).Build();

            //TODO: Uncomment when using DB
            /*
            host.MigrateDbContext<BenefitDataContext>((context, services) =>
            {

                var env = services.GetService<IHostingEnvironment>();
                //var settings = services.GetService<IOptions<OrderingSettings>>();
                //var logger = services.GetService<ILogger<OrderingContextSeed>>();

                new BenefitContextSeed()
                    .SeedAsync(context, env)
                    .Wait();
            });
            */

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
