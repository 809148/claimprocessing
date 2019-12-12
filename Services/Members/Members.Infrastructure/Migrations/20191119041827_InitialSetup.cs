using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CTOCDE.HC.ClaimsProcessing.Services.Members.Infrastructure.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "members",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MemberIdentifier = table.Column<string>(maxLength: 10, nullable: true),
                    SubscriberId = table.Column<string>(maxLength: 10, nullable: true),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 100, nullable: true),
                    Prefix = table.Column<string>(maxLength: 10, nullable: true),
                    Suffix = table.Column<string>(maxLength: 10, nullable: true),
                    Gender = table.Column<string>(maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<string>(maxLength: 10, nullable: false),
                    MaritalStatus = table.Column<string>(maxLength: 50, nullable: false),
                    PlanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressType = table.Column<string>(maxLength: 50, nullable: false),
                    Country = table.Column<string>(maxLength: 50, nullable: false),
                    State = table.Column<string>(maxLength: 50, nullable: false),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    AddressLine1 = table.Column<string>(maxLength: 100, nullable: false),
                    AddressLine2 = table.Column<string>(maxLength: 100, nullable: true),
                    AddressLine3 = table.Column<string>(maxLength: 100, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 6, nullable: false),
                    MemberId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactType = table.Column<string>(maxLength: 10, nullable: false),
                    Value = table.Column<string>(maxLength: 50, nullable: false),
                    MemberId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlanId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    CoverageType = table.Column<string>(nullable: false),
                    CoverageTypeCode = table.Column<string>(maxLength: 50, nullable: false),
                    CoverageStartDate = table.Column<string>(maxLength: 10, nullable: false),
                    CoverageEndDate = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollments_members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_MemberId",
                table: "Addresses",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_MemberId",
                table: "Contacts",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_MemberId",
                table: "Enrollments",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "members");
        }
    }
}
