using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServiceAcademy.Migrations
{
    /// <inheritdoc />
    public partial class AddProgramsPull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "91c06316-da62-47bb-90a0-da914ee692a7", "653a1ce8-11fa-4a30-a1f3-a0a227478029" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "164358e0-6909-4376-9cea-8d18f75ddcfc", "b9c4bf84-a325-41f2-9b4b-46aa02644a0e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "55161bc9-3a3c-4665-a9d0-5f646edb7b96", "d2b5b204-d6dc-4a5b-8bd4-396b6c8f456e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "164358e0-6909-4376-9cea-8d18f75ddcfc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55161bc9-3a3c-4665-a9d0-5f646edb7b96");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91c06316-da62-47bb-90a0-da914ee692a7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "653a1ce8-11fa-4a30-a1f3-a0a227478029");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b9c4bf84-a325-41f2-9b4b-46aa02644a0e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d2b5b204-d6dc-4a5b-8bd4-396b6c8f456e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "40c527f4-afe8-49c1-8824-ecb1a11a9d6c", null, "Instructor", "INSTRUCTOR" },
                    { "87d8e539-b2b8-4d93-930f-502b321d9c32", null, "Admin", "ADMIN" },
                    { "a678c125-c8cd-43b2-9aaf-724d0384a659", null, "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3057b98c-ca84-464c-aef7-edb6eff9b5a8", 0, "4ca3068f-fbee-4315-a56e-23e59f608c6f", "instructor@lms.com", true, "Instructor User", false, null, "INSTRUCTOR@LMS.COM", "INSTRUCTOR@LMS.COM", "AQAAAAIAAYagAAAAEKOacZUfm+b6KUVSBqrOu8xMd/1iMWR4FEeRTAVf5aaVyugYa5V7M9dwvUY4yJmfkQ==", null, false, "8287f60e-4ae9-462a-b1e3-cd52feacf946", false, "instructor@lms.com" },
                    { "6808758f-e040-4d1c-9542-8a05bbf8509b", 0, "39e33557-ae42-47fb-9f21-9fb0ab11c28e", "admin@lms.com", true, "Admin User", false, null, "ADMIN@LMS.COM", "ADMIN@LMS.COM", "AQAAAAIAAYagAAAAENyMDn8IFmCTPmImV1aadzoHLYObNS09KGcDAZCaZRVkj9H873KLXRtOZB8+xUbniQ==", null, false, "669fad4a-1a25-4200-8d8a-ca36b897e510", false, "admin@lms.com" },
                    { "853c9947-f813-4687-9918-84fb03932719", 0, "8d157455-58b9-4711-a776-ad4ef91a4424", "student@lms.com", true, "Student User", false, null, "STUDENT@LMS.COM", "STUDENT@LMS.COM", "AQAAAAIAAYagAAAAEN/TxGTKOEI4o8pSWlTMhLf19sJOGmePY9ZhX1vMEZXYa9R4qRNJHDHo8Ttq/JiA0Q==", null, false, "73f2d691-4d12-4003-bc02-a11f1b5cd130", false, "student@lms.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "40c527f4-afe8-49c1-8824-ecb1a11a9d6c", "3057b98c-ca84-464c-aef7-edb6eff9b5a8" },
                    { "87d8e539-b2b8-4d93-930f-502b321d9c32", "6808758f-e040-4d1c-9542-8a05bbf8509b" },
                    { "a678c125-c8cd-43b2-9aaf-724d0384a659", "853c9947-f813-4687-9918-84fb03932719" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "40c527f4-afe8-49c1-8824-ecb1a11a9d6c", "3057b98c-ca84-464c-aef7-edb6eff9b5a8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "87d8e539-b2b8-4d93-930f-502b321d9c32", "6808758f-e040-4d1c-9542-8a05bbf8509b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a678c125-c8cd-43b2-9aaf-724d0384a659", "853c9947-f813-4687-9918-84fb03932719" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40c527f4-afe8-49c1-8824-ecb1a11a9d6c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87d8e539-b2b8-4d93-930f-502b321d9c32");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a678c125-c8cd-43b2-9aaf-724d0384a659");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3057b98c-ca84-464c-aef7-edb6eff9b5a8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6808758f-e040-4d1c-9542-8a05bbf8509b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "853c9947-f813-4687-9918-84fb03932719");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "164358e0-6909-4376-9cea-8d18f75ddcfc", null, "Instructor", "INSTRUCTOR" },
                    { "55161bc9-3a3c-4665-a9d0-5f646edb7b96", null, "Admin", "ADMIN" },
                    { "91c06316-da62-47bb-90a0-da914ee692a7", null, "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "653a1ce8-11fa-4a30-a1f3-a0a227478029", 0, "4482bb6b-f90b-48c7-bd9c-206238aa7856", "student@lms.com", true, "Student User", false, null, "STUDENT@LMS.COM", "STUDENT@LMS.COM", "AQAAAAIAAYagAAAAEOZyhW914JZT/4YRiwVBE56Ppj1KjTvIJI9uGSvky4Mc1CCJaEEZzfxMWyBp6J+2dQ==", null, false, "45efc3d5-f7b6-48f5-9cab-02339e856ba6", false, "student@lms.com" },
                    { "b9c4bf84-a325-41f2-9b4b-46aa02644a0e", 0, "4f4ad1b6-0524-42b3-852e-22e6d87316ce", "instructor@lms.com", true, "Instructor User", false, null, "INSTRUCTOR@LMS.COM", "INSTRUCTOR@LMS.COM", "AQAAAAIAAYagAAAAEJ1xUqPXw6YkH7ZAM1vaFXimq//rz+6cQ4gaTqVivsDzHMStZ1K+vloTbbgGMUtJgw==", null, false, "50f8628b-099f-457b-99cd-fbe1e3d5c460", false, "instructor@lms.com" },
                    { "d2b5b204-d6dc-4a5b-8bd4-396b6c8f456e", 0, "2bf41183-0923-48ec-b3b0-d11bd51a309c", "admin@lms.com", true, "Admin User", false, null, "ADMIN@LMS.COM", "ADMIN@LMS.COM", "AQAAAAIAAYagAAAAEMQ4t/ReiRwmVT6iCXqtoB97mQ3kVSyzKSu4TEw2clh1egJ2opUMa4j0EhlylnruVA==", null, false, "8d603c2a-c778-4481-92e7-30cbd5915f75", false, "admin@lms.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "91c06316-da62-47bb-90a0-da914ee692a7", "653a1ce8-11fa-4a30-a1f3-a0a227478029" },
                    { "164358e0-6909-4376-9cea-8d18f75ddcfc", "b9c4bf84-a325-41f2-9b4b-46aa02644a0e" },
                    { "55161bc9-3a3c-4665-a9d0-5f646edb7b96", "d2b5b204-d6dc-4a5b-8bd4-396b6c8f456e" }
                });
        }
    }
}
