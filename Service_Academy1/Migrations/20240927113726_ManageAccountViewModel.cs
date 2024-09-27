using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServiceAcademy.Migrations
{
    /// <inheritdoc />
    public partial class ManageAccountViewModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "1d601c27-2d6a-45b7-8096-403c788e9d18", null, "Student", "STUDENT" },
                    { "25281414-cf96-4aaf-b4e6-66a6dc093aa5", null, "Instructor", "INSTRUCTOR" },
                    { "e6caaa8e-ca58-418e-9899-dfe248273767", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "215bacb7-6095-4ca3-b4b6-608724115c6a", 0, "1c4d3036-4222-4741-ba35-ec6927a5a45e", "instructor@lms.com", true, "Instructor User", false, null, "INSTRUCTOR@LMS.COM", "INSTRUCTOR@LMS.COM", "AQAAAAIAAYagAAAAEM4zICHlxNxTvsTWsHgX3Um60vHI+RzLKerWQAM0p771S1ZENMnORETt1udrj1xPIw==", null, false, "Instructor", "cd4d824c-81ee-4fc2-9100-76a73396b9f1", false, "instructor@lms.com" },
                    { "349c2611-c5c3-4c3d-9e97-017a7fbb7d57", 0, "d1ae0fbd-b0b2-47a4-b019-3ccf19f37a0c", "admin@lms.com", true, "Admin User", false, null, "ADMIN@LMS.COM", "ADMIN@LMS.COM", "AQAAAAIAAYagAAAAECSsyEOgDlWKGy5t/gx6xN5LX8uVW1hmQw6/DhCoJdzDCcINMI/oJnlGZ2lySsYyEg==", null, false, "Admin", "2c98f561-8072-4e47-94be-0dcde1f479ec", false, "admin@lms.com" },
                    { "9af57314-7a67-4488-86f0-2136c7fbe420", 0, "e3d80b73-2b9f-464d-8688-13dd06533da1", "student@lms.com", true, "Student User", false, null, "STUDENT@LMS.COM", "STUDENT@LMS.COM", "AQAAAAIAAYagAAAAELZwrglsPfUpftlGDfVB8kf19/GVZkDFaOXtI/pE4Caa3EdK48jlYP8dxOR3V6IYFg==", null, false, "Student", "6a0bd797-ca6c-439f-a6af-107777e3f295", false, "student@lms.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "25281414-cf96-4aaf-b4e6-66a6dc093aa5", "215bacb7-6095-4ca3-b4b6-608724115c6a" },
                    { "e6caaa8e-ca58-418e-9899-dfe248273767", "349c2611-c5c3-4c3d-9e97-017a7fbb7d57" },
                    { "1d601c27-2d6a-45b7-8096-403c788e9d18", "9af57314-7a67-4488-86f0-2136c7fbe420" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "25281414-cf96-4aaf-b4e6-66a6dc093aa5", "215bacb7-6095-4ca3-b4b6-608724115c6a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e6caaa8e-ca58-418e-9899-dfe248273767", "349c2611-c5c3-4c3d-9e97-017a7fbb7d57" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1d601c27-2d6a-45b7-8096-403c788e9d18", "9af57314-7a67-4488-86f0-2136c7fbe420" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d601c27-2d6a-45b7-8096-403c788e9d18");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25281414-cf96-4aaf-b4e6-66a6dc093aa5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6caaa8e-ca58-418e-9899-dfe248273767");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "215bacb7-6095-4ca3-b4b6-608724115c6a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "349c2611-c5c3-4c3d-9e97-017a7fbb7d57");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9af57314-7a67-4488-86f0-2136c7fbe420");

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
    }
}
