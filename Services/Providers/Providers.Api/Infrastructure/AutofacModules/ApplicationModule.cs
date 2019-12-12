using Autofac;
using CTOCDE.HC.ClaimsProcessing.Services.Providers.Infrastructure.Repositories;
using CTOCDE.HC.ClaimsProcessing.Services.Providers.Domain.Aggregates.BenefitAggregate;

namespace CTOCDE.HC.ClaimsProcessing.Services.Providers.Api.Infrastructure.AutofacModules
{
    public class ApplicationModule: Autofac.Module
    {
        public ApplicationModule(){}

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProviderRepository>()
                .As<IProviderRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
