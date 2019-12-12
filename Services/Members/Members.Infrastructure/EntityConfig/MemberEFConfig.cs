using CTOCDE.HC.ClaimsProcessing.Services.Members.Domain.Aggregates.MemberAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CTOCDE.HC.ClaimsProcessing.Services.Members.Infrastructure.EntityConfig
{
    public class MemberEFConfig : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> ProviderConfiguration)
        {
            ProviderConfiguration.ToTable(MemberDataContext.DEFAULT_SCHEMA);
            ProviderConfiguration.HasKey(b => b.Id);
        }
    }
}
