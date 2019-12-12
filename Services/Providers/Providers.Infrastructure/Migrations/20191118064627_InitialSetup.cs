using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CTOCDE.HC.ClaimsProcessing.Services.Providers.Infrastructure.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.EnsureSchema(
            //    name: "providers");

            migrationBuilder.CreateTable(
                name: "ProviderTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProviderTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "providers",
              //  schema: "providers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Address = table.Column<string>(maxLength: 200, nullable: false),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    State = table.Column<string>(maxLength: 50, nullable: false),
                    Country = table.Column<string>(maxLength: 50, nullable: false),
                    Zip = table.Column<int>(maxLength: 10, nullable: false),
                    RegisteredDate = table.Column<string>(maxLength: 10, nullable: false),
                    ProviderTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_providers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_providers_ProviderTypes_ProviderTypeId",
                        column: x => x.ProviderTypeId,
                        principalTable: "ProviderTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_providers_ProviderTypeId",
             //   schema: "providers",
                table: "providers",
                column: "ProviderTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "providers"
               // ,schema: "providers"
                );

            migrationBuilder.DropTable(
                name: "ProviderTypes");
        }
    }
}
