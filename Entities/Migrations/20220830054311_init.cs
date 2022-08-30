using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    DefaultQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
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
                table: "FridgeModels",
                columns: new[] { "Id", "Name", "Year" },
                values: new object[,]
                {
                    { new Guid("8327333d-91f6-44a5-8ff1-d359f92fb2b7"), "TH-803", 2017 },
                    { new Guid("9aa97ade-e26a-416a-97a0-4f4c06ebd314"), "RSA1SHVB1", 2018 },
                    { new Guid("afd18796-df5e-48c7-bb9c-0bfe3ed04e9c"), "VF 395-1 SBS", 2018 },
                    { new Guid("4d66b102-b242-4d9c-a52a-18cafb1a5169"), "SBS 7212", 2013 },
                    { new Guid("4771be19-940d-4ce4-ad48-18f49164e5b8"), "Electric MR-CR46G-HS-R", 2017 },
                    { new Guid("885f37cb-701f-4181-84c3-ffcb7926288f"), "VF 910 X", 2013 },
                    { new Guid("fa6ce91d-cd86-49b3-a5f8-85c02e103f51"), "RB-34 K6220SS", 2011 },
                    { new Guid("4fe91723-603f-4c30-9779-144fc5437d8b"), "RF-61 K90407F", 2017 },
                    { new Guid("baa761dd-e039-4bf7-badf-ddb95b757b74"), "VF 466 EB", 2013 },
                    { new Guid("0f313d4c-e0e0-4a6b-bbbe-57552085c920"), "DS 333020", 2013 },
                    { new Guid("235ceca3-3827-4dfc-b209-bb3b214c4cf6"), "DF 5180 W", 2015 },
                    { new Guid("41c31e3a-d486-4faa-af1d-ba7ce21a9d29"), "XM 4021-000", 2017 },
                    { new Guid("1efdc335-b487-4c54-af0a-8cdf69fc0779"), "RC-54", 2012 },
                    { new Guid("47044726-764c-4693-8d15-2b6263098afe"), "514-NWE", 2012 },
                    { new Guid("ea1130b3-a4a5-4a82-8a62-2edbbd5d4c2f"), "KGN36S55", 2014 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DefaultQuantity", "Name" },
                values: new object[,]
                {
                    { new Guid("17bd2365-8b3e-4bff-b085-af10b3090af7"), 15, "Raspberry" },
                    { new Guid("85171e2e-e345-4672-a601-c89db24416b8"), 11, "Cherry" },
                    { new Guid("da64b838-55a3-4795-bbdb-63c5a127138d"), 17, "Grape" },
                    { new Guid("88ced146-bc51-4721-b387-51102f762a29"), 16, "Lemon" },
                    { new Guid("ac2e1d87-6d43-41f4-9de0-e8335859ea28"), 5, "Orange" },
                    { new Guid("f061eebe-a621-46c1-b90a-5650b6da0bc1"), 17, "Peach" },
                    { new Guid("3b45cd36-84fe-40f8-bb88-878f7e7b98dd"), 15, "Strawberry" },
                    { new Guid("90233476-dfbc-4a8a-9fcd-7bd5db837e49"), 14, "Watermelon" },
                    { new Guid("3f61ea20-8bb9-43b8-a23e-917e357fdde5"), 15, "Jelly" },
                    { new Guid("020b716b-a53a-47e5-9f0e-f4c0c247401a"), 6, "Milk" },
                    { new Guid("166a5eb4-c256-451a-ad7f-82ad80dd3f33"), 12, "Kefir" },
                    { new Guid("7e68c46e-8e30-4b99-8a74-ca596d061c74"), 5, "Chocolate" },
                    { new Guid("5d7be9c1-420b-40d0-a1bb-ca26de63d7da"), 11, "Jam" },
                    { new Guid("defcfda3-0fe2-477d-988c-ba257d2d849a"), 16, "Pudding" },
                    { new Guid("27cb5b9b-65ec-4d00-bce7-af83fabbefaf"), 11, "Banana" },
                    { new Guid("f77a6a20-d538-4755-b10b-d0c395fb6219"), 8, "Pancake" },
                    { new Guid("f3cfb7eb-73a2-4efd-926a-28ba1681e266"), 7, "Butter" },
                    { new Guid("57490060-0056-45ac-8f14-9e29edcfcfc6"), 11, "Potato" },
                    { new Guid("49e1519d-c3cd-4a03-bf94-253576f33449"), 14, "Avocado" },
                    { new Guid("e2275239-c3ac-4458-8dcc-98fcea075b03"), 13, "Onion" },
                    { new Guid("ad2efb0a-d7ec-4af9-a850-b600a2456092"), 8, "Bread" },
                    { new Guid("51afc043-bed8-48ef-b341-07df74a5edb1"), 11, "Apple" },
                    { new Guid("6cd53e71-a6ed-44b3-9b66-7a5f034eeb7b"), 8, "Yoghurt" },
                    { new Guid("c6a16a35-4bd5-47af-8be2-ce6e67369164"), 8, "Egg" },
                    { new Guid("f14ae0df-8998-4357-976b-6631b1e73955"), 14, "Cheese" },
                    { new Guid("4324a8bd-d767-46ed-9fb1-acff5c486cb7"), 5, "Mashroom" },
                    { new Guid("3a78216a-5fdf-498f-bee3-2df26e06403c"), 5, "Chicken" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DefaultQuantity", "Name" },
                values: new object[,]
                {
                    { new Guid("5dd24c06-902d-4075-b627-7c55c3ad9812"), 5, "Garlic" },
                    { new Guid("801607cf-45a8-4e7a-94fa-04803a5d209e"), 11, "Pork" },
                    { new Guid("c8feda3c-1f76-4340-9fb4-2579fda93105"), 15, "Sausage" },
                    { new Guid("82c4e799-d501-4f93-9c2c-bf44d0b32391"), 8, "Fish" },
                    { new Guid("15b22668-cc50-4874-815f-e444232662ab"), 7, "Juice" },
                    { new Guid("fe2ca603-3208-4718-98aa-c527cd8d14c5"), 14, "Broccoli" },
                    { new Guid("fb22f051-4279-4955-80e1-1ad224e8e994"), 14, "Beans" },
                    { new Guid("b239631e-1c30-43d9-b7b0-9230e466ab03"), 7, "Carrot" },
                    { new Guid("d053265d-b8b0-4bec-91c3-84c35886f881"), 13, "Cucumber" },
                    { new Guid("06195ab6-b6f4-4b6b-97df-2c6a1e530f23"), 17, "Beef" },
                    { new Guid("9f07e2ef-9525-4313-ae7f-0ba07d0c6c9a"), 7, "Soda" }
                });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "Id", "FridgeModelId", "Name", "OwnerName" },
                values: new object[,]
                {
                    { new Guid("c772c540-a0db-4136-be6c-c82faa150754"), new Guid("47044726-764c-4693-8d15-2b6263098afe"), "Stinol", "Vlada" },
                    { new Guid("9c2c4873-b586-43b0-86ac-7099d7c60937"), new Guid("1efdc335-b487-4c54-af0a-8cdf69fc0779"), "Bosch", "Dima" },
                    { new Guid("6935abcb-47c6-4fc3-a590-0a440b129ad3"), new Guid("235ceca3-3827-4dfc-b209-bb3b214c4cf6"), "Indesit", "Anna" },
                    { new Guid("ac4a387a-a149-4d75-bb6c-93b98e03bf0c"), new Guid("4fe91723-603f-4c30-9779-144fc5437d8b"), "Vestfrost", "Anna" },
                    { new Guid("aeef0916-92a9-44f9-b0fd-34019812c0f0"), new Guid("4d66b102-b242-4d9c-a52a-18cafb1a5169"), "Philips", "Vlada" }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("e806f19d-b3db-477f-bb7a-a2af1e2c5c16"), new Guid("c772c540-a0db-4136-be6c-c82faa150754"), new Guid("5dd24c06-902d-4075-b627-7c55c3ad9812"), 0 },
                    { new Guid("0ab13cd8-d345-4e11-9793-416c8573ea0d"), new Guid("ac4a387a-a149-4d75-bb6c-93b98e03bf0c"), new Guid("c8feda3c-1f76-4340-9fb4-2579fda93105"), 19 },
                    { new Guid("77f1a72a-5132-4445-84bb-95076ca3ed4f"), new Guid("ac4a387a-a149-4d75-bb6c-93b98e03bf0c"), new Guid("51afc043-bed8-48ef-b341-07df74a5edb1"), 8 },
                    { new Guid("cdc1c4df-e5b7-4dc0-84a9-164d8098b6a2"), new Guid("ac4a387a-a149-4d75-bb6c-93b98e03bf0c"), new Guid("82c4e799-d501-4f93-9c2c-bf44d0b32391"), 25 },
                    { new Guid("aa5478db-afba-4b66-9ba4-113f7cace7ec"), new Guid("ac4a387a-a149-4d75-bb6c-93b98e03bf0c"), new Guid("ad2efb0a-d7ec-4af9-a850-b600a2456092"), 1 },
                    { new Guid("ef653170-c8b0-47e2-8ff2-6a5e4033b377"), new Guid("ac4a387a-a149-4d75-bb6c-93b98e03bf0c"), new Guid("166a5eb4-c256-451a-ad7f-82ad80dd3f33"), 62 },
                    { new Guid("eb027ae3-02d8-43c2-9fb1-c8e9c71b0ea3"), new Guid("ac4a387a-a149-4d75-bb6c-93b98e03bf0c"), new Guid("d053265d-b8b0-4bec-91c3-84c35886f881"), 74 },
                    { new Guid("ea497486-cafb-454f-843c-19e0dafc4ff0"), new Guid("ac4a387a-a149-4d75-bb6c-93b98e03bf0c"), new Guid("fb22f051-4279-4955-80e1-1ad224e8e994"), 59 },
                    { new Guid("6d7463ef-1d98-450c-be09-57c1b7ae784a"), new Guid("ac4a387a-a149-4d75-bb6c-93b98e03bf0c"), new Guid("b239631e-1c30-43d9-b7b0-9230e466ab03"), 56 },
                    { new Guid("cc3e9fb9-6b6d-4f1e-901f-094cb1a06661"), new Guid("ac4a387a-a149-4d75-bb6c-93b98e03bf0c"), new Guid("f77a6a20-d538-4755-b10b-d0c395fb6219"), 78 },
                    { new Guid("e4ede72e-fcdc-44db-8f23-18e09f27ae54"), new Guid("ac4a387a-a149-4d75-bb6c-93b98e03bf0c"), new Guid("defcfda3-0fe2-477d-988c-ba257d2d849a"), 87 },
                    { new Guid("6e0eb14f-9aab-4f39-9211-796e7073166a"), new Guid("ac4a387a-a149-4d75-bb6c-93b98e03bf0c"), new Guid("f3cfb7eb-73a2-4efd-926a-28ba1681e266"), 34 },
                    { new Guid("a60ae84c-2346-43ad-ab67-8ae928f48b0c"), new Guid("ac4a387a-a149-4d75-bb6c-93b98e03bf0c"), new Guid("020b716b-a53a-47e5-9f0e-f4c0c247401a"), 65 },
                    { new Guid("c2c2d490-0ade-45ba-96d9-486472b91e18"), new Guid("ac4a387a-a149-4d75-bb6c-93b98e03bf0c"), new Guid("49e1519d-c3cd-4a03-bf94-253576f33449"), 40 },
                    { new Guid("6f3e61cf-2b7a-4f93-be2a-c7e5dd9990c3"), new Guid("ac4a387a-a149-4d75-bb6c-93b98e03bf0c"), new Guid("fe2ca603-3208-4718-98aa-c527cd8d14c5"), 62 },
                    { new Guid("393a8ffb-8a3a-41ce-b9a0-ee0c657451ee"), new Guid("ac4a387a-a149-4d75-bb6c-93b98e03bf0c"), new Guid("06195ab6-b6f4-4b6b-97df-2c6a1e530f23"), 32 },
                    { new Guid("3c2b0246-207f-4477-b155-7580261c982e"), new Guid("ac4a387a-a149-4d75-bb6c-93b98e03bf0c"), new Guid("7e68c46e-8e30-4b99-8a74-ca596d061c74"), 66 },
                    { new Guid("1c8e2eec-fbcd-46b0-bce2-67fad2456753"), new Guid("ac4a387a-a149-4d75-bb6c-93b98e03bf0c"), new Guid("f14ae0df-8998-4357-976b-6631b1e73955"), 10 },
                    { new Guid("e65ff6a4-da34-4b38-9cf7-4491ed825f8e"), new Guid("6935abcb-47c6-4fc3-a590-0a440b129ad3"), new Guid("90233476-dfbc-4a8a-9fcd-7bd5db837e49"), 3 },
                    { new Guid("0f821966-dc92-47f8-bbf4-7dbdc534a98d"), new Guid("6935abcb-47c6-4fc3-a590-0a440b129ad3"), new Guid("3b45cd36-84fe-40f8-bb88-878f7e7b98dd"), 3 },
                    { new Guid("0cd71a3d-fb27-4740-b805-6636237642f5"), new Guid("6935abcb-47c6-4fc3-a590-0a440b129ad3"), new Guid("3a78216a-5fdf-498f-bee3-2df26e06403c"), 10 },
                    { new Guid("a96095bb-f53c-4c35-8a5f-a8fd0f4f31be"), new Guid("6935abcb-47c6-4fc3-a590-0a440b129ad3"), new Guid("85171e2e-e345-4672-a601-c89db24416b8"), 31 },
                    { new Guid("3ae91d16-67d0-4ef6-86e6-a0fcfd4817ff"), new Guid("6935abcb-47c6-4fc3-a590-0a440b129ad3"), new Guid("6cd53e71-a6ed-44b3-9b66-7a5f034eeb7b"), 8 },
                    { new Guid("c4a46699-5024-48e4-95dc-72a6345df295"), new Guid("6935abcb-47c6-4fc3-a590-0a440b129ad3"), new Guid("e2275239-c3ac-4458-8dcc-98fcea075b03"), 59 },
                    { new Guid("4c32d3be-207b-4d17-82a4-ad7f40ce57b9"), new Guid("6935abcb-47c6-4fc3-a590-0a440b129ad3"), new Guid("defcfda3-0fe2-477d-988c-ba257d2d849a"), 37 },
                    { new Guid("a94b2e5b-f9e1-41a2-9a79-e7856e1b55da"), new Guid("6935abcb-47c6-4fc3-a590-0a440b129ad3"), new Guid("9f07e2ef-9525-4313-ae7f-0ba07d0c6c9a"), 8 },
                    { new Guid("55800bd1-9187-45b0-b39c-e87f9084dc5f"), new Guid("ac4a387a-a149-4d75-bb6c-93b98e03bf0c"), new Guid("5d7be9c1-420b-40d0-a1bb-ca26de63d7da"), 53 },
                    { new Guid("b6a1543f-82be-4db3-a791-5ee10a5ecba4"), new Guid("ac4a387a-a149-4d75-bb6c-93b98e03bf0c"), new Guid("27cb5b9b-65ec-4d00-bce7-af83fabbefaf"), 7 },
                    { new Guid("5421c6d3-ad65-4a1b-92e6-c97ca15a0edd"), new Guid("ac4a387a-a149-4d75-bb6c-93b98e03bf0c"), new Guid("5dd24c06-902d-4075-b627-7c55c3ad9812"), 21 },
                    { new Guid("84e5919e-cca0-4eb5-a398-f1c7130d20e6"), new Guid("ac4a387a-a149-4d75-bb6c-93b98e03bf0c"), new Guid("3f61ea20-8bb9-43b8-a23e-917e357fdde5"), 78 },
                    { new Guid("8dde9bb8-8528-4cb8-a1a8-2393600560d5"), new Guid("aeef0916-92a9-44f9-b0fd-34019812c0f0"), new Guid("f061eebe-a621-46c1-b90a-5650b6da0bc1"), 19 },
                    { new Guid("6d91fc3d-e5e3-4edf-99d3-4b155934d027"), new Guid("aeef0916-92a9-44f9-b0fd-34019812c0f0"), new Guid("020b716b-a53a-47e5-9f0e-f4c0c247401a"), 22 },
                    { new Guid("35d5c0a0-50f4-43fc-b08d-a917053d9c87"), new Guid("aeef0916-92a9-44f9-b0fd-34019812c0f0"), new Guid("f14ae0df-8998-4357-976b-6631b1e73955"), 25 },
                    { new Guid("da29bd10-1fce-44c4-bd59-57d374d3e9c2"), new Guid("aeef0916-92a9-44f9-b0fd-34019812c0f0"), new Guid("f3cfb7eb-73a2-4efd-926a-28ba1681e266"), 26 },
                    { new Guid("2daeb28c-ea38-4e81-b7e3-675b80ea38d2"), new Guid("aeef0916-92a9-44f9-b0fd-34019812c0f0"), new Guid("5d7be9c1-420b-40d0-a1bb-ca26de63d7da"), 12 },
                    { new Guid("368f4db3-6ec8-43a5-92fc-757f81898e42"), new Guid("aeef0916-92a9-44f9-b0fd-34019812c0f0"), new Guid("49e1519d-c3cd-4a03-bf94-253576f33449"), 1 },
                    { new Guid("93ae7f0b-1d3a-442d-995b-5b6c8f9515d2"), new Guid("aeef0916-92a9-44f9-b0fd-34019812c0f0"), new Guid("57490060-0056-45ac-8f14-9e29edcfcfc6"), 7 },
                    { new Guid("2eeabb1d-ccf8-4299-9d27-5c106fcdba06"), new Guid("aeef0916-92a9-44f9-b0fd-34019812c0f0"), new Guid("06195ab6-b6f4-4b6b-97df-2c6a1e530f23"), 15 },
                    { new Guid("73b483fa-5323-4b68-8170-6ed14248833f"), new Guid("aeef0916-92a9-44f9-b0fd-34019812c0f0"), new Guid("da64b838-55a3-4795-bbdb-63c5a127138d"), 9 },
                    { new Guid("e1c3e4e9-d9c0-41ce-8bc6-d71edcd3033d"), new Guid("aeef0916-92a9-44f9-b0fd-34019812c0f0"), new Guid("801607cf-45a8-4e7a-94fa-04803a5d209e"), 30 },
                    { new Guid("f767f17c-2e9d-45d0-ae11-d90caf6eaa1a"), new Guid("aeef0916-92a9-44f9-b0fd-34019812c0f0"), new Guid("ac2e1d87-6d43-41f4-9de0-e8335859ea28"), 44 },
                    { new Guid("72334641-8157-4fc2-923a-cc14013e623a"), new Guid("aeef0916-92a9-44f9-b0fd-34019812c0f0"), new Guid("88ced146-bc51-4721-b387-51102f762a29"), 43 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("5bc564e2-b558-4a5e-9a1c-75704a663f1c"), new Guid("6935abcb-47c6-4fc3-a590-0a440b129ad3"), new Guid("7e68c46e-8e30-4b99-8a74-ca596d061c74"), 21 },
                    { new Guid("4bcb2a71-d7f9-4a31-8ec1-2c90974dc9e0"), new Guid("aeef0916-92a9-44f9-b0fd-34019812c0f0"), new Guid("6cd53e71-a6ed-44b3-9b66-7a5f034eeb7b"), 27 },
                    { new Guid("05813bc1-99f6-4f2d-b4b8-a332c3d5afb0"), new Guid("aeef0916-92a9-44f9-b0fd-34019812c0f0"), new Guid("e2275239-c3ac-4458-8dcc-98fcea075b03"), 13 },
                    { new Guid("bd7d3bed-9b61-4180-9b87-9d2f3ab94aca"), new Guid("aeef0916-92a9-44f9-b0fd-34019812c0f0"), new Guid("3a78216a-5fdf-498f-bee3-2df26e06403c"), 34 },
                    { new Guid("f533efe2-d564-4b46-af02-8f74c68c2c4e"), new Guid("aeef0916-92a9-44f9-b0fd-34019812c0f0"), new Guid("90233476-dfbc-4a8a-9fcd-7bd5db837e49"), 25 },
                    { new Guid("be5c72c6-e4fd-400f-8a75-2294450a5161"), new Guid("aeef0916-92a9-44f9-b0fd-34019812c0f0"), new Guid("c8feda3c-1f76-4340-9fb4-2579fda93105"), 29 },
                    { new Guid("b8a66ea3-43be-4215-a0e4-a2e10ec770c6"), new Guid("aeef0916-92a9-44f9-b0fd-34019812c0f0"), new Guid("3b45cd36-84fe-40f8-bb88-878f7e7b98dd"), 59 },
                    { new Guid("17423dad-a4cc-4bff-8d48-8c2fe8e92443"), new Guid("aeef0916-92a9-44f9-b0fd-34019812c0f0"), new Guid("17bd2365-8b3e-4bff-b085-af10b3090af7"), 64 },
                    { new Guid("9091cc56-970c-4b33-a56b-50b509ba9c92"), new Guid("aeef0916-92a9-44f9-b0fd-34019812c0f0"), new Guid("82c4e799-d501-4f93-9c2c-bf44d0b32391"), 22 },
                    { new Guid("d49a8ab7-8965-4505-94ad-62c3f88583b9"), new Guid("ac4a387a-a149-4d75-bb6c-93b98e03bf0c"), new Guid("e2275239-c3ac-4458-8dcc-98fcea075b03"), 20 },
                    { new Guid("6c1d5a29-2c50-4086-a6fe-618fa41d7570"), new Guid("ac4a387a-a149-4d75-bb6c-93b98e03bf0c"), new Guid("c6a16a35-4bd5-47af-8be2-ce6e67369164"), 8 },
                    { new Guid("2211b95a-78ff-4fde-b954-dcc1a6d51605"), new Guid("ac4a387a-a149-4d75-bb6c-93b98e03bf0c"), new Guid("f061eebe-a621-46c1-b90a-5650b6da0bc1"), 2 },
                    { new Guid("0167e4d1-152e-4130-8060-1286c1c35c03"), new Guid("ac4a387a-a149-4d75-bb6c-93b98e03bf0c"), new Guid("17bd2365-8b3e-4bff-b085-af10b3090af7"), 10 },
                    { new Guid("0961517a-9920-4f08-80b9-6ba5191df6c6"), new Guid("ac4a387a-a149-4d75-bb6c-93b98e03bf0c"), new Guid("15b22668-cc50-4874-815f-e444232662ab"), 7 },
                    { new Guid("d7d3ce03-6182-48ee-8323-f31da53acf38"), new Guid("aeef0916-92a9-44f9-b0fd-34019812c0f0"), new Guid("4324a8bd-d767-46ed-9fb1-acff5c486cb7"), 30 },
                    { new Guid("e6b85c96-802d-4878-9c7e-3acd32e37984"), new Guid("aeef0916-92a9-44f9-b0fd-34019812c0f0"), new Guid("c6a16a35-4bd5-47af-8be2-ce6e67369164"), 11 },
                    { new Guid("c0a7d415-28f8-4652-8b74-54d5dde96806"), new Guid("6935abcb-47c6-4fc3-a590-0a440b129ad3"), new Guid("fb22f051-4279-4955-80e1-1ad224e8e994"), 18 },
                    { new Guid("3591cdc6-0b2e-445e-9b89-d13ff3dc396c"), new Guid("6935abcb-47c6-4fc3-a590-0a440b129ad3"), new Guid("020b716b-a53a-47e5-9f0e-f4c0c247401a"), 12 },
                    { new Guid("e77c2d3e-7aa6-45e5-9bd4-92e7d58f1d2d"), new Guid("9c2c4873-b586-43b0-86ac-7099d7c60937"), new Guid("90233476-dfbc-4a8a-9fcd-7bd5db837e49"), 21 },
                    { new Guid("d6b99f5a-6e9e-4164-ac47-9fd8b7a36747"), new Guid("9c2c4873-b586-43b0-86ac-7099d7c60937"), new Guid("17bd2365-8b3e-4bff-b085-af10b3090af7"), 62 },
                    { new Guid("97dc5f4d-e71f-4c60-8f19-6aaa50752bc7"), new Guid("9c2c4873-b586-43b0-86ac-7099d7c60937"), new Guid("6cd53e71-a6ed-44b3-9b66-7a5f034eeb7b"), 2 },
                    { new Guid("9782afea-8684-4b79-b2d6-f5a023108e86"), new Guid("9c2c4873-b586-43b0-86ac-7099d7c60937"), new Guid("7e68c46e-8e30-4b99-8a74-ca596d061c74"), 18 },
                    { new Guid("c45f2a80-a433-4b90-93c1-06d2738be844"), new Guid("9c2c4873-b586-43b0-86ac-7099d7c60937"), new Guid("f3cfb7eb-73a2-4efd-926a-28ba1681e266"), 37 },
                    { new Guid("92fa1f64-7822-443d-aade-c26d96ca2355"), new Guid("9c2c4873-b586-43b0-86ac-7099d7c60937"), new Guid("c8feda3c-1f76-4340-9fb4-2579fda93105"), 47 },
                    { new Guid("56f711ce-3087-4237-8042-7ef62b17eb96"), new Guid("c772c540-a0db-4136-be6c-c82faa150754"), new Guid("51afc043-bed8-48ef-b341-07df74a5edb1"), 29 },
                    { new Guid("921819c5-f5c5-4d67-aaa3-a6788723e2de"), new Guid("c772c540-a0db-4136-be6c-c82faa150754"), new Guid("4324a8bd-d767-46ed-9fb1-acff5c486cb7"), 61 },
                    { new Guid("20758882-9154-45f1-ad90-0111be01e629"), new Guid("c772c540-a0db-4136-be6c-c82faa150754"), new Guid("fb22f051-4279-4955-80e1-1ad224e8e994"), 12 },
                    { new Guid("aeca6956-41fc-4351-b2b3-80d46d536715"), new Guid("c772c540-a0db-4136-be6c-c82faa150754"), new Guid("27cb5b9b-65ec-4d00-bce7-af83fabbefaf"), 16 },
                    { new Guid("cab284e1-5caa-46cf-b5bc-4d1782a7d017"), new Guid("c772c540-a0db-4136-be6c-c82faa150754"), new Guid("88ced146-bc51-4721-b387-51102f762a29"), 40 },
                    { new Guid("ad0e7292-f045-476f-ae1d-d9afdc10b98c"), new Guid("c772c540-a0db-4136-be6c-c82faa150754"), new Guid("f77a6a20-d538-4755-b10b-d0c395fb6219"), 13 },
                    { new Guid("b7d12c02-6d9d-4a64-87c6-ae6cd913c366"), new Guid("c772c540-a0db-4136-be6c-c82faa150754"), new Guid("57490060-0056-45ac-8f14-9e29edcfcfc6"), 48 },
                    { new Guid("666f6aa2-890c-4308-a929-ec741dfc256b"), new Guid("c772c540-a0db-4136-be6c-c82faa150754"), new Guid("ac2e1d87-6d43-41f4-9de0-e8335859ea28"), 35 },
                    { new Guid("34d36c68-0222-4b62-b931-a0a2cd03f347"), new Guid("c772c540-a0db-4136-be6c-c82faa150754"), new Guid("6cd53e71-a6ed-44b3-9b66-7a5f034eeb7b"), 36 },
                    { new Guid("7c4b718f-d34d-467a-9c74-c2674bd71c50"), new Guid("c772c540-a0db-4136-be6c-c82faa150754"), new Guid("49e1519d-c3cd-4a03-bf94-253576f33449"), 5 },
                    { new Guid("53927161-62be-4c79-a04b-aee9668d7e3a"), new Guid("c772c540-a0db-4136-be6c-c82faa150754"), new Guid("15b22668-cc50-4874-815f-e444232662ab"), 34 },
                    { new Guid("49b0982c-66d5-461b-a9e8-287c66557536"), new Guid("c772c540-a0db-4136-be6c-c82faa150754"), new Guid("f14ae0df-8998-4357-976b-6631b1e73955"), 26 },
                    { new Guid("0b84cd61-ea04-4c10-99d9-e43363c743c2"), new Guid("c772c540-a0db-4136-be6c-c82faa150754"), new Guid("85171e2e-e345-4672-a601-c89db24416b8"), 26 },
                    { new Guid("a2abb796-938c-49bd-95ba-394888db6656"), new Guid("c772c540-a0db-4136-be6c-c82faa150754"), new Guid("da64b838-55a3-4795-bbdb-63c5a127138d"), 35 },
                    { new Guid("41f9bb48-5816-43be-b946-b5f409a89260"), new Guid("c772c540-a0db-4136-be6c-c82faa150754"), new Guid("9f07e2ef-9525-4313-ae7f-0ba07d0c6c9a"), 33 },
                    { new Guid("49f75b76-8877-45d7-8b0c-b6a84c120cfb"), new Guid("c772c540-a0db-4136-be6c-c82faa150754"), new Guid("c6a16a35-4bd5-47af-8be2-ce6e67369164"), 46 },
                    { new Guid("769b5ca3-7ba7-4f01-bd76-b300cfe7d57d"), new Guid("c772c540-a0db-4136-be6c-c82faa150754"), new Guid("f061eebe-a621-46c1-b90a-5650b6da0bc1"), 29 },
                    { new Guid("f4061df7-137d-420d-b370-90734c8423d2"), new Guid("c772c540-a0db-4136-be6c-c82faa150754"), new Guid("3b45cd36-84fe-40f8-bb88-878f7e7b98dd"), 16 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("233bf640-f6e1-457c-861a-f18ada293bb9"), new Guid("c772c540-a0db-4136-be6c-c82faa150754"), new Guid("ad2efb0a-d7ec-4af9-a850-b600a2456092"), 17 },
                    { new Guid("d22b103c-6844-4906-a956-8381fa3c4857"), new Guid("9c2c4873-b586-43b0-86ac-7099d7c60937"), new Guid("06195ab6-b6f4-4b6b-97df-2c6a1e530f23"), 54 },
                    { new Guid("5d620b6e-0f89-4d93-9df3-e4101de7cd5c"), new Guid("9c2c4873-b586-43b0-86ac-7099d7c60937"), new Guid("020b716b-a53a-47e5-9f0e-f4c0c247401a"), 39 },
                    { new Guid("57892470-cb51-4fab-bb69-9d060d87059c"), new Guid("9c2c4873-b586-43b0-86ac-7099d7c60937"), new Guid("ad2efb0a-d7ec-4af9-a850-b600a2456092"), 1 },
                    { new Guid("bc123cb3-2b84-4be6-a381-94287377c3ae"), new Guid("9c2c4873-b586-43b0-86ac-7099d7c60937"), new Guid("166a5eb4-c256-451a-ad7f-82ad80dd3f33"), 8 },
                    { new Guid("afc900b0-6f8c-4a47-ac1c-5defe482b324"), new Guid("6935abcb-47c6-4fc3-a590-0a440b129ad3"), new Guid("b239631e-1c30-43d9-b7b0-9230e466ab03"), 60 },
                    { new Guid("5227a8bc-243d-4e9a-95ce-b117af68f644"), new Guid("6935abcb-47c6-4fc3-a590-0a440b129ad3"), new Guid("5d7be9c1-420b-40d0-a1bb-ca26de63d7da"), 41 },
                    { new Guid("887eed1b-ad68-44b1-8c68-daff4f1a0138"), new Guid("6935abcb-47c6-4fc3-a590-0a440b129ad3"), new Guid("5dd24c06-902d-4075-b627-7c55c3ad9812"), 34 },
                    { new Guid("d47f28f5-4b27-4e1a-b751-31e82b105622"), new Guid("6935abcb-47c6-4fc3-a590-0a440b129ad3"), new Guid("57490060-0056-45ac-8f14-9e29edcfcfc6"), 7 },
                    { new Guid("d8b6b54b-f247-492f-8aa4-e6b7bf542297"), new Guid("6935abcb-47c6-4fc3-a590-0a440b129ad3"), new Guid("15b22668-cc50-4874-815f-e444232662ab"), 28 },
                    { new Guid("eea0118b-c19f-4910-9032-5e92298fe07b"), new Guid("6935abcb-47c6-4fc3-a590-0a440b129ad3"), new Guid("d053265d-b8b0-4bec-91c3-84c35886f881"), 64 },
                    { new Guid("bd48faa6-0841-4b88-b050-f169fa481caa"), new Guid("6935abcb-47c6-4fc3-a590-0a440b129ad3"), new Guid("51afc043-bed8-48ef-b341-07df74a5edb1"), 26 },
                    { new Guid("4d1d1e0c-3c47-498a-8374-3d3fb5abcccc"), new Guid("6935abcb-47c6-4fc3-a590-0a440b129ad3"), new Guid("3f61ea20-8bb9-43b8-a23e-917e357fdde5"), 32 },
                    { new Guid("6a798937-24f3-4e44-ba4a-0bd0f5d88ba0"), new Guid("6935abcb-47c6-4fc3-a590-0a440b129ad3"), new Guid("4324a8bd-d767-46ed-9fb1-acff5c486cb7"), 9 },
                    { new Guid("613bf49a-c99d-4495-aaf3-c8b71dbf90f4"), new Guid("6935abcb-47c6-4fc3-a590-0a440b129ad3"), new Guid("f77a6a20-d538-4755-b10b-d0c395fb6219"), 63 },
                    { new Guid("cbbf2b4a-db34-49b9-b112-2c6644b3a528"), new Guid("6935abcb-47c6-4fc3-a590-0a440b129ad3"), new Guid("27cb5b9b-65ec-4d00-bce7-af83fabbefaf"), 17 },
                    { new Guid("e963563b-e63c-45e3-8ffd-41b772d79899"), new Guid("9c2c4873-b586-43b0-86ac-7099d7c60937"), new Guid("ac2e1d87-6d43-41f4-9de0-e8335859ea28"), 9 },
                    { new Guid("ee2e7429-be91-429b-9bc6-a56239831c28"), new Guid("6935abcb-47c6-4fc3-a590-0a440b129ad3"), new Guid("ad2efb0a-d7ec-4af9-a850-b600a2456092"), 21 },
                    { new Guid("133bd50d-93a8-4581-99cf-5a9909eaafd9"), new Guid("9c2c4873-b586-43b0-86ac-7099d7c60937"), new Guid("5d7be9c1-420b-40d0-a1bb-ca26de63d7da"), 5 },
                    { new Guid("49c39678-da3a-41b6-861e-8906d773f539"), new Guid("9c2c4873-b586-43b0-86ac-7099d7c60937"), new Guid("fe2ca603-3208-4718-98aa-c527cd8d14c5"), 23 },
                    { new Guid("3984d128-d675-42c3-833b-6040b0ff4977"), new Guid("9c2c4873-b586-43b0-86ac-7099d7c60937"), new Guid("defcfda3-0fe2-477d-988c-ba257d2d849a"), 13 },
                    { new Guid("057946fd-bddc-4a0b-8d06-58728df4d47d"), new Guid("9c2c4873-b586-43b0-86ac-7099d7c60937"), new Guid("27cb5b9b-65ec-4d00-bce7-af83fabbefaf"), 8 },
                    { new Guid("69337d62-3be8-432d-9120-b889c73a173d"), new Guid("9c2c4873-b586-43b0-86ac-7099d7c60937"), new Guid("801607cf-45a8-4e7a-94fa-04803a5d209e"), 11 },
                    { new Guid("4efded77-fa5b-46dc-a6e0-d51cd5ef1e48"), new Guid("9c2c4873-b586-43b0-86ac-7099d7c60937"), new Guid("fb22f051-4279-4955-80e1-1ad224e8e994"), 34 },
                    { new Guid("30f11be6-d0bf-414b-b79d-784721c81216"), new Guid("9c2c4873-b586-43b0-86ac-7099d7c60937"), new Guid("49e1519d-c3cd-4a03-bf94-253576f33449"), 44 },
                    { new Guid("e5697554-cc32-4d3f-b47d-fadcfb18c4b7"), new Guid("9c2c4873-b586-43b0-86ac-7099d7c60937"), new Guid("f061eebe-a621-46c1-b90a-5650b6da0bc1"), 14 },
                    { new Guid("70d3286d-e401-4632-aa3c-d45b1cdff191"), new Guid("9c2c4873-b586-43b0-86ac-7099d7c60937"), new Guid("4324a8bd-d767-46ed-9fb1-acff5c486cb7"), 8 },
                    { new Guid("93c41262-539b-4344-8a66-33f4d919bf6d"), new Guid("9c2c4873-b586-43b0-86ac-7099d7c60937"), new Guid("9f07e2ef-9525-4313-ae7f-0ba07d0c6c9a"), 12 },
                    { new Guid("89b8ce61-64f9-420a-97c2-ea9f1fd20e36"), new Guid("9c2c4873-b586-43b0-86ac-7099d7c60937"), new Guid("3a78216a-5fdf-498f-bee3-2df26e06403c"), 80 },
                    { new Guid("40491857-7fa0-4638-a366-d4aa09802b10"), new Guid("9c2c4873-b586-43b0-86ac-7099d7c60937"), new Guid("82c4e799-d501-4f93-9c2c-bf44d0b32391"), 34 },
                    { new Guid("16cc0dc6-2e21-497c-a3ce-dada383e1ca3"), new Guid("9c2c4873-b586-43b0-86ac-7099d7c60937"), new Guid("3b45cd36-84fe-40f8-bb88-878f7e7b98dd"), 35 },
                    { new Guid("e542a4fb-f9a6-453b-8e1d-82153f2068d2"), new Guid("9c2c4873-b586-43b0-86ac-7099d7c60937"), new Guid("f14ae0df-8998-4357-976b-6631b1e73955"), 9 },
                    { new Guid("185e8d62-4099-4398-8c4e-3b2fdfa73725"), new Guid("aeef0916-92a9-44f9-b0fd-34019812c0f0"), new Guid("85171e2e-e345-4672-a601-c89db24416b8"), 1 }
                });

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
                name: "FridgeProducts");

            migrationBuilder.DropTable(
                name: "Fridges");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "FridgeModels");
        }
    }
}
