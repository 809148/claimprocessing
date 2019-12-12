using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTOCDE.HC.ClaimsProcessing.Services.Payers.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using AutoMapper;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CTOCDE.HC.ClaimsProcessing.Services.Payers.Api.Infrastructure.AutofacModules;

namespace CTOCDE.HC.ClaimsProcessing.Services.Payers.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //services.
            //    AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services
              .AddCustomMvc()
              //.AddCustomDbContext(Configuration)
              .AddCustomSwagger(Configuration)
              .AddCustomMappings();
            services.AddDbContext<PayerDataContext>(ops => ops.UseMySQL(@"Server=localhost; Database=payers; Uid=user_name_1; Pwd=my-secret-pw"));
            var container = new ContainerBuilder();
            container.Populate(services);

            container.RegisterModule(new ApplicationModule()); // Configuration["ConnectionString"]));

            return new AutofacServiceProvider(container.Build());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var pathBase = Configuration["PATH_BASE"];
            if (!string.IsNullOrEmpty(pathBase))
            {
                //loggerFactory.CreateLogger<Startup>().LogDebug("Using PATH BASE '{pathBase}'", pathBase);
                app.UsePathBase(pathBase);
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger()
               .UseSwaggerUI(c =>
               {
                   c.SwaggerEndpoint($"{ (!string.IsNullOrEmpty(pathBase) ? pathBase : string.Empty) }/swagger/v1/swagger.json", "Payers.API V1");
                   //c.OAuthClientId("orderingswaggerui");
                   //c.OAuthAppName("Ordering Swagger UI");
               });
        }

       
    }
    static class CustomExtensionsMethods
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddEntityFrameworkSqlServer()
               // .AddEntityFramework
                .AddDbContext<PayerDataContext>(options =>
                {
                    //options.UseInMemoryDatabase("myPayers");
                    // options.UseSqlServer(configuration.GetConnectionString("defaultConnection"));
                    // options.UseSqlServer(configuration.GetConnectionString("azureConnection"));//ops.UseMySql(@"Server=localhost; Database=Students; Uid=user_name_1; Pwd=my-secret-pw")
                    options.UseMySQL(configuration.GetConnectionString(@"Server = localhost; Database = payers; Uid = user_name_1; Pwd = my-secret-pw"));
                    //options.UseSqlServer(configuration.GetConnectionString("localDockerConnection"));
                    //TODO: Uncomment when connecting to DB
                    //options.UseSqlServer(configuration["ConnectionString"],
                    //                     sqlServerOptionsAction: sqlOptions =>
                    //                     {
                    //                         sqlOptions.MigrationsAssembly(typeof(BenefitsContext).GetTypeInfo().Assembly.GetName().Name);
                    //                         //Configuring Connection Resiliency: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency 
                    //                         sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                    //                     });

                    // Changing default behavior when client evaluation occurs to throw. 
                    // Default in EF Core would be to log a warning when client evaluation is performed.
                    options.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
                        //Check Client vs. Server evaluation: https://docs.microsoft.com/en-us/ef/core/querying/client-eval
                    },
            ServiceLifetime.Scoped
            );

            return services;
        }
        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc(options =>
            {
                //options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                //.AddControllersAsServices();  //Injecting Controllers themselves thru DI
                //For further info see: http://docs.autofac.org/en/latest/integration/aspnetcore.html#controllers-as-services
                ;




            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            return services;
        }
        public static IServiceCollection AddCustomMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));

            return services;
        }
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "Payers HTTP API",
                    Version = "v1",
                    Description = "The Payers Service HTTP API",
                    TermsOfService = "Terms Of Service"
                });
                options.CustomSchemaIds(x => x.FullName);


            });

            return services;
        }
    }
}
