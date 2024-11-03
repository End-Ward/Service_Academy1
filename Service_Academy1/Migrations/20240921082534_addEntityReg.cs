using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServiceAcademy.Migrations
{
    /// <inheritdoc />
    public partial class addEntityReg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b88d0586-88c8-4efe-bb77-fd0cb56ba11f", "2c929ecd-f2a6-423f-9cc3-a6a89508a160" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2afc6252-78d8-4585-a775-2ebe989714f1", "55e9750f-1fb8-4688-bc26-4f3ca2922cb1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "139df910-505b-4595-9992-5d9389fb9712", "9de411fb-616c-4968-aaa8-0734dd1e314a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "139df910-505b-4595-9992-5d9389fb9712");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2afc6252-78d8-4585-a775-2ebe989714f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b88d0586-88c8-4efe-bb77-fd0cb56ba11f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2c929ecd-f2a6-423f-9cc3-a6a89508a160");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55e9750f-1fb8-4688-bc26-4f3ca2922cb1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9de411fb-616c-4968-aaa8-0734dd1e314a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0af77e6c-9450-45ed-a66d-679e4665202c", null, "Instructor", "INSTRUCTOR" },
                    { "702dd1bf-50d7-4432-b044-0d1b2cc6b5c9", null, "Admin", "ADMIN" },
                    { "d698ac81-f8ba-415d-b067-2fe75f98221e", null, "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "19577116-977b-43f7-a198-3dfe983902cd", 0, "82bc1847-f476-4cf0-8ced-1b4a42dbed9f", "instructor@lms.com", true, "Instructor User", false, null, "INSTRUCTOR@LMS.COM", "INSTRUCTOR@LMS.COM", "AQAAAAIAAYagAAAAEGuZ3ZMCyj+RjomvpJkRDO8Xln4bqnPkO94X0zgg291WGWpGRGadiQfQPq6SiVLIlA==", null, false, "Instructor", "dfda5bdc-3a57-47b9-a92a-89956b4c6c3e", false, "instructor@lms.com" },
                    { "5d847d9f-8a15-476d-82b6-56fc2a59262a", 0, "559d7a83-4c16-4a34-965c-7141b1e0e5d4", "admin@lms.com", true, "Admin User", false, null, "ADMIN@LMS.COM", "ADMIN@LMS.COM", "AQAAAAIAAYagAAAAEIWomMTMfX+uHm0BRLn557n2mOk35MJS1Fu/d0LO+ci+dGrOgniaDfEVx+ebEbi7GQ==", null, false, "Admin", "6968da79-265f-47f7-9c15-582a6de31eba", false, "admin@lms.com" },
                    { "73b46db4-499d-4c1a-902a-8b62d07aa633", 0, "cc9e8728-d786-4440-8af3-d68238c3789b", "student@lms.com", true, "Student User", false, null, "STUDENT@LMS.COM", "STUDENT@LMS.COM", "AQAAAAIAAYagAAAAEMWplo1oIe5dvf60E/c7GIkrmpuvfBF8ZgW8eg19zfPpbPqkHQzH6vXb8xclwW/+jw==", null, false, "Student", "89026b08-3364-4fbf-953b-42a139b5c51e", false, "student@lms.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0af77e6c-9450-45ed-a66d-679e4665202c", "19577116-977b-43f7-a198-3dfe983902cd" },
                    { "702dd1bf-50d7-4432-b044-0d1b2cc6b5c9", "5d847d9f-8a15-476d-82b6-56fc2a59262a" },
                    { "d698ac81-f8ba-415d-b067-2fe75f98221e", "73b46db4-499d-4c1a-902a-8b62d07aa633" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0af77e6c-9450-45ed-a66d-679e4665202c", "19577116-977b-43f7-a198-3dfe983902cd" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "702dd1bf-50d7-4432-b044-0d1b2cc6b5c9", "5d847d9f-8a15-476d-82b6-56fc2a59262a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d698ac81-f8ba-415d-b067-2fe75f98221e", "73b46db4-499d-4c1a-902a-8b62d07aa633" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0af77e6c-9450-45ed-a66d-679e4665202c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "702dd1bf-50d7-4432-b044-0d1b2cc6b5c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d698ac81-f8ba-415d-b067-2fe75f98221e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "19577116-977b-43f7-a198-3dfe983902cd");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5d847d9f-8a15-476d-82b6-56fc2a59262a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "73b46db4-499d-4c1a-902a-8b62d07aa633");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "139df910-505b-4595-9992-5d9389fb9712", null, "Admin", "ADMIN" },
                    { "2afc6252-78d8-4585-a775-2ebe989714f1", null, "Student", "STUDENT" },
                    { "b88d0586-88c8-4efe-bb77-fd0cb56ba11f", null, "Instructor", "INSTRUCTOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2c929ecd-f2a6-423f-9cc3-a6a89508a160", 0, "f7bc0713-471d-4fad-8d79-f7b897b6c8b0", "instructor@lms.com", true, "Instructor User", false, null, "INSTRUCTOR@LMS.COM", "INSTRUCTOR@LMS.COM", "AQAAAAIAAYagAAAAEOQbkITlHERlX/Tv8hX3cZO17wUhkKrjEUHPPfuQVNWuGxlo0fk+7COrSOK/E7lFAQ==", null, false, "Instructor", "42270b95-f2e7-4bd3-8264-6d3e88e5743a", false, "instructor@lms.com" },
                    { "55e9750f-1fb8-4688-bc26-4f3ca2922cb1", 0, "9241019c-fe1f-4abf-b2b7-8c5677bbb415", "student@lms.com", true, "Student User", false, null, "STUDENT@LMS.COM", "STUDENT@LMS.COM", "AQAAAAIAAYagAAAAEIuLsYkD36CT+OI52YqlGaHz2HZMlY2qFxSvC1qrHPNb6ubN4quR0jj8GMiOAN2F3Q==", null, false, "Student", "f888407c-88c1-4b73-97f5-1864e93bde89", false, "student@lms.com" },
                    { "9de411fb-616c-4968-aaa8-0734dd1e314a", 0, "dd7f0274-07be-4dd5-8bff-0ae7793948aa", "admin@lms.com", true, "Admin User", false, null, "ADMIN@LMS.COM", "ADMIN@LMS.COM", "AQAAAAIAAYagAAAAEMgxFjg7aq45pHwRqyKC4UXZX/xfnfQZKyNsyBf4ARVsN3nZOXnodNJ6mQYbhHaW0g==", null, false, "Admin", "6d81501b-812c-4ad6-9435-a95ee28767ea", false, "admin@lms.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "b88d0586-88c8-4efe-bb77-fd0cb56ba11f", "2c929ecd-f2a6-423f-9cc3-a6a89508a160" },
                    { "2afc6252-78d8-4585-a775-2ebe989714f1", "55e9750f-1fb8-4688-bc26-4f3ca2922cb1" },
                    { "139df910-505b-4595-9992-5d9389fb9712", "9de411fb-616c-4968-aaa8-0734dd1e314a" }
                });
        }
    }
}
