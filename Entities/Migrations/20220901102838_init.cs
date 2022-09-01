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
                    { "624e7a25-711a-4935-bde8-f035a19dc6c3", "38cb36b8-b870-43c7-888a-bff564eda798", "user", "USER" },
                    { "218726a2-a1f9-4c41-b1f6-8075767d2c19", "bfbebcc9-ffe5-498d-bd01-44c73133d7d4", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "FridgeModels",
                columns: new[] { "Id", "Name", "Year" },
                values: new object[,]
                {
                    { new Guid("67126052-b657-42d1-bed9-3799bdab2d3b"), "RSA1SHVB1", 2016 },
                    { new Guid("dd6d3261-a876-428c-ae62-f856132fc19d"), "VF 395-1 SBS", 2012 },
                    { new Guid("77d784a1-95bb-441c-a4c3-9ea117717df0"), "SBS 7212", 2011 },
                    { new Guid("abf38b3a-4159-4ccb-98aa-5c85d638e9f9"), "RF-61 K90407F", 2011 },
                    { new Guid("0334dc6e-38b3-41c5-96c5-aed580f565a1"), "Electric MR-CR46G-HS-R", 2015 },
                    { new Guid("e676a1ef-978d-431a-b4b3-1ed3367cc7b1"), "VF 910 X", 2010 },
                    { new Guid("dee19637-d0ba-4f64-9447-ea6d7ed6f703"), "TH-803", 2010 },
                    { new Guid("17703f0b-356e-4346-b631-da5965d694f4"), "KGN36S55", 2019 },
                    { new Guid("6bb788cd-ce13-4b02-a781-d621f90b56f3"), "VF 466 EB", 2011 },
                    { new Guid("2d11d538-2631-4cff-b94e-2a2d1177ece1"), "DS 333020", 2014 },
                    { new Guid("c1d2b335-2ee7-41cb-ba39-a5c791703acf"), "DF 5180 W", 2016 },
                    { new Guid("316e7144-85e5-43f5-b96a-9b2221c760c3"), "XM 4021-000", 2013 },
                    { new Guid("96e4de91-d312-4c26-a70c-db38e910d433"), "RC-54", 2019 },
                    { new Guid("46ec6a11-82fd-435b-bc8d-b8231f5be9b1"), "RB-34 K6220SS", 2011 },
                    { new Guid("959c45ee-9c1e-49d1-9419-8a223f8321b3"), "514-NWE", 2019 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DefaultQuantity", "ImageSource", "Name" },
                values: new object[,]
                {
                    { new Guid("83207418-0efa-4915-ab0e-c01a0660d581"), 6, "https://www.seeds-gallery.shop/8291-large_default/lemon-seeds-c-limon.jpg", "Lemon" },
                    { new Guid("ad3da370-5bf0-49e5-9f14-1ded754f86c7"), 6, "https://cdn.shopify.com/s/files/1/2971/2126/products/Orange_f48b955f-9cde-4b90-bbd5-03ce7b8bcf1f_400x.jpg?v=1569304785", "Orange" },
                    { new Guid("57f05516-0ad9-4c47-a30a-9a9686b94293"), 6, "https://static.libertyprim.com/files/familles/peche-large.jpg?1574630286", "Peach" },
                    { new Guid("857bc16b-fadd-4fd4-9327-21011f94f3cc"), 11, "https://befreshcorp.net/wp-content/uploads/2017/07/product-packshot-strawberrie-558x600.jpg", "Strawberry" },
                    { new Guid("9a644c45-c42b-4a05-a10f-85708420ed00"), 16, "https://soapatopia.com/wp-content/uploads/2021/01/raspberries.jpg", "Raspberry" },
                    { new Guid("1ad0298a-a534-4c7f-b5ac-57c777ed8c48"), 14, "https://www.seeds-gallery.shop/5488-large_default/400-watermelon-seeds-crimson-sweet.jpg", "Watermelon" },
                    { new Guid("67edc619-ba82-4673-b60d-0141ea40aa94"), 12, "https://quintalsonline.com/wp-content/uploads/2020/05/close-up-of-block-of-butter-being-sliced-may-raise-cholesterol_1400x.jpg", "Butter" },
                    { new Guid("936ed325-5b21-40fa-8a02-e6acb039143c"), 12, "https://andygrimshaw.com/wp-content/uploads/2016/03/Chocolate-bar-melt-explosion.jpg", "Chocolate" },
                    { new Guid("b537531e-6533-4d43-9ad7-c5ba00264add"), 8, "https://groceries.morrisons.com/productImages/408/408833011_0_268x268.jpg?identifier=146ae3bbcbb049c8aa859a0fbd47946e", "Kefir" },
                    { new Guid("71eb81fe-f43f-4711-8c47-202d9a5b2832"), 8, "https://img.freepik.com/free-vector/isolated-dark-grape-with-green-leaf_317810-1956.jpg?w=2000", "Grape" },
                    { new Guid("dc2ef7b9-afdd-4bab-b525-e5edadd4ae0d"), 17, "https://assets.tmecosys.com/image/upload/t_web767x639/img/recipe/ras/Assets/4B7C3510-7041-4B5D-8000-1D10B1BA4678/Derivates/6749ac4e-586d-4055-9df2-5a96832897f6.jpg", "Jam" },
                    { new Guid("5738609f-8434-41da-bfe4-c639bf3a8580"), 8, "https://www.mybakingaddiction.com/wp-content/uploads/2021/03/vanilla-pudding-with-fruit-720x720.jpg", "Pudding" },
                    { new Guid("490af2c4-4d4f-4cea-b694-8acbcdabafdb"), 6, "https://assets.tmecosys.com/image/upload/t_web767x639/img/recipe/ras/Assets/607dfd53-5b5c-4309-9e1f-5a959d20e16c/Derivates/9ac9e3c1-20d2-4d31-afdb-191c9ba22235.jpg", "Jelly" },
                    { new Guid("63c383fa-60e1-48fc-8b0c-bd1c74978730"), 7, "https://www.wholesomeyum.com/wp-content/uploads/2017/03/wholesomeyum-Low-Carb-Keto-Pancakes-Recipe-21.jpg", "Pancake" },
                    { new Guid("4e6ab710-5b9a-4d62-81fe-ca1361f53a75"), 12, "https://media.istockphoto.com/photos/fresh-citrus-juices-picture-id158268808?k=20&m=158268808&s=612x612&w=0&h=9mUMCBDaY-JYqR7m9r_mi0-Ta0RIebZ3DpxyimSQ7Fc=", "Juice" },
                    { new Guid("07bcfe36-9949-4a94-8762-925fff456ec7"), 16, "https://img.freepik.com/free-vector/soda-cups-drink_24877-57922.jpg?w=2000", "Soda" },
                    { new Guid("21f5b513-c80f-4740-9eef-956ba539d517"), 10, "https://static.vecteezy.com/system/resources/previews/006/225/849/original/a-carton-of-milk-cartoon-illustration-vector.jpg", "Milk" },
                    { new Guid("21c514ce-a929-4ef3-8527-d22d22b3446c"), 9, "https://sc04.alicdn.com/kf/Ub2b912f5fb6d48ce99dee2bef2a7d2fch.jpg", "Cherry" },
                    { new Guid("deefca7b-019b-491b-97a8-760ae77a9e93"), 5, "https://produits.bienmanger.com/36700-0w470h470_Organic_Red_Onion_From_Italy.jpg", "Onion" },
                    { new Guid("3abdb7f0-5be2-4ef3-b564-7b86ba7282fd"), 5, "https://5.imimg.com/data5/ANDROID/Default/2021/2/UH/HH/LB/44089979/potatoes-jpg-250x250.jpg", "Potato" },
                    { new Guid("8e55a5d7-7a86-4601-a1fd-717b60759c59"), 16, "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7b/Assorted_bread.jpg/274px-Assorted_bread.jpg", "Bread" },
                    { new Guid("2d7e09eb-e784-4788-91ce-bf174bd3e801"), 10, "https://id-test-11.slatic.net/p/70f40d8f77f844671af4a5a11755e7ae.jpg", "Apple" },
                    { new Guid("691e00fe-486e-426b-88b5-e22218ae16a9"), 17, "https://media.istockphoto.com/vectors/yogurt-cup-with-spoon-vector-id1060883416?k=20&m=1060883416&s=612x612&w=0&h=nhPJA8XYohdkGbBojLt72e_q9sbgBuO6mUI-7cnuu6s=", "Yoghurt" },
                    { new Guid("13690f61-d0c8-487c-9738-a71e6ddc5945"), 10, "https://www.collinsdictionary.com/images/full/egg_110803370.jpg", "Egg" },
                    { new Guid("c3f712d7-57c3-4116-a525-96dfab9a8b6c"), 15, "https://cdn.yamatoscale.com/wp-content/uploads/2016/04/K%C3%A4se-Scheiben_01_00_OH-1.jpg", "Cheese" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DefaultQuantity", "ImageSource", "Name" },
                values: new object[,]
                {
                    { new Guid("824d13bf-9fea-44fa-a074-b08c82e40634"), 13, "https://4.imimg.com/data4/JX/UQ/ANDROID-47104262/product-500x500.jpeg", "Mashroom" },
                    { new Guid("f99411f4-ffa5-489f-8c4e-a7abb6b5cffc"), 12, "https://food.fnr.sndimg.com/content/dam/images/food/fullset/2010/5/1/0/0039592F3_beer-can-chicken_s4x3.jpg.rend.hgtvcom.616.462.suffix/1382539274625.jpeg", "Chicken" },
                    { new Guid("c63bd2ca-edd9-4d36-bd6d-1326551f0c21"), 10, "https://images.heb.com/is/image/HEBGrocery/000377497", "Banana" },
                    { new Guid("fd8eb2a4-5795-4fb1-b765-bd485e4c948e"), 9, "https://www.thespruceeats.com/thmb/OueG44zJ3LnwQt9HwVXmmT6mkNM=/3067x3067/smart/filters:no_upscale()/roasted-boneless-pork-loin-recipe-995289-hero-01-93314ca221a54ecebc45a17e99cb78c4.jpg", "Pork" },
                    { new Guid("a8e3c5ab-d5df-487d-b1c1-adb71c8a2db0"), 6, "https://www.crescentfoods.lk/images/products/PREMIUM_CHICKEN_SAUSAGES.jpg", "Sausage" },
                    { new Guid("73463840-fed5-49c2-baad-74ec78e8bd7d"), 11, "https://preview.free3d.com/img/2017/05/2279485108920518249/e92jihnh-900.jpg", "Fish" },
                    { new Guid("5eb861be-b8a6-46d5-ae50-f14df27a3b01"), 17, "https://images.absolutdrinks.com/ingredient-images/Raw/Absolut/d391984d-0573-4fb2-aa36-2f18d2ee8ce8.jpg?imwidth=500", "Avocado" },
                    { new Guid("11c41bbc-7476-4fbd-8578-e2f4118dd98d"), 8, "https://www.eatthis.com/wp-content/uploads/sites/4/2020/03/variety-of-beans.jpg?quality=82&strip=1", "Beans" },
                    { new Guid("d4b758be-4bcb-4454-9c91-ff760f1cecaf"), 14, "https://www.jessicagavin.com/wp-content/uploads/2019/02/carrots-7-1200.jpg", "Carrot" },
                    { new Guid("aac0d0be-d048-4d2f-a992-8fa97db205e3"), 6, "https://www.farmersfamily.in/wp-content/uploads/2020/08/Cucumber.jpg", "Cucumber" },
                    { new Guid("4fe877bc-f34b-4813-ad46-cfb1470d10c0"), 13, "https://www.ngroceries.com/wp-content/uploads/2021/10/61amdwJRu-L._SX522_.jpg", "Garlic" },
                    { new Guid("1e0bc6e0-0ecc-42d8-9ddd-396b70c65251"), 14, "https://hips.hearstapps.com/hmg-prod/images/delish-roast-beef-horizontal-1540505165.jpg", "Beef" },
                    { new Guid("d721a6fe-9893-417d-9c83-2ed695b475da"), 16, "http://cdn.shopify.com/s/files/1/0404/0710/5687/products/6000200094505_grande.jpg?v=1595626016", "Broccoli" }
                });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "Id", "FridgeModelId", "Name", "OwnerName" },
                values: new object[,]
                {
                    { new Guid("cffc5731-3af8-4f77-994b-9b9649a60ace"), new Guid("959c45ee-9c1e-49d1-9419-8a223f8321b3"), "Bosch", "Vlada" },
                    { new Guid("220b14ea-114f-4b64-bb53-2f926b77fd7c"), new Guid("316e7144-85e5-43f5-b96a-9b2221c760c3"), "Beko", "Nastya" },
                    { new Guid("b921502a-1964-4033-83d9-885faf12f74d"), new Guid("316e7144-85e5-43f5-b96a-9b2221c760c3"), "Beko", "Anna" },
                    { new Guid("bd38cdb8-0cd4-46b8-a292-d58bd1027d1e"), new Guid("316e7144-85e5-43f5-b96a-9b2221c760c3"), "Atlant", "Dima" },
                    { new Guid("c01e3b97-3c46-4683-ab34-d99a13c0bd56"), new Guid("17703f0b-356e-4346-b631-da5965d694f4"), "Vestfrost", "Polina" }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("addb7ee8-da1d-4a10-a0cf-7505d53966e0"), new Guid("cffc5731-3af8-4f77-994b-9b9649a60ace"), new Guid("deefca7b-019b-491b-97a8-760ae77a9e93"), 13 },
                    { new Guid("7375f864-faa1-47f5-ae59-c5df59c12c3b"), new Guid("bd38cdb8-0cd4-46b8-a292-d58bd1027d1e"), new Guid("83207418-0efa-4915-ab0e-c01a0660d581"), 2 },
                    { new Guid("ca89d08d-c491-4d27-983d-fb432479e559"), new Guid("bd38cdb8-0cd4-46b8-a292-d58bd1027d1e"), new Guid("8e55a5d7-7a86-4601-a1fd-717b60759c59"), 33 },
                    { new Guid("106494ab-6862-41d6-8f72-3f4e47d29299"), new Guid("bd38cdb8-0cd4-46b8-a292-d58bd1027d1e"), new Guid("b537531e-6533-4d43-9ad7-c5ba00264add"), 12 },
                    { new Guid("478d37c5-021a-4f9a-8bb9-7fd969658f6a"), new Guid("bd38cdb8-0cd4-46b8-a292-d58bd1027d1e"), new Guid("5738609f-8434-41da-bfe4-c639bf3a8580"), 42 },
                    { new Guid("56f0db66-3afc-4dc1-8842-7ed7d89bfc39"), new Guid("bd38cdb8-0cd4-46b8-a292-d58bd1027d1e"), new Guid("deefca7b-019b-491b-97a8-760ae77a9e93"), 26 },
                    { new Guid("a5075682-c048-49e2-9e29-bf57a5497668"), new Guid("bd38cdb8-0cd4-46b8-a292-d58bd1027d1e"), new Guid("1e0bc6e0-0ecc-42d8-9ddd-396b70c65251"), 4 },
                    { new Guid("7545890c-1302-4550-b8ed-89a906afedb7"), new Guid("bd38cdb8-0cd4-46b8-a292-d58bd1027d1e"), new Guid("07bcfe36-9949-4a94-8762-925fff456ec7"), 48 },
                    { new Guid("309c2bbf-3f3e-4386-8504-1a0af8f7e09b"), new Guid("bd38cdb8-0cd4-46b8-a292-d58bd1027d1e"), new Guid("2d7e09eb-e784-4788-91ce-bf174bd3e801"), 37 },
                    { new Guid("1bd53e3e-8658-4afb-8563-36033740aa62"), new Guid("bd38cdb8-0cd4-46b8-a292-d58bd1027d1e"), new Guid("3abdb7f0-5be2-4ef3-b564-7b86ba7282fd"), 32 },
                    { new Guid("b1ea8091-8484-4366-b154-597bda58d051"), new Guid("bd38cdb8-0cd4-46b8-a292-d58bd1027d1e"), new Guid("d4b758be-4bcb-4454-9c91-ff760f1cecaf"), 75 },
                    { new Guid("77d61171-f2da-41bd-9ced-5c08680da336"), new Guid("bd38cdb8-0cd4-46b8-a292-d58bd1027d1e"), new Guid("71eb81fe-f43f-4711-8c47-202d9a5b2832"), 14 },
                    { new Guid("f89fad46-a3e3-4908-b9c2-540a52fc7585"), new Guid("bd38cdb8-0cd4-46b8-a292-d58bd1027d1e"), new Guid("21c514ce-a929-4ef3-8527-d22d22b3446c"), 47 },
                    { new Guid("5af763a0-0ce9-4770-95aa-561565ccf110"), new Guid("bd38cdb8-0cd4-46b8-a292-d58bd1027d1e"), new Guid("aac0d0be-d048-4d2f-a992-8fa97db205e3"), 75 },
                    { new Guid("f2fe4099-0260-4a8f-b741-2045213e8453"), new Guid("bd38cdb8-0cd4-46b8-a292-d58bd1027d1e"), new Guid("490af2c4-4d4f-4cea-b694-8acbcdabafdb"), 50 },
                    { new Guid("571aae09-8373-45b7-93e1-038df1a1a0eb"), new Guid("bd38cdb8-0cd4-46b8-a292-d58bd1027d1e"), new Guid("9a644c45-c42b-4a05-a10f-85708420ed00"), 3 },
                    { new Guid("377d99ab-4526-470f-a268-cce678cb98c8"), new Guid("b921502a-1964-4033-83d9-885faf12f74d"), new Guid("1e0bc6e0-0ecc-42d8-9ddd-396b70c65251"), 25 },
                    { new Guid("4ca46cb7-526d-4b8e-a3f3-8b80576edca3"), new Guid("b921502a-1964-4033-83d9-885faf12f74d"), new Guid("a8e3c5ab-d5df-487d-b1c1-adb71c8a2db0"), 29 },
                    { new Guid("ce628a7f-eb99-4a6a-aba6-0ef518e04770"), new Guid("b921502a-1964-4033-83d9-885faf12f74d"), new Guid("aac0d0be-d048-4d2f-a992-8fa97db205e3"), 52 },
                    { new Guid("a36119b2-ec8d-4fb9-b00c-2f8b76ac3abe"), new Guid("b921502a-1964-4033-83d9-885faf12f74d"), new Guid("d4b758be-4bcb-4454-9c91-ff760f1cecaf"), 69 },
                    { new Guid("ec6edc6f-ae7d-41c6-9e49-e42b13398dd5"), new Guid("b921502a-1964-4033-83d9-885faf12f74d"), new Guid("63c383fa-60e1-48fc-8b0c-bd1c74978730"), 12 },
                    { new Guid("41ff12b6-e831-4c7f-868a-610d8bf42aaf"), new Guid("b921502a-1964-4033-83d9-885faf12f74d"), new Guid("deefca7b-019b-491b-97a8-760ae77a9e93"), 26 },
                    { new Guid("c43c69f6-f19b-46fe-877e-cbecc0f7955a"), new Guid("b921502a-1964-4033-83d9-885faf12f74d"), new Guid("ad3da370-5bf0-49e5-9f14-1ded754f86c7"), 9 },
                    { new Guid("59c43fe8-1c8d-4ced-bf42-85f51bdc40b1"), new Guid("b921502a-1964-4033-83d9-885faf12f74d"), new Guid("dc2ef7b9-afdd-4bab-b525-e5edadd4ae0d"), 45 },
                    { new Guid("beb9a1e9-e84f-4dbb-905a-a6451375e6f3"), new Guid("b921502a-1964-4033-83d9-885faf12f74d"), new Guid("936ed325-5b21-40fa-8a02-e6acb039143c"), 42 },
                    { new Guid("aac6538c-8170-4300-916d-dfbb7b094158"), new Guid("b921502a-1964-4033-83d9-885faf12f74d"), new Guid("21f5b513-c80f-4740-9eef-956ba539d517"), 42 },
                    { new Guid("d6798db7-42ca-4444-bd5e-61d6fbe48a10"), new Guid("bd38cdb8-0cd4-46b8-a292-d58bd1027d1e"), new Guid("4fe877bc-f34b-4813-ad46-cfb1470d10c0"), 28 },
                    { new Guid("61234fd0-5a9d-47d2-9ad4-67a0713c1c3f"), new Guid("b921502a-1964-4033-83d9-885faf12f74d"), new Guid("b537531e-6533-4d43-9ad7-c5ba00264add"), 33 },
                    { new Guid("08690eea-75c5-4ef9-9aad-777e168bfff6"), new Guid("bd38cdb8-0cd4-46b8-a292-d58bd1027d1e"), new Guid("dc2ef7b9-afdd-4bab-b525-e5edadd4ae0d"), 18 },
                    { new Guid("7daf72d3-66d9-454a-83db-08021bc27c13"), new Guid("bd38cdb8-0cd4-46b8-a292-d58bd1027d1e"), new Guid("4e6ab710-5b9a-4d62-81fe-ca1361f53a75"), 41 },
                    { new Guid("9a08efc7-3383-48c6-be0a-8f1b47098004"), new Guid("c01e3b97-3c46-4683-ab34-d99a13c0bd56"), new Guid("71eb81fe-f43f-4711-8c47-202d9a5b2832"), 48 },
                    { new Guid("1748615e-62b6-46e9-bd44-e639ff6afeb4"), new Guid("c01e3b97-3c46-4683-ab34-d99a13c0bd56"), new Guid("3abdb7f0-5be2-4ef3-b564-7b86ba7282fd"), 21 },
                    { new Guid("6bb45275-8911-4ec0-9483-1bfb6799b930"), new Guid("c01e3b97-3c46-4683-ab34-d99a13c0bd56"), new Guid("ad3da370-5bf0-49e5-9f14-1ded754f86c7"), 31 },
                    { new Guid("cfc8fa50-4766-48a5-beff-8e483682fba2"), new Guid("c01e3b97-3c46-4683-ab34-d99a13c0bd56"), new Guid("857bc16b-fadd-4fd4-9327-21011f94f3cc"), 31 },
                    { new Guid("6716ceab-6daa-45d7-9985-b99f5b5491f4"), new Guid("c01e3b97-3c46-4683-ab34-d99a13c0bd56"), new Guid("691e00fe-486e-426b-88b5-e22218ae16a9"), 24 },
                    { new Guid("17757b3a-7c8a-4af3-8392-5dfeef1bc1d2"), new Guid("c01e3b97-3c46-4683-ab34-d99a13c0bd56"), new Guid("07bcfe36-9949-4a94-8762-925fff456ec7"), 15 },
                    { new Guid("1715f479-213a-415e-9bde-061c3defd310"), new Guid("c01e3b97-3c46-4683-ab34-d99a13c0bd56"), new Guid("f99411f4-ffa5-489f-8c4e-a7abb6b5cffc"), 10 },
                    { new Guid("ce4cb9f0-68e1-4a67-b380-e380edbbdffa"), new Guid("c01e3b97-3c46-4683-ab34-d99a13c0bd56"), new Guid("8e55a5d7-7a86-4601-a1fd-717b60759c59"), 38 },
                    { new Guid("3f343c77-f255-4cf4-b80b-911872d605aa"), new Guid("c01e3b97-3c46-4683-ab34-d99a13c0bd56"), new Guid("83207418-0efa-4915-ab0e-c01a0660d581"), 23 },
                    { new Guid("e5d57ad2-da35-4b09-b206-67d3737e6974"), new Guid("c01e3b97-3c46-4683-ab34-d99a13c0bd56"), new Guid("824d13bf-9fea-44fa-a074-b08c82e40634"), 24 },
                    { new Guid("1c186e4b-49ca-4417-8129-ea60b0368496"), new Guid("c01e3b97-3c46-4683-ab34-d99a13c0bd56"), new Guid("c3f712d7-57c3-4116-a525-96dfab9a8b6c"), 28 },
                    { new Guid("34349bdd-fc76-4461-bfac-3d62786ddfa6"), new Guid("c01e3b97-3c46-4683-ab34-d99a13c0bd56"), new Guid("2d7e09eb-e784-4788-91ce-bf174bd3e801"), 24 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("b9e29395-aca0-4b77-92cc-fdd3460c2fa3"), new Guid("c01e3b97-3c46-4683-ab34-d99a13c0bd56"), new Guid("1e0bc6e0-0ecc-42d8-9ddd-396b70c65251"), 4 },
                    { new Guid("25559d4f-648d-4c06-9ab0-4b8ad7cfcce8"), new Guid("c01e3b97-3c46-4683-ab34-d99a13c0bd56"), new Guid("fd8eb2a4-5795-4fb1-b765-bd485e4c948e"), 11 },
                    { new Guid("b2c95a32-dd21-45bd-bf48-8651d8940ec9"), new Guid("c01e3b97-3c46-4683-ab34-d99a13c0bd56"), new Guid("4e6ab710-5b9a-4d62-81fe-ca1361f53a75"), 28 },
                    { new Guid("3ad9ba21-59fa-42ec-975f-783b1d89853c"), new Guid("c01e3b97-3c46-4683-ab34-d99a13c0bd56"), new Guid("5eb861be-b8a6-46d5-ae50-f14df27a3b01"), 5 },
                    { new Guid("2e697fd5-1813-45c3-80a4-fe05da1c8d6d"), new Guid("c01e3b97-3c46-4683-ab34-d99a13c0bd56"), new Guid("c63bd2ca-edd9-4d36-bd6d-1326551f0c21"), 37 },
                    { new Guid("ecd50581-2bda-479e-b901-26ad162f239e"), new Guid("c01e3b97-3c46-4683-ab34-d99a13c0bd56"), new Guid("57f05516-0ad9-4c47-a30a-9a9686b94293"), 18 },
                    { new Guid("08a401b3-3515-441c-b4f0-57d3921dcfb7"), new Guid("c01e3b97-3c46-4683-ab34-d99a13c0bd56"), new Guid("21c514ce-a929-4ef3-8527-d22d22b3446c"), 13 },
                    { new Guid("4a0b2844-db62-4f79-acd1-cb3cf45b845e"), new Guid("c01e3b97-3c46-4683-ab34-d99a13c0bd56"), new Guid("936ed325-5b21-40fa-8a02-e6acb039143c"), 16 },
                    { new Guid("eb386c04-f5e6-4104-be30-857f971de7e8"), new Guid("bd38cdb8-0cd4-46b8-a292-d58bd1027d1e"), new Guid("691e00fe-486e-426b-88b5-e22218ae16a9"), 16 },
                    { new Guid("c965d054-a716-4d65-a8ac-93ae17b5efc5"), new Guid("bd38cdb8-0cd4-46b8-a292-d58bd1027d1e"), new Guid("d721a6fe-9893-417d-9c83-2ed695b475da"), 5 },
                    { new Guid("2a23b31c-7ca7-44af-9fb9-fa11f6139ed4"), new Guid("bd38cdb8-0cd4-46b8-a292-d58bd1027d1e"), new Guid("57f05516-0ad9-4c47-a30a-9a9686b94293"), 2 },
                    { new Guid("72721d0c-bc43-42a1-a6c0-96be459db7c5"), new Guid("bd38cdb8-0cd4-46b8-a292-d58bd1027d1e"), new Guid("c63bd2ca-edd9-4d36-bd6d-1326551f0c21"), 9 },
                    { new Guid("f8192227-19ff-4b63-8992-5e8730bff899"), new Guid("bd38cdb8-0cd4-46b8-a292-d58bd1027d1e"), new Guid("63c383fa-60e1-48fc-8b0c-bd1c74978730"), 45 },
                    { new Guid("da0148f6-5235-4c74-8c93-4a97c026e48b"), new Guid("bd38cdb8-0cd4-46b8-a292-d58bd1027d1e"), new Guid("11c41bbc-7476-4fbd-8578-e2f4118dd98d"), 30 },
                    { new Guid("2e41d80c-0887-42fe-aa93-8deeba8cb6eb"), new Guid("c01e3b97-3c46-4683-ab34-d99a13c0bd56"), new Guid("13690f61-d0c8-487c-9738-a71e6ddc5945"), 21 },
                    { new Guid("f6fa9a12-0a58-4a20-ad17-cd35ce706f70"), new Guid("b921502a-1964-4033-83d9-885faf12f74d"), new Guid("73463840-fed5-49c2-baad-74ec78e8bd7d"), 37 },
                    { new Guid("dd9429f9-addf-41cc-a18e-ef770e5ff858"), new Guid("b921502a-1964-4033-83d9-885faf12f74d"), new Guid("4fe877bc-f34b-4813-ad46-cfb1470d10c0"), 14 },
                    { new Guid("a351c925-1028-4604-93d0-d5fb3e1ba354"), new Guid("cffc5731-3af8-4f77-994b-9b9649a60ace"), new Guid("4e6ab710-5b9a-4d62-81fe-ca1361f53a75"), 0 },
                    { new Guid("41ea8e44-5910-400f-beee-4419e0d83da8"), new Guid("cffc5731-3af8-4f77-994b-9b9649a60ace"), new Guid("57f05516-0ad9-4c47-a30a-9a9686b94293"), 24 },
                    { new Guid("ebbab192-7b75-46fd-a6cb-3a35442a9e25"), new Guid("cffc5731-3af8-4f77-994b-9b9649a60ace"), new Guid("83207418-0efa-4915-ab0e-c01a0660d581"), 10 },
                    { new Guid("fb924543-2a81-4d2a-8892-a0dc13901238"), new Guid("cffc5731-3af8-4f77-994b-9b9649a60ace"), new Guid("936ed325-5b21-40fa-8a02-e6acb039143c"), 22 },
                    { new Guid("fee86096-fc5b-44b0-829f-3765c32738a8"), new Guid("cffc5731-3af8-4f77-994b-9b9649a60ace"), new Guid("11c41bbc-7476-4fbd-8578-e2f4118dd98d"), 5 },
                    { new Guid("1d68db1f-5018-4758-8c5d-de5db5403dde"), new Guid("cffc5731-3af8-4f77-994b-9b9649a60ace"), new Guid("5738609f-8434-41da-bfe4-c639bf3a8580"), 13 },
                    { new Guid("d02f1e3f-4eb0-406a-9e30-c357b579dd7c"), new Guid("cffc5731-3af8-4f77-994b-9b9649a60ace"), new Guid("63c383fa-60e1-48fc-8b0c-bd1c74978730"), 0 },
                    { new Guid("8c7a475d-2cd7-4c15-99ce-438e520fff9b"), new Guid("cffc5731-3af8-4f77-994b-9b9649a60ace"), new Guid("71eb81fe-f43f-4711-8c47-202d9a5b2832"), 12 },
                    { new Guid("e16cc505-1f19-4ea2-b942-5637282440c3"), new Guid("cffc5731-3af8-4f77-994b-9b9649a60ace"), new Guid("67edc619-ba82-4673-b60d-0141ea40aa94"), 58 },
                    { new Guid("85152b5e-c05a-480a-8fbd-6c6f163a7bd8"), new Guid("cffc5731-3af8-4f77-994b-9b9649a60ace"), new Guid("f99411f4-ffa5-489f-8c4e-a7abb6b5cffc"), 38 },
                    { new Guid("6bee07a2-4c9a-4fab-8f95-467fa1cced7d"), new Guid("cffc5731-3af8-4f77-994b-9b9649a60ace"), new Guid("490af2c4-4d4f-4cea-b694-8acbcdabafdb"), 13 },
                    { new Guid("40ecb154-694d-4bb2-a3c2-c9b89808754e"), new Guid("cffc5731-3af8-4f77-994b-9b9649a60ace"), new Guid("a8e3c5ab-d5df-487d-b1c1-adb71c8a2db0"), 83 },
                    { new Guid("66b1ab32-f212-49f6-8f14-11164b6f261e"), new Guid("cffc5731-3af8-4f77-994b-9b9649a60ace"), new Guid("73463840-fed5-49c2-baad-74ec78e8bd7d"), 42 },
                    { new Guid("bc2cae53-b587-43be-8db2-dbf1c90085a7"), new Guid("cffc5731-3af8-4f77-994b-9b9649a60ace"), new Guid("1e0bc6e0-0ecc-42d8-9ddd-396b70c65251"), 72 },
                    { new Guid("6671a9db-c6ea-489f-a618-f1234b298d34"), new Guid("cffc5731-3af8-4f77-994b-9b9649a60ace"), new Guid("d4b758be-4bcb-4454-9c91-ff760f1cecaf"), 12 },
                    { new Guid("d666688a-976a-40f5-affd-ea8a97136145"), new Guid("cffc5731-3af8-4f77-994b-9b9649a60ace"), new Guid("5eb861be-b8a6-46d5-ae50-f14df27a3b01"), 27 },
                    { new Guid("ca393048-5d23-45c9-a735-e8c5e8e0f353"), new Guid("cffc5731-3af8-4f77-994b-9b9649a60ace"), new Guid("aac0d0be-d048-4d2f-a992-8fa97db205e3"), 6 },
                    { new Guid("efa2c268-ca98-450f-bebf-31c24beafad4"), new Guid("cffc5731-3af8-4f77-994b-9b9649a60ace"), new Guid("d721a6fe-9893-417d-9c83-2ed695b475da"), 46 },
                    { new Guid("4fe4baf3-848a-4fd5-bddd-33a43fd81471"), new Guid("cffc5731-3af8-4f77-994b-9b9649a60ace"), new Guid("fd8eb2a4-5795-4fb1-b765-bd485e4c948e"), 29 },
                    { new Guid("e2838513-c2db-462e-b7d0-d1fb42c27a9b"), new Guid("cffc5731-3af8-4f77-994b-9b9649a60ace"), new Guid("dc2ef7b9-afdd-4bab-b525-e5edadd4ae0d"), 63 },
                    { new Guid("46b97c9a-3230-4042-86e5-ab861da824bf"), new Guid("cffc5731-3af8-4f77-994b-9b9649a60ace"), new Guid("857bc16b-fadd-4fd4-9327-21011f94f3cc"), 3 },
                    { new Guid("ea285627-6e07-438a-9ba6-26bd70101dd7"), new Guid("cffc5731-3af8-4f77-994b-9b9649a60ace"), new Guid("1ad0298a-a534-4c7f-b5ac-57c777ed8c48"), 80 },
                    { new Guid("298e9fc0-c1a1-4d2c-a322-03c1e076b146"), new Guid("cffc5731-3af8-4f77-994b-9b9649a60ace"), new Guid("21f5b513-c80f-4740-9eef-956ba539d517"), 25 },
                    { new Guid("9175631f-da85-447d-a1a9-bf4e29073259"), new Guid("cffc5731-3af8-4f77-994b-9b9649a60ace"), new Guid("9a644c45-c42b-4a05-a10f-85708420ed00"), 43 },
                    { new Guid("cc8d517f-29c7-43bc-b41c-0f903c4ad8da"), new Guid("cffc5731-3af8-4f77-994b-9b9649a60ace"), new Guid("b537531e-6533-4d43-9ad7-c5ba00264add"), 104 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("2dd176ec-9303-4c87-a57b-642b8036e228"), new Guid("cffc5731-3af8-4f77-994b-9b9649a60ace"), new Guid("824d13bf-9fea-44fa-a074-b08c82e40634"), 18 },
                    { new Guid("45c299e3-4ec4-40f5-bb4e-ce1b8a4344cb"), new Guid("b921502a-1964-4033-83d9-885faf12f74d"), new Guid("5eb861be-b8a6-46d5-ae50-f14df27a3b01"), 27 },
                    { new Guid("00737e29-97f5-4f8f-8445-e8f015f143e9"), new Guid("cffc5731-3af8-4f77-994b-9b9649a60ace"), new Guid("07bcfe36-9949-4a94-8762-925fff456ec7"), 1 },
                    { new Guid("d18b2a83-da75-400d-8802-d14ff9d5aa77"), new Guid("220b14ea-114f-4b64-bb53-2f926b77fd7c"), new Guid("691e00fe-486e-426b-88b5-e22218ae16a9"), 16 },
                    { new Guid("e4e89544-64b5-46f5-898a-c9724b5749f9"), new Guid("b921502a-1964-4033-83d9-885faf12f74d"), new Guid("11c41bbc-7476-4fbd-8578-e2f4118dd98d"), 50 },
                    { new Guid("b3936a72-8221-4625-8794-84d228c6a53b"), new Guid("b921502a-1964-4033-83d9-885faf12f74d"), new Guid("d721a6fe-9893-417d-9c83-2ed695b475da"), 42 },
                    { new Guid("0306793c-5188-401f-b403-80717f355378"), new Guid("b921502a-1964-4033-83d9-885faf12f74d"), new Guid("4e6ab710-5b9a-4d62-81fe-ca1361f53a75"), 7 },
                    { new Guid("479a2bf9-6361-4f99-be50-44ff9e198748"), new Guid("b921502a-1964-4033-83d9-885faf12f74d"), new Guid("5738609f-8434-41da-bfe4-c639bf3a8580"), 86 },
                    { new Guid("7c3e3f29-d79c-4401-aec9-8da9a3b5ee29"), new Guid("b921502a-1964-4033-83d9-885faf12f74d"), new Guid("490af2c4-4d4f-4cea-b694-8acbcdabafdb"), 87 },
                    { new Guid("d9cc22fb-9f81-400b-9f68-1d54295a958f"), new Guid("b921502a-1964-4033-83d9-885faf12f74d"), new Guid("67edc619-ba82-4673-b60d-0141ea40aa94"), 40 },
                    { new Guid("bc0bc117-663c-4543-8d14-bd1ecbd5f82e"), new Guid("220b14ea-114f-4b64-bb53-2f926b77fd7c"), new Guid("73463840-fed5-49c2-baad-74ec78e8bd7d"), 12 },
                    { new Guid("24b26fba-691c-486b-a76f-31bb6b58d4ff"), new Guid("220b14ea-114f-4b64-bb53-2f926b77fd7c"), new Guid("57f05516-0ad9-4c47-a30a-9a9686b94293"), 31 },
                    { new Guid("83083ff4-8054-4bf0-ac05-06552242316f"), new Guid("220b14ea-114f-4b64-bb53-2f926b77fd7c"), new Guid("1e0bc6e0-0ecc-42d8-9ddd-396b70c65251"), 43 },
                    { new Guid("9d04e7fa-b9b4-40d8-8ef9-0dcef862ea80"), new Guid("220b14ea-114f-4b64-bb53-2f926b77fd7c"), new Guid("21f5b513-c80f-4740-9eef-956ba539d517"), 5 },
                    { new Guid("d3cf835c-e890-4711-95b0-59ce943511ea"), new Guid("220b14ea-114f-4b64-bb53-2f926b77fd7c"), new Guid("9a644c45-c42b-4a05-a10f-85708420ed00"), 30 },
                    { new Guid("510b0207-61e4-483f-a39d-7e1053051b07"), new Guid("220b14ea-114f-4b64-bb53-2f926b77fd7c"), new Guid("67edc619-ba82-4673-b60d-0141ea40aa94"), 8 },
                    { new Guid("318561e3-638e-4398-9c4a-db0b5eb79769"), new Guid("220b14ea-114f-4b64-bb53-2f926b77fd7c"), new Guid("c3f712d7-57c3-4116-a525-96dfab9a8b6c"), 4 },
                    { new Guid("ed5c2749-b461-4b4e-8ef0-b05904f74b4b"), new Guid("220b14ea-114f-4b64-bb53-2f926b77fd7c"), new Guid("c63bd2ca-edd9-4d36-bd6d-1326551f0c21"), 16 },
                    { new Guid("cdaedf0b-a177-47b4-813f-5461a3e01b54"), new Guid("220b14ea-114f-4b64-bb53-2f926b77fd7c"), new Guid("ad3da370-5bf0-49e5-9f14-1ded754f86c7"), 56 },
                    { new Guid("14a6eeee-ba12-4206-8c0b-47b16fe8b23e"), new Guid("220b14ea-114f-4b64-bb53-2f926b77fd7c"), new Guid("857bc16b-fadd-4fd4-9327-21011f94f3cc"), 24 },
                    { new Guid("b4dd0121-f0a1-437a-babb-f5def3312e9b"), new Guid("220b14ea-114f-4b64-bb53-2f926b77fd7c"), new Guid("fd8eb2a4-5795-4fb1-b765-bd485e4c948e"), 28 },
                    { new Guid("e8105c69-12fe-448f-8ce6-def1815edc57"), new Guid("220b14ea-114f-4b64-bb53-2f926b77fd7c"), new Guid("f99411f4-ffa5-489f-8c4e-a7abb6b5cffc"), 26 },
                    { new Guid("bf67d65a-234d-4c6c-8c5a-b207a2e9639a"), new Guid("220b14ea-114f-4b64-bb53-2f926b77fd7c"), new Guid("1ad0298a-a534-4c7f-b5ac-57c777ed8c48"), 60 },
                    { new Guid("8e679e89-d9e6-4f10-830a-4a12d7f8ec8d"), new Guid("220b14ea-114f-4b64-bb53-2f926b77fd7c"), new Guid("13690f61-d0c8-487c-9738-a71e6ddc5945"), 27 },
                    { new Guid("ecdd0905-297b-43cf-8053-fae8d34805c2"), new Guid("220b14ea-114f-4b64-bb53-2f926b77fd7c"), new Guid("83207418-0efa-4915-ab0e-c01a0660d581"), 35 },
                    { new Guid("3cbfac1a-f362-4272-830e-0d3c5136c1fc"), new Guid("220b14ea-114f-4b64-bb53-2f926b77fd7c"), new Guid("824d13bf-9fea-44fa-a074-b08c82e40634"), 37 },
                    { new Guid("4e6b5bb6-7771-493b-b335-e8f68f33a3ab"), new Guid("220b14ea-114f-4b64-bb53-2f926b77fd7c"), new Guid("71eb81fe-f43f-4711-8c47-202d9a5b2832"), 20 },
                    { new Guid("16d4f0cc-9d99-4caf-9099-6a7c3e447cef"), new Guid("220b14ea-114f-4b64-bb53-2f926b77fd7c"), new Guid("a8e3c5ab-d5df-487d-b1c1-adb71c8a2db0"), 55 },
                    { new Guid("07c29fd9-eb43-4db8-ab27-d9ffd2f39486"), new Guid("220b14ea-114f-4b64-bb53-2f926b77fd7c"), new Guid("8e55a5d7-7a86-4601-a1fd-717b60759c59"), 1 },
                    { new Guid("fdd87339-2fa0-4fdc-b616-9780cc2ad5d9"), new Guid("220b14ea-114f-4b64-bb53-2f926b77fd7c"), new Guid("11c41bbc-7476-4fbd-8578-e2f4118dd98d"), 12 },
                    { new Guid("60948d88-f977-42dd-91cb-ea846e3a15ba"), new Guid("c01e3b97-3c46-4683-ab34-d99a13c0bd56"), new Guid("4fe877bc-f34b-4813-ad46-cfb1470d10c0"), 11 }
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
