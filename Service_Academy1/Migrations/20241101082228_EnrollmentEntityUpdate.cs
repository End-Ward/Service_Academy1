using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Service_Academy1.Migrations
{
    /// <inheritdoc />
    public partial class EnrollmentEntityUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StatusDate",
                table: "Enrollment",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "ReasonForDenial",
                table: "Enrollment",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReasonForDenial",
                table: "Enrollment");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StatusDate",
                table: "Enrollment",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);
        }
    }
}
