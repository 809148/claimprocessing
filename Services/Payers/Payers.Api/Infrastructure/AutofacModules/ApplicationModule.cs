using Autofac;
using CTOCDE.HC.ClaimsProcessing.Services.Payers.Domain.Aggregates.PayerAggregate;
using CTOCDE.HC.ClaimsProcessing.Services.Payers.Infrastructure.Repositories;

namespace CTOCDE.HC.ClaimsProcessing.Services.Payers.Api.Infrastructure.AutofacModules
{
    public class ApplicationModule: Autofac.Module
    {
        public ApplicationModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PayerRepository>().As<IPayerRepository>().InstancePerLifetimeScope();
        }
    }
}
