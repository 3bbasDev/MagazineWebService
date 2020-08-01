using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MagazineWebService.Migrations
{
    public partial class init001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Number = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    SlidShow = table.Column<string>(nullable: false),
                    Views = table.Column<int>(nullable: false, defaultValue: 0),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Link = table.Column<string>(nullable: false),
                    AccreditationNumber = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    ParentId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(maxLength: 20, nullable: false),
                    Password = table.Column<string>(maxLength: 150, nullable: false),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    LastName = table.Column<string>(maxLength: 20, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    PolicyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Policies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PolicyRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PolicyId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    Add = table.Column<bool>(nullable: false),
                    Update = table.Column<bool>(nullable: false),
                    View = table.Column<bool>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PolicyRoles_Policies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PolicyRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 150, nullable: false),
                    Body = table.Column<string>(nullable: false),
                    Views = table.Column<int>(nullable: false, defaultValue: 0),
                    Rating = table.Column<string>(nullable: false),
                    Photo = table.Column<string>(nullable: false),
                    Link = table.Column<string>(nullable: false),
                    Issued = table.Column<DateTime>(nullable: false),
                    SectionId = table.Column<Guid>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Country = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Text = table.Column<string>(nullable: false),
                    Issued = table.Column<DateTime>(nullable: false),
                    PostId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Policies",
                columns: new[] { "Id", "IsDeleted", "Name", "Number" },
                values: new object[,]
                {
                    { 1, false, "ADMIN", 1000 },
                    { 2, false, "GUEST", 2000 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "User" },
                    { 2, false, "Post" },
                    { 3, false, "Comment" },
                    { 4, false, "Section" },
                    { 5, false, "Upload" }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("24c15152-ec93-4fb7-b94b-ffab71b8f64f"), false, "منوعات" },
                    { new Guid("11a9dc6d-45e8-4ba0-a6f5-db294afbcf1b"), false, "حوارات" },
                    { new Guid("794019be-ca17-4f39-bc39-ba3aeb6abbed"), false, "تحقيقات واستطلاعات" },
                    { new Guid("589c4332-3207-4a99-a386-1e136f8f2535"), false, "اقتصاد عالمي" },
                    { new Guid("0d19070c-caa5-4097-af84-398635e62b78"), false, "اقتصاد عربي" },
                    { new Guid("a338c36f-febf-454e-85ce-6ba80037272e"), false, "اقتصاد محلي" },
                    { new Guid("fe22da2e-9b47-44e4-911c-3e225ac69e76"), false, "اقتصاد" }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "IsDeleted", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("bd03554e-5c70-49d1-8fba-09bd326a4091"), false, "رياضة دولية", new Guid("680dbcab-7a33-47ca-9fea-0b2f19ae11f6") },
                    { new Guid("7be8a042-e4ca-499b-8068-d3af75f259e7"), false, "رياضة عربية", new Guid("680dbcab-7a33-47ca-9fea-0b2f19ae11f6") }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("2f6d3098-ede5-4125-b8e5-6131327b876d"), false, "ثقافة" },
                    { new Guid("680dbcab-7a33-47ca-9fea-0b2f19ae11f6"), false, "رياضة" },
                    { new Guid("af677486-1e9b-4526-96be-8a70fcc5788a"), false, "مقالات" }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "IsDeleted", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("d1de1f0c-74d7-482d-814e-c82e5693fc9c"), false, "اخبار سياسية", new Guid("9edcd3e6-f364-4a06-9ce1-87fa6e057874") },
                    { new Guid("bae1e65f-4bff-4627-a39e-8807f7005c47"), false, "اخبار امنية", new Guid("9edcd3e6-f364-4a06-9ce1-87fa6e057874") },
                    { new Guid("8223eeed-3df2-4d1f-9b04-9d1ec6ad1c3d"), false, "اخبار عربية", new Guid("9edcd3e6-f364-4a06-9ce1-87fa6e057874") },
                    { new Guid("2f515dea-9a94-4a57-bcb6-2562b0ee60f5"), false, "اخبار دولية", new Guid("9edcd3e6-f364-4a06-9ce1-87fa6e057874") },
                    { new Guid("9dccd319-4a8b-404a-9f91-fce8b279b19d"), false, "اخبار محلية", new Guid("9edcd3e6-f364-4a06-9ce1-87fa6e057874") }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[] { new Guid("9edcd3e6-f364-4a06-9ce1-87fa6e057874"), false, "الاخبار" });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "IsDeleted", "Name", "ParentId" },
                values: new object[] { new Guid("7d9ee551-aec3-4b17-826c-7df954b12375"), false, "رياضة محلية", new Guid("680dbcab-7a33-47ca-9fea-0b2f19ae11f6") });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[] { new Guid("12555e70-5bde-4b12-82fd-0584bd74aa8b"), false, "اثار ومواقع" });

            migrationBuilder.InsertData(
                table: "PolicyRoles",
                columns: new[] { "Id", "Add", "Delete", "IsDeleted", "PolicyId", "RoleId", "Update", "View" },
                values: new object[,]
                {
                    { 1, true, true, false, 1, 1, true, true },
                    { 2, true, true, false, 1, 2, true, true },
                    { 3, true, true, false, 1, 3, true, true },
                    { 4, true, true, false, 1, 4, true, true },
                    { 5, true, true, true, 1, 5, true, true }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "IsDeleted", "LastName", "Password", "PolicyId", "Username" },
                values: new object[] { new Guid("86c70521-b68b-4f77-88fa-a4478bca59c1"), "ahmed", false, "Ali", "oObu6m21rdNksIlWRG5XUoCabd8N6ER5KvF5f92QGFh/JOsk", 1, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyRoles_Id",
                table: "PolicyRoles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyRoles_PolicyId",
                table: "PolicyRoles",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyRoles_RoleId",
                table: "PolicyRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SectionId",
                table: "Posts",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PolicyId",
                table: "Users",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "PolicyRoles");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropTable(
                name: "Sections");
        }
    }
}
