using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServiceAcademy.Migrations
{
    /// <inheritdoc />
    public partial class ProgramManagementEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                 name: "ProgramManagement",
                 columns: table => new
                 {
                     ProgramManagementId = table.Column<int>(type: "integer", nullable: false)
                         .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                     ProgramId = table.Column<string>(type: "integer", nullable: false),
                     StartDate = table.Column<string>(type: "date", nullable: false),
                     EndDate = table.Column<string>(type: "date", nullable: false),
                     IsArchived = table.Column<string>(type: "bool", nullable: false),
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_ProgramManagement", x => x.ProgramManagementId);
                 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
        name: "ProgramManagement");

        }
    }
}

