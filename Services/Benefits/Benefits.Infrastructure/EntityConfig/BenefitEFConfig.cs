using CTOCDE.HC.ClaimsProcessing.Services.Benefits.Domain.Aggregates.BenefitAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTOCDE.HC.ClaimsProcessing.Services.Benefits.Infrastructure.EntityConfig
{
    class BenefitEFConfig : IEntityTypeConfiguration<Benefit>
    {
        public void Configure(EntityTypeBuilder<Benefit> BenefitConfiguration)
        {
            BenefitConfiguration.ToTable("Benefits", BenefitDataContext.DEFAULT_SCHEMA);

            BenefitConfiguration.HasKey(b => b.Id);
        }
    }
}
