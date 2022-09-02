using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FridgeModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FridgeModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultQuantity = table.Column<int>(type: "int", nullable: false),
                    ImageSource = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fridges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FridgeModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fridges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fridges_FridgeModels_FridgeModelId",
                        column: x => x.FridgeModelId,
                        principalTable: "FridgeModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FridgeProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    FridgeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FridgeProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FridgeProducts_Fridges_FridgeId",
                        column: x => x.FridgeId,
                        principalTable: "Fridges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FridgeProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9ae38d66-790c-4aa6-b75f-8006398b58a8", "dbf1333e-1937-4936-a056-560fd6c9353e", "user", "USER" },
                    { "1508a75c-adb5-49a7-afde-99a5a09813c0", "a3536628-74a0-4f8d-850f-8dbd7df24476", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "FridgeModels",
                columns: new[] { "Id", "Name", "Year" },
                values: new object[,]
                {
                    { new Guid("91b72841-5ce0-4556-ae8d-ac6c2cb3a126"), "RSA1SHVB1", 2018 },
                    { new Guid("4079bcea-c1fc-42a5-b220-981e9b083b4d"), "SBS 7212", 2019 },
                    { new Guid("bc45989d-5ef9-4cd0-85e9-ed54701bef17"), "RF-61 K90407F", 2010 },
                    { new Guid("7158ca91-4000-4256-9182-048a8b850143"), "Electric MR-CR46G-HS-R", 2010 },
                    { new Guid("bf864c03-2f70-482e-9505-3dcfcd1a9ac8"), "VF 910 X", 2014 },
                    { new Guid("6120df35-3a32-4465-83d9-02d90769dc12"), "RB-34 K6220SS", 2018 },
                    { new Guid("5175e5fe-fcc9-4041-8043-62fc5c71fbaf"), "VF 395-1 SBS", 2010 },
                    { new Guid("b102fe85-fa02-436a-a2f9-e30fc83abd2b"), "VF 466 EB", 2014 },
                    { new Guid("770e8bf1-3c52-4e68-b441-027501583ce2"), "KGN36S55", 2018 },
                    { new Guid("d5a11ba1-f080-46f0-aaed-510972099ef3"), "514-NWE", 2010 },
                    { new Guid("5ce2abb4-6d21-4c85-8cdc-ccedff9b2dad"), "RC-54", 2013 },
                    { new Guid("63b1a8ab-1dcd-41ba-be31-b64ea07eaa9d"), "TH-803", 2016 },
                    { new Guid("ce2635aa-2f6c-4ce5-a1ba-af7c0991753e"), "DF 5180 W", 2015 },
                    { new Guid("e91340aa-0634-4c22-a7fb-7a4335f193d4"), "DS 333020", 2011 },
                    { new Guid("c78db094-fd33-4492-b3a3-0515d141c25d"), "XM 4021-000", 2010 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DefaultQuantity", "ImageSource", "Name" },
                values: new object[,]
                {
                    { new Guid("0f125d2e-d071-4119-95d7-77fc9e46e7a4"), 6, "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7b/Assorted_bread.jpg/274px-Assorted_bread.jpg", "Bread" },
                    { new Guid("e9b648d8-d1f6-4f6e-a335-4432b06838d5"), 14, "https://id-test-11.slatic.net/p/70f40d8f77f844671af4a5a11755e7ae.jpg", "Apple" },
                    { new Guid("740ccb3d-5c6e-41c8-9be9-2dc003ece707"), 8, "https://www.collinsdictionary.com/images/full/egg_110803370.jpg", "Egg" },
                    { new Guid("32e54047-db5f-43ed-afcd-43a8ab7692a8"), 16, "https://cdn.yamatoscale.com/wp-content/uploads/2016/04/K%C3%A4se-Scheiben_01_00_OH-1.jpg", "Cheese" },
                    { new Guid("5fd00212-1985-41eb-9f57-36dc7e1541f8"), 5, "https://4.imimg.com/data4/JX/UQ/ANDROID-47104262/product-500x500.jpeg", "Mashroom" },
                    { new Guid("9539614d-aec7-4747-a754-3a1375e59b3e"), 6, "https://food.fnr.sndimg.com/content/dam/images/food/fullset/2010/5/1/0/0039592F3_beer-can-chicken_s4x3.jpg.rend.hgtvcom.616.462.suffix/1382539274625.jpeg", "Chicken" },
                    { new Guid("8221e424-5e13-46cd-9b94-3824a7da5b31"), 13, "https://www.thespruceeats.com/thmb/OueG44zJ3LnwQt9HwVXmmT6mkNM=/3067x3067/smart/filters:no_upscale()/roasted-boneless-pork-loin-recipe-995289-hero-01-93314ca221a54ecebc45a17e99cb78c4.jpg", "Pork" },
                    { new Guid("d2706ca5-5a3f-47be-a3ff-735ba9d0df03"), 10, "https://hips.hearstapps.com/hmg-prod/images/delish-roast-beef-horizontal-1540505165.jpg", "Beef" },
                    { new Guid("69512c08-faa8-4c94-a259-917df81555cf"), 11, "https://www.crescentfoods.lk/images/products/PREMIUM_CHICKEN_SAUSAGES.jpg", "Sausage" },
                    { new Guid("d6662ea2-60e2-47a9-9685-eeedf476e6b1"), 13, "https://media.istockphoto.com/vectors/yogurt-cup-with-spoon-vector-id1060883416?k=20&m=1060883416&s=612x612&w=0&h=nhPJA8XYohdkGbBojLt72e_q9sbgBuO6mUI-7cnuu6s=", "Yoghurt" }
                });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "Id", "FridgeModelId", "Name", "OwnerName" },
                values: new object[,]
                {
                    { new Guid("1dd3994b-2d43-4ab7-bf0c-d71699fe45cd"), new Guid("63b1a8ab-1dcd-41ba-be31-b64ea07eaa9d"), "Philips", "Anna" },
                    { new Guid("d0a3dc0a-db1f-4672-b92e-9318aece6e68"), new Guid("770e8bf1-3c52-4e68-b441-027501583ce2"), "Vestfrost", "Vlada" },
                    { new Guid("77fb7ae5-14cc-44c2-9c42-98a10323fc3d"), new Guid("6120df35-3a32-4465-83d9-02d90769dc12"), "Indesit", "Vlada" },
                    { new Guid("85d19b94-a402-4374-9c93-71d58533e6fc"), new Guid("7158ca91-4000-4256-9182-048a8b850143"), "Beko", "Anna" },
                    { new Guid("588a11f6-14d3-4613-ac3f-f03690105d72"), new Guid("91b72841-5ce0-4556-ae8d-ac6c2cb3a126"), "Bosch", "Anna" }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("acfc1ae6-5edb-4fe1-b90a-ee3a526bd1bb"), new Guid("1dd3994b-2d43-4ab7-bf0c-d71699fe45cd"), new Guid("e9b648d8-d1f6-4f6e-a335-4432b06838d5"), 22 },
                    { new Guid("69046c3e-7b03-4722-bad9-1c697a28933e"), new Guid("588a11f6-14d3-4613-ac3f-f03690105d72"), new Guid("5fd00212-1985-41eb-9f57-36dc7e1541f8"), 13 },
                    { new Guid("d7600561-b48a-4a2d-a1f1-e30bbdc0a1c6"), new Guid("588a11f6-14d3-4613-ac3f-f03690105d72"), new Guid("69512c08-faa8-4c94-a259-917df81555cf"), 17 },
                    { new Guid("893c0c20-ef0d-48c3-87ef-bfbc0394984c"), new Guid("588a11f6-14d3-4613-ac3f-f03690105d72"), new Guid("e9b648d8-d1f6-4f6e-a335-4432b06838d5"), 0 },
                    { new Guid("1c89abbb-7ccc-430d-9d24-1d94f8c374b1"), new Guid("588a11f6-14d3-4613-ac3f-f03690105d72"), new Guid("d6662ea2-60e2-47a9-9685-eeedf476e6b1"), 3 },
                    { new Guid("4bfe180a-be37-4efa-99b9-2766a5c9f74f"), new Guid("588a11f6-14d3-4613-ac3f-f03690105d72"), new Guid("740ccb3d-5c6e-41c8-9be9-2dc003ece707"), 11 },
                    { new Guid("7f08ce39-bc75-49ef-8dc9-c2dd8df3be2f"), new Guid("85d19b94-a402-4374-9c93-71d58533e6fc"), new Guid("d2706ca5-5a3f-47be-a3ff-735ba9d0df03"), 11 },
                    { new Guid("ddb68e55-4ad8-4133-9575-08dc486bae83"), new Guid("85d19b94-a402-4374-9c93-71d58533e6fc"), new Guid("5fd00212-1985-41eb-9f57-36dc7e1541f8"), 6 },
                    { new Guid("f43119a2-74a7-4c38-85bb-005275bff9b7"), new Guid("85d19b94-a402-4374-9c93-71d58533e6fc"), new Guid("32e54047-db5f-43ed-afcd-43a8ab7692a8"), 5 },
                    { new Guid("bd18215a-48c2-4f9a-8c77-3501ffdcd571"), new Guid("85d19b94-a402-4374-9c93-71d58533e6fc"), new Guid("8221e424-5e13-46cd-9b94-3824a7da5b31"), 10 },
                    { new Guid("90348dd2-506d-469e-b9fe-5b92d974ea26"), new Guid("85d19b94-a402-4374-9c93-71d58533e6fc"), new Guid("0f125d2e-d071-4119-95d7-77fc9e46e7a4"), 13 },
                    { new Guid("ac1858d8-e549-4059-a38f-7b3c51529204"), new Guid("85d19b94-a402-4374-9c93-71d58533e6fc"), new Guid("740ccb3d-5c6e-41c8-9be9-2dc003ece707"), 14 },
                    { new Guid("400bbeb2-2ae7-4a55-bc58-98abcfb34ade"), new Guid("85d19b94-a402-4374-9c93-71d58533e6fc"), new Guid("69512c08-faa8-4c94-a259-917df81555cf"), 24 },
                    { new Guid("faba721f-780c-4118-af74-38173179bc03"), new Guid("77fb7ae5-14cc-44c2-9c42-98a10323fc3d"), new Guid("69512c08-faa8-4c94-a259-917df81555cf"), 22 },
                    { new Guid("a0ec0292-8450-4048-b0a9-b48e1cfafaf7"), new Guid("588a11f6-14d3-4613-ac3f-f03690105d72"), new Guid("32e54047-db5f-43ed-afcd-43a8ab7692a8"), 8 },
                    { new Guid("4f9c54d5-b56e-430a-904f-c72e8e4d74e0"), new Guid("77fb7ae5-14cc-44c2-9c42-98a10323fc3d"), new Guid("d6662ea2-60e2-47a9-9685-eeedf476e6b1"), 2 },
                    { new Guid("af80407a-2bc2-446c-ab18-b73867fc5390"), new Guid("77fb7ae5-14cc-44c2-9c42-98a10323fc3d"), new Guid("8221e424-5e13-46cd-9b94-3824a7da5b31"), 11 },
                    { new Guid("ea77b198-4d7e-476f-8641-4f1342f2fb9c"), new Guid("77fb7ae5-14cc-44c2-9c42-98a10323fc3d"), new Guid("d2706ca5-5a3f-47be-a3ff-735ba9d0df03"), 25 },
                    { new Guid("54a47864-924e-42fe-87a5-114b9701dcd3"), new Guid("77fb7ae5-14cc-44c2-9c42-98a10323fc3d"), new Guid("32e54047-db5f-43ed-afcd-43a8ab7692a8"), 21 },
                    { new Guid("6abe6dc8-08a9-4374-94ae-9f5fa1e857dc"), new Guid("77fb7ae5-14cc-44c2-9c42-98a10323fc3d"), new Guid("740ccb3d-5c6e-41c8-9be9-2dc003ece707"), 10 },
                    { new Guid("e7bb99af-386f-4992-8e0e-647016e658f6"), new Guid("d0a3dc0a-db1f-4672-b92e-9318aece6e68"), new Guid("e9b648d8-d1f6-4f6e-a335-4432b06838d5"), 3 },
                    { new Guid("97693042-2622-4692-87d5-940b451f8d42"), new Guid("d0a3dc0a-db1f-4672-b92e-9318aece6e68"), new Guid("8221e424-5e13-46cd-9b94-3824a7da5b31"), 18 },
                    { new Guid("31d3d3dc-4994-4ff8-9653-5bb9e877ad3f"), new Guid("d0a3dc0a-db1f-4672-b92e-9318aece6e68"), new Guid("d6662ea2-60e2-47a9-9685-eeedf476e6b1"), 27 },
                    { new Guid("ce98eadd-a1be-44c9-ace6-3f810a6b6cd3"), new Guid("d0a3dc0a-db1f-4672-b92e-9318aece6e68"), new Guid("0f125d2e-d071-4119-95d7-77fc9e46e7a4"), 4 },
                    { new Guid("262a3b91-6791-4806-ab7d-db6a0cc46835"), new Guid("d0a3dc0a-db1f-4672-b92e-9318aece6e68"), new Guid("32e54047-db5f-43ed-afcd-43a8ab7692a8"), 13 },
                    { new Guid("490ffb37-9ec8-44e1-88c5-9c7bc417088b"), new Guid("1dd3994b-2d43-4ab7-bf0c-d71699fe45cd"), new Guid("9539614d-aec7-4747-a754-3a1375e59b3e"), 9 },
                    { new Guid("b1e5a4b0-45c1-49d9-90ca-42241df61d57"), new Guid("1dd3994b-2d43-4ab7-bf0c-d71699fe45cd"), new Guid("d6662ea2-60e2-47a9-9685-eeedf476e6b1"), 2 },
                    { new Guid("2a6e7fa3-63d0-443d-98ea-1898cd7138e6"), new Guid("1dd3994b-2d43-4ab7-bf0c-d71699fe45cd"), new Guid("5fd00212-1985-41eb-9f57-36dc7e1541f8"), 6 },
                    { new Guid("8462d265-e2e6-4853-ba65-8552805bef2a"), new Guid("1dd3994b-2d43-4ab7-bf0c-d71699fe45cd"), new Guid("0f125d2e-d071-4119-95d7-77fc9e46e7a4"), 12 },
                    { new Guid("3353e578-ed10-423f-b2dc-6046b668b8e2"), new Guid("77fb7ae5-14cc-44c2-9c42-98a10323fc3d"), new Guid("9539614d-aec7-4747-a754-3a1375e59b3e"), 7 },
                    { new Guid("6e444720-0154-4f71-900f-9b619aa3e166"), new Guid("588a11f6-14d3-4613-ac3f-f03690105d72"), new Guid("9539614d-aec7-4747-a754-3a1375e59b3e"), 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeProducts_FridgeId",
                table: "FridgeProducts",
                column: "FridgeId");

            migrationBuilder.CreateIndex(
                name: "IX_FridgeProducts_ProductId",
                table: "FridgeProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Fridges_FridgeModelId",
                table: "Fridges",
                column: "FridgeModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FridgeProducts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Fridges");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "FridgeModels");
        }
    }
}
