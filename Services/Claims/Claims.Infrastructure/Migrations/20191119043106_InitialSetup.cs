using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CTOCDE.HC.ClaimsProcessing.Services.Claims.Infrastructure.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PatientGender = table.Column<string>(nullable: true),
                    PatientAddress = table.Column<string>(nullable: true),
                    BeneficiaryName = table.Column<string>(nullable: true),
                    SubscriberId = table.Column<string>(nullable: true),
                    SubscriberName = table.Column<string>(nullable: true),
                    Relationship = table.Column<string>(nullable: true),
                    ProviderName = table.Column<string>(nullable: true),
                    TotalValue = table.Column<decimal>(nullable: false),
                    ClaimStatus = table.Column<string>(nullable: true),
                    MemberIdentifier = table.Column<string>(nullable: true),
                    CoverageTypeCode = table.Column<string>(nullable: true),
                    ClaimSubmissionDate = table.Column<string>(nullable: true),
                    ApprovedAmount = table.Column<decimal>(nullable: false),
                    DenialReason = table.Column<string>(nullable: true),
                    ProviderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClaimDetails",
                columns: table => new
                {
                    ClaimDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    ServiceStartDate = table.Column<string>(nullable: true),
                    ServiceEndDate = table.Column<string>(nullable: true),
                    DiagText = table.Column<string>(nullable: true),
                    DiagCode = table.Column<string>(nullable: true),
                    ProcCode = table.Column<string>(nullable: true),
                    ProcText = table.Column<string>(nullable: true),
                    ClaimId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimDetails", x => x.ClaimDetailId);
                    table.ForeignKey(
                        name: "FK_ClaimDetails_Claims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "Claims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClaimDetails_ClaimId",
                table: "ClaimDetails",
                column: "ClaimId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClaimDetails");

            migrationBuilder.DropTable(
                name: "Claims");
        }
    }
}
