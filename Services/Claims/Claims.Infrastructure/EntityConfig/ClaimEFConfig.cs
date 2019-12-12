using CTOCDE.HC.ClaimsProcessing.Services.Claims.Domain.Aggregates.ClaimAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTOCDE.HC.ClaimsProcessing.Services.Claims.Infrastructure.EntityConfig
{
    public class ClaimEFConfig: IEntityTypeConfiguration<Claim>
    {
        public void Configure(EntityTypeBuilder<Claim> ClaimConfiguration)
        {
            ClaimConfiguration.ToTable(ClaimDataContext.DEFAULT_SCHEMA);
            ClaimConfiguration.HasKey(b => b.Id);
        }
    }
}
