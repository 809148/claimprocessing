﻿// <auto-generated />
using CTOCDE.HC.ClaimsProcessing.Services.Claims.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CTOCDE.HC.ClaimsProcessing.Services.Claims.Infrastructure.Migrations
{
    [DbContext(typeof(ClaimDataContext))]
    [Migration("20191119043106_InitialSetup")]
    partial class InitialSetup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CTOCDE.HC.ClaimsProcessing.Services.Claims.Domain.Aggregates.ClaimAggregate.Claim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("ApprovedAmount");

                    b.Property<string>("BeneficiaryName");

                    b.Property<string>("ClaimStatus");

                    b.Property<string>("ClaimSubmissionDate");

                    b.Property<string>("CoverageTypeCode");

                    b.Property<string>("DenialReason");

                    b.Property<string>("MemberIdentifier");

                    b.Property<string>("Name");

                    b.Property<string>("PatientAddress");

                    b.Property<string>("PatientGender");

                    b.Property<int>("ProviderId");

                    b.Property<string>("ProviderName");

                    b.Property<string>("Relationship");

                    b.Property<string>("SubscriberId");

                    b.Property<string>("SubscriberName");

                    b.Property<decimal>("TotalValue");

                    b.HasKey("Id");

                    b.ToTable("Claims");
                });

            modelBuilder.Entity("CTOCDE.HC.ClaimsProcessing.Services.Claims.Domain.Aggregates.ClaimAggregate.ClaimDetail", b =>
                {
                    b.Property<int>("ClaimDetailId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClaimId");

                    b.Property<string>("Code");

                    b.Property<string>("DiagCode");

                    b.Property<string>("DiagText");

                    b.Property<string>("ProcCode");

                    b.Property<string>("ProcText");

                    b.Property<int>("Quantity");

                    b.Property<string>("ServiceEndDate");

                    b.Property<string>("ServiceStartDate");

                    b.Property<decimal>("UnitPrice");

                    b.Property<decimal>("Value");

                    b.HasKey("ClaimDetailId");

                    b.HasIndex("ClaimId");

                    b.ToTable("ClaimDetails");
                });

            modelBuilder.Entity("CTOCDE.HC.ClaimsProcessing.Services.Claims.Domain.Aggregates.ClaimAggregate.ClaimDetail", b =>
                {
                    b.HasOne("CTOCDE.HC.ClaimsProcessing.Services.Claims.Domain.Aggregates.ClaimAggregate.Claim", "Claim")
                        .WithMany("Details")
                        .HasForeignKey("ClaimId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
