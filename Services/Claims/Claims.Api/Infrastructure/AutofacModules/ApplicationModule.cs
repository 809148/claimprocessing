using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using CTOCDE.HC.ClaimsProcessing.Services.Claims.Domain.Aggregates.ClaimAggregate;
using CTOCDE.HC.ClaimsProcessing.Services.Claims.Infrastructure.Repositories;

namespace CTOCDE.HC.ClaimsProcessing.Services.Claims.Claims.Api.Infrastructure.AutofacModules
{
    public class ApplicationModule: Autofac.Module
    {
        public ApplicationModule()
        {

        }

        protected override void Load(ContainerBuilder builder)
        {
           builder.RegisterType<ClaimRepository>().As<IClaimRepository>()
                  .InstancePerLifetimeScope();
        }
    }

}
