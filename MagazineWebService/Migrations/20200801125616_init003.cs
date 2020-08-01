using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MagazineWebService.Migrations
{
    public partial class init003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("0d19070c-caa5-4097-af84-398635e62b78"),
                columns: new[] { "IsDeleted", "ParentId" },
                values: new object[] { false, new Guid("fe22da2e-9b47-44e4-911c-3e225ac69e76") });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("11a9dc6d-45e8-4ba0-a6f5-db294afbcf1b"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("12555e70-5bde-4b12-82fd-0584bd74aa8b"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("24c15152-ec93-4fb7-b94b-ffab71b8f64f"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("2f515dea-9a94-4a57-bcb6-2562b0ee60f5"),
                columns: new[] { "IsDeleted", "ParentId" },
                values: new object[] { false, new Guid("9edcd3e6-f364-4a06-9ce1-87fa6e057874") });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("2f6d3098-ede5-4125-b8e5-6131327b876d"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("589c4332-3207-4a99-a386-1e136f8f2535"),
                columns: new[] { "IsDeleted", "ParentId" },
                values: new object[] { false, new Guid("fe22da2e-9b47-44e4-911c-3e225ac69e76") });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("680dbcab-7a33-47ca-9fea-0b2f19ae11f6"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("794019be-ca17-4f39-bc39-ba3aeb6abbed"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("7be8a042-e4ca-499b-8068-d3af75f259e7"),
                columns: new[] { "IsDeleted", "ParentId" },
                values: new object[] { false, new Guid("680dbcab-7a33-47ca-9fea-0b2f19ae11f6") });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("7d9ee551-aec3-4b17-826c-7df954b12375"),
                columns: new[] { "IsDeleted", "ParentId" },
                values: new object[] { false, new Guid("680dbcab-7a33-47ca-9fea-0b2f19ae11f6") });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("8223eeed-3df2-4d1f-9b04-9d1ec6ad1c3d"),
                columns: new[] { "IsDeleted", "ParentId" },
                values: new object[] { false, new Guid("9edcd3e6-f364-4a06-9ce1-87fa6e057874") });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("9dccd319-4a8b-404a-9f91-fce8b279b19d"),
                columns: new[] { "IsDeleted", "ParentId" },
                values: new object[] { false, new Guid("9edcd3e6-f364-4a06-9ce1-87fa6e057874") });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("9edcd3e6-f364-4a06-9ce1-87fa6e057874"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("a338c36f-febf-454e-85ce-6ba80037272e"),
                columns: new[] { "IsDeleted", "ParentId" },
                values: new object[] { false, new Guid("fe22da2e-9b47-44e4-911c-3e225ac69e76") });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("af677486-1e9b-4526-96be-8a70fcc5788a"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("bae1e65f-4bff-4627-a39e-8807f7005c47"),
                columns: new[] { "IsDeleted", "ParentId" },
                values: new object[] { false, new Guid("9edcd3e6-f364-4a06-9ce1-87fa6e057874") });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("bd03554e-5c70-49d1-8fba-09bd326a4091"),
                columns: new[] { "IsDeleted", "ParentId" },
                values: new object[] { false, new Guid("680dbcab-7a33-47ca-9fea-0b2f19ae11f6") });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("d1de1f0c-74d7-482d-814e-c82e5693fc9c"),
                columns: new[] { "IsDeleted", "ParentId" },
                values: new object[] { false, new Guid("9edcd3e6-f364-4a06-9ce1-87fa6e057874") });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("fe22da2e-9b47-44e4-911c-3e225ac69e76"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("86c70521-b68b-4f77-88fa-a4478bca59c1"),
                columns: new[] { "IsDeleted", "Password" },
                values: new object[] { false, "ymnh8hYxYj2xlUPTywawW0/yHLLXVpbB5sJqFAswqZ+ZHdJJ" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Policies",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "PolicyRoles",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsDeleted",
                value: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("0d19070c-caa5-4097-af84-398635e62b78"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("11a9dc6d-45e8-4ba0-a6f5-db294afbcf1b"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("12555e70-5bde-4b12-82fd-0584bd74aa8b"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("24c15152-ec93-4fb7-b94b-ffab71b8f64f"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("2f515dea-9a94-4a57-bcb6-2562b0ee60f5"),
                columns: new[] { "IsDeleted", "ParentId" },
                values: new object[] { false, new Guid("9edcd3e6-f364-4a06-9ce1-87fa6e057874") });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("2f6d3098-ede5-4125-b8e5-6131327b876d"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("589c4332-3207-4a99-a386-1e136f8f2535"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("680dbcab-7a33-47ca-9fea-0b2f19ae11f6"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("794019be-ca17-4f39-bc39-ba3aeb6abbed"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("7be8a042-e4ca-499b-8068-d3af75f259e7"),
                columns: new[] { "IsDeleted", "ParentId" },
                values: new object[] { false, new Guid("680dbcab-7a33-47ca-9fea-0b2f19ae11f6") });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("7d9ee551-aec3-4b17-826c-7df954b12375"),
                columns: new[] { "IsDeleted", "ParentId" },
                values: new object[] { false, new Guid("680dbcab-7a33-47ca-9fea-0b2f19ae11f6") });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("8223eeed-3df2-4d1f-9b04-9d1ec6ad1c3d"),
                columns: new[] { "IsDeleted", "ParentId" },
                values: new object[] { false, new Guid("9edcd3e6-f364-4a06-9ce1-87fa6e057874") });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("9dccd319-4a8b-404a-9f91-fce8b279b19d"),
                columns: new[] { "IsDeleted", "ParentId" },
                values: new object[] { false, new Guid("9edcd3e6-f364-4a06-9ce1-87fa6e057874") });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("9edcd3e6-f364-4a06-9ce1-87fa6e057874"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("a338c36f-febf-454e-85ce-6ba80037272e"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("af677486-1e9b-4526-96be-8a70fcc5788a"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("bae1e65f-4bff-4627-a39e-8807f7005c47"),
                columns: new[] { "IsDeleted", "ParentId" },
                values: new object[] { false, new Guid("9edcd3e6-f364-4a06-9ce1-87fa6e057874") });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("bd03554e-5c70-49d1-8fba-09bd326a4091"),
                columns: new[] { "IsDeleted", "ParentId" },
                values: new object[] { false, new Guid("680dbcab-7a33-47ca-9fea-0b2f19ae11f6") });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("d1de1f0c-74d7-482d-814e-c82e5693fc9c"),
                columns: new[] { "IsDeleted", "ParentId" },
                values: new object[] { false, new Guid("9edcd3e6-f364-4a06-9ce1-87fa6e057874") });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: new Guid("fe22da2e-9b47-44e4-911c-3e225ac69e76"),
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("86c70521-b68b-4f77-88fa-a4478bca59c1"),
                columns: new[] { "IsDeleted", "Password" },
                values: new object[] { false, "i7w2jAWAWhBpNP1Th+CiAWI6RwacolE8R+hkO1JXAYb50RBO" });
        }
    }
}
