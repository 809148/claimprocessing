using CTOCDE.HC.ClaimsProcessing.Services.Payers.Domain.Aggregates.PayerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTOCDE.HC.ClaimsProcessing.Services.Payers.Infrastructure.EntityConfig
{
    public class PayerEFConfig : IEntityTypeConfiguration<Payer>
    {
        public void Configure(EntityTypeBuilder<Payer> PayerConfiguration)
        {
            PayerConfiguration.ToTable("Payers", PayerDataContext.DEFAULT_SCHEMA);

            PayerConfiguration.HasKey(b => b.Id);
        }
    }
}
