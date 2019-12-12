using Autofac;
using CTOCDE.HC.ClaimsProcessing.Services.Members.Domain.Aggregates.MemberAggregate;
using CTOCDE.HC.ClaimsProcessing.Services.Members.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTOCDE.HC.ClaimsProcessing.Services.Members.Members.Api.Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        public ApplicationModule() { }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MemberRepository>()
                .As<IMemberRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
