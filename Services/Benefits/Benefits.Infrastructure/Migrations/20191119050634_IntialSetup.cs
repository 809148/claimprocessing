using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CTOCDE.HC.ClaimsProcessing.Services.Benefits.Infrastructure.Migrations
{
    public partial class IntialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "schedules");

            migrationBuilder.CreateTable(
                name: "CoverageType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverageType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CoPayPercent = table.Column<decimal>(nullable: false),
                    CoverageType = table.Column<string>(nullable: true),
                    DeductiblePercent = table.Column<decimal>(nullable: false),
                    EffectiveStartDate = table.Column<string>(nullable: true),
                    EffectiveEndDate = table.Column<string>(nullable: true),
                    CoverageTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plan_CoverageType_CoverageTypeId",
                        column: x => x.CoverageTypeId,
                        principalTable: "CoverageType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ServiceCode = table.Column<string>(nullable: true),
                    ServiceName = table.Column<string>(nullable: true),
                    PlanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanDetail_Plan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Benefits",
                schema: "schedules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubscriberId = table.Column<string>(nullable: true),
                    MemberId = table.Column<string>(nullable: true),
                    DateOfService = table.Column<string>(nullable: true),
                    EligStatus = table.Column<string>(nullable: true),
                    CoverageTypeId = table.Column<int>(nullable: false),
                    PlanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benefits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Benefits_CoverageType_CoverageTypeId",
                        column: x => x.CoverageTypeId,
                        principalTable: "CoverageType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Benefits_Plan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plan_CoverageTypeId",
                table: "Plan",
                column: "CoverageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanDetail_PlanId",
                table: "PlanDetail",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Benefits_CoverageTypeId",
                schema: "schedules",
                table: "Benefits",
                column: "CoverageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Benefits_PlanId",
                schema: "schedules",
                table: "Benefits",
                column: "PlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanDetail");

            migrationBuilder.DropTable(
                name: "Benefits",
                schema: "schedules");

            migrationBuilder.DropTable(
                name: "Plan");

            migrationBuilder.DropTable(
                name: "CoverageType");
        }
    }
}
