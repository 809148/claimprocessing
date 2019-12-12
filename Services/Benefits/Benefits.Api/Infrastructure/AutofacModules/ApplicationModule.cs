using Autofac;
using CTOCDE.HC.ClaimsProcessing.Services.Benefits.Domain.Aggregates.BenefitAggregate;
using CTOCDE.HC.ClaimsProcessing.Services.Benefits.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTOCDE.HC.ClaimsProcessing.Services.Benefits.Api.Infrastructure.AutofacModules
{
    public class ApplicationModule
         : Autofac.Module
    {


        public ApplicationModule()
        {
           

        }

        protected override void Load(ContainerBuilder builder)
        {

          
            builder.RegisterType<BenefitRepository>()
                .As<IBenefitRepository>()
                .InstancePerLifetimeScope();

           



           
        }
    }
}
