using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServiceAcademy.Migrations
{
    /// <inheritdoc />
    public partial class DBchanges1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7a33a127-c3d9-444a-8b57-6eda29885ef1", null, "Instructor", "INSTRUCTOR" },
                    { "9d926e14-a09e-43d7-95a4-20559ff4705e", null, "Admin", "ADMIN" },
                    { "b9d02765-f3b1-4e82-9226-777ca2906ff5", null, "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "02de205e-cccb-4b68-a5c7-52547f8c1911", 0, "51916495-4695-4ba8-8a81-d3c71e830424", "admin@lms.com", true, "Admin User", false, null, "ADMIN@LMS.COM", "ADMIN@LMS.COM", "AQAAAAIAAYagAAAAEONT9N2fHhc5cdrSAlGoHJ28zBISazPwluXRn7A7aLfkHt1bDN/hxsPuQe+xUu4e6g==", null, false, "b269e076-ff5e-4631-811c-0638f696ad2b", false, "admin@lms.com" },
                    { "514b8c2b-5ae4-4cee-ac6f-e1fd425c4237", 0, "a2e583c5-4fbd-48fc-a269-4f3e6b6286ac", "instructor@lms.com", true, "Instructor User", false, null, "INSTRUCTOR@LMS.COM", "INSTRUCTOR@LMS.COM", "AQAAAAIAAYagAAAAEOeT3PAwzewoAPScWW580f3qdH152qkircKnNto/pUPZ2Lc8668sJWRysTy3oiz6Mw==", null, false, "8b120b64-b979-4f41-b571-aa75d577b268", false, "instructor@lms.com" },
                    { "efe3c877-925c-4821-a50d-328de7cf0439", 0, "13fec17e-7ef7-4d16-88c3-9f4543d8b6de", "student@lms.com", true, "Student User", false, null, "STUDENT@LMS.COM", "STUDENT@LMS.COM", "AQAAAAIAAYagAAAAEEB5jUSf29Mhy+IrDM8fEw7ywlwVUo/9SLSMxIl5owZ8ee2Sp8jsCe7hDP+QyRUXUw==", null, false, "e1bcebb5-a30b-47ed-a8f3-e02b1b96cf6d", false, "student@lms.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "9d926e14-a09e-43d7-95a4-20559ff4705e", "02de205e-cccb-4b68-a5c7-52547f8c1911" },
                    { "7a33a127-c3d9-444a-8b57-6eda29885ef1", "514b8c2b-5ae4-4cee-ac6f-e1fd425c4237" },
                    { "b9d02765-f3b1-4e82-9226-777ca2906ff5", "efe3c877-925c-4821-a50d-328de7cf0439" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9d926e14-a09e-43d7-95a4-20559ff4705e", "02de205e-cccb-4b68-a5c7-52547f8c1911" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7a33a127-c3d9-444a-8b57-6eda29885ef1", "514b8c2b-5ae4-4cee-ac6f-e1fd425c4237" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b9d02765-f3b1-4e82-9226-777ca2906ff5", "efe3c877-925c-4821-a50d-328de7cf0439" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a33a127-c3d9-444a-8b57-6eda29885ef1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d926e14-a09e-43d7-95a4-20559ff4705e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9d02765-f3b1-4e82-9226-777ca2906ff5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02de205e-cccb-4b68-a5c7-52547f8c1911");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "514b8c2b-5ae4-4cee-ac6f-e1fd425c4237");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "efe3c877-925c-4821-a50d-328de7cf0439");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

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
    }
}
