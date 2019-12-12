using CTOCDE.HC.ClaimsProcessing.Services.Providers.Domain.Aggregates.ProviderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTOCDE.HC.ClaimsProcessing.Services.Providers.Infrastructure.EntityConfig
{
    public class ProviderEFConfig: IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> ProviderConfiguration)
        {
            ProviderConfiguration.ToTable("providers");//, ProviderDataContext.DEFAULT_SCHEMA);
            ProviderConfiguration.HasKey(b => b.Id);
        }
    }
}
    
