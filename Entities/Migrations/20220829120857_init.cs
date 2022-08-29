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
                    { new Guid("752214f4-02d5-47b7-af7a-86dc382c1efe"), "TH-803", 2018 },
                    { new Guid("a74a43fa-b677-476e-8204-49a155f0a324"), "RSA1SHVB1", 2016 },
                    { new Guid("b6fac9bd-7e75-4cac-9e80-de203a01a184"), "VF 395-1 SBS", 2017 },
                    { new Guid("82482777-6458-4831-958b-aea7cd8e7deb"), "SBS 7212", 2016 },
                    { new Guid("e42b56c4-a764-4bd9-927a-efa2803d4959"), "Electric MR-CR46G-HS-R", 2010 },
                    { new Guid("5e92a553-fb19-4c45-934e-60eac65958dd"), "VF 910 X", 2018 },
                    { new Guid("113bdae1-155b-45e2-b62d-e197918c5c73"), "RB-34 K6220SS", 2012 },
                    { new Guid("4b065486-6925-4ca8-825b-7be2b65c051c"), "RF-61 K90407F", 2013 },
                    { new Guid("fe7ce09f-1ba5-4db3-9ac0-ad2b4ef3be28"), "VF 466 EB", 2013 },
                    { new Guid("ee3a107c-f70f-4ba5-85e3-20b057aadd23"), "DS 333020", 2013 },
                    { new Guid("4e91bf7c-3d4f-4d43-94cd-3d2a3b4dabef"), "DF 5180 W", 2018 },
                    { new Guid("cf6d697c-04a6-4213-a445-8d27fcddb7d5"), "XM 4021-000", 2012 },
                    { new Guid("b886598d-6ef5-4728-be16-884a871c6af2"), "RC-54", 2018 },
                    { new Guid("04e0b6d9-54aa-474b-b1c5-b1930e242833"), "514-NWE", 2011 },
                    { new Guid("1f3e29cf-6803-4e34-96de-3786ccd45d60"), "KGN36S55", 2014 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DefaultQuantity", "Name" },
                values: new object[,]
                {
                    { new Guid("9d7badd4-54c3-407d-a24d-c3d0ccf91225"), 5, "Raspberry" },
                    { new Guid("08969aac-4fba-4d65-935a-d9c97c654011"), 10, "Cherry" },
                    { new Guid("2d31c815-ced7-4e5a-89f1-c6733a461aab"), 11, "Grape" },
                    { new Guid("9ff4e8ca-c439-477d-900a-e1f25ca3e2dd"), 14, "Lemon" },
                    { new Guid("4762edaf-efde-42e8-a33d-bb552d05e855"), 15, "Orange" },
                    { new Guid("a4865afa-8bcd-4560-b673-598b03e8a3e5"), 16, "Peach" },
                    { new Guid("7828910e-7238-40d6-9055-572a7cecf305"), 17, "Strawberry" },
                    { new Guid("bf73d9a1-0390-4257-adae-1efb0320b6fd"), 5, "Watermelon" },
                    { new Guid("24c10ccc-63bb-4c26-b95d-2bbde2ec3912"), 11, "Jelly" },
                    { new Guid("ae6804ab-f48c-48b0-a140-9e730a22d767"), 13, "Milk" },
                    { new Guid("c67c7ccd-1560-47b5-bcc2-26c2624decdd"), 7, "Kefir" },
                    { new Guid("f55e4540-a81c-4d8a-a084-d5467372c4c8"), 15, "Chocolate" },
                    { new Guid("4f4d0ce7-a137-477c-b39e-4102b95fbb2c"), 9, "Jam" },
                    { new Guid("d1dbb921-9965-48ff-ad8a-f28a65d37a68"), 16, "Pudding" },
                    { new Guid("d032460d-cd60-4bb5-83be-9ccdb4f93253"), 10, "Banana" },
                    { new Guid("a811bb40-f419-4633-9df9-f7f73ed66931"), 5, "Pancake" },
                    { new Guid("131d32b0-48f2-400f-ad2f-6d2952b67fcb"), 12, "Butter" },
                    { new Guid("eb4de3de-f595-4c7b-ab89-90301dafad59"), 9, "Potato" },
                    { new Guid("71898d20-d3fc-49e6-b14d-fdf144cce37d"), 6, "Avocado" },
                    { new Guid("a1ea8e85-c7d1-4132-bcef-1ab04cb4299f"), 8, "Onion" },
                    { new Guid("53d2bdf1-94be-4e6f-80ae-8ce1cf42fa55"), 13, "Bread" },
                    { new Guid("18961872-e0bc-48c5-9f9d-418f9995ebd7"), 16, "Apple" },
                    { new Guid("38ed1c57-e732-4adc-a5f8-94469d6c1805"), 7, "Yoghurt" },
                    { new Guid("cc9153e0-4527-4b84-b8f0-d6ebeff5da1b"), 8, "Egg" },
                    { new Guid("6f4ffe3f-f510-493a-ad6e-2efed8bd5e2d"), 8, "Cheese" },
                    { new Guid("26d9a0e4-6e8c-4398-a566-76b6c9bfccc2"), 9, "Mashroom" },
                    { new Guid("20fb524d-979b-4ab2-b6e9-afe6ce408509"), 16, "Chicken" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DefaultQuantity", "Name" },
                values: new object[,]
                {
                    { new Guid("9f2ce497-989c-4bde-9889-150c2fd29c63"), 8, "Garlic" },
                    { new Guid("d2339776-f23d-4ee1-ac80-5d545466e526"), 10, "Pork" },
                    { new Guid("2ab2ba56-fe04-4a53-ae20-2215b7fc87b8"), 5, "Sausage" },
                    { new Guid("1317e147-39b8-4d37-b15f-07930f5c6de4"), 12, "Fish" },
                    { new Guid("e33896f0-eaeb-4f63-ae6f-12f6cb2f2552"), 6, "Juice" },
                    { new Guid("61702535-e238-4fa0-9ec0-629ccb9e99b4"), 13, "Broccoli" },
                    { new Guid("2afded9f-ac57-469c-92f4-3ed713a149e3"), 13, "Beans" },
                    { new Guid("f53d9efd-6a01-498c-b804-923e8e843d63"), 14, "Carrot" },
                    { new Guid("af629e88-9a33-49cf-a1c1-3484d71a5ea9"), 14, "Cucumber" },
                    { new Guid("88cf1bad-edb4-49f1-9206-b6a212d816d5"), 10, "Beef" },
                    { new Guid("7afc45a2-f9b7-41fa-af75-f2fbe9b3c3b7"), 14, "Soda" }
                });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "Id", "FridgeModelId", "Name", "OwnerName" },
                values: new object[,]
                {
                    { new Guid("b3361f45-f0e5-4dc3-81ac-11b7f1ba2203"), new Guid("04e0b6d9-54aa-474b-b1c5-b1930e242833"), "Beko", "Kirill" },
                    { new Guid("e9719ef1-b2c1-4c78-bdcc-7c1ac37ac3c7"), new Guid("4b065486-6925-4ca8-825b-7be2b65c051c"), "Vestfrost", "Julia" },
                    { new Guid("d7fdf207-aa20-4400-8cbf-97b13351c3ee"), new Guid("4b065486-6925-4ca8-825b-7be2b65c051c"), "Samsung", "Vlada" },
                    { new Guid("c58b5550-7887-433f-b8e9-2e38c2f27ce3"), new Guid("4b065486-6925-4ca8-825b-7be2b65c051c"), "Samsung", "Julia" },
                    { new Guid("b6471e4d-31fd-4214-8778-1b697ad3a655"), new Guid("e42b56c4-a764-4bd9-927a-efa2803d4959"), "Samsung", "Nastya" },
                    { new Guid("18d37016-b737-4115-8c27-6b046dd71ba8"), new Guid("5e92a553-fb19-4c45-934e-60eac65958dd"), "Liebherr", "Andrew" },
                    { new Guid("215c8463-e150-40ec-a6df-17fcb0d39fd6"), new Guid("113bdae1-155b-45e2-b62d-e197918c5c73"), "Philips", "Kirill" },
                    { new Guid("d5cf3d4f-2215-4e2c-b394-1b500badf74d"), new Guid("113bdae1-155b-45e2-b62d-e197918c5c73"), "Philips", "Dima" },
                    { new Guid("c60d7c0a-08b1-444a-957f-6604b1535a74"), new Guid("1f3e29cf-6803-4e34-96de-3786ccd45d60"), "Philips", "Vlada" },
                    { new Guid("f6a11456-c59a-4e93-b3c0-4d48cb03b2c3"), new Guid("1f3e29cf-6803-4e34-96de-3786ccd45d60"), "Samsung", "Vlada" },
                    { new Guid("6605e28c-3bc1-4a44-b5db-43e309e17d7a"), new Guid("1f3e29cf-6803-4e34-96de-3786ccd45d60"), "Indesit", "Dima" },
                    { new Guid("db2f2c19-7e3d-4dbe-a90c-973fbfad8e56"), new Guid("fe7ce09f-1ba5-4db3-9ac0-ad2b4ef3be28"), "Samsung", "Mariya" },
                    { new Guid("8017a3aa-c9f2-4382-afca-f22e2212e6b4"), new Guid("4e91bf7c-3d4f-4d43-94cd-3d2a3b4dabef"), "Atlant", "Polina" },
                    { new Guid("dd7763d2-3b5d-4b28-a566-399c607b4eed"), new Guid("cf6d697c-04a6-4213-a445-8d27fcddb7d5"), "Vestfrost", "Julia" },
                    { new Guid("4f4c1b3f-adc8-4ff4-902a-38e835133f6b"), new Guid("b886598d-6ef5-4728-be16-884a871c6af2"), "Indesit", "Andrew" },
                    { new Guid("bd60ad7f-dc58-4401-b094-a9b379325634"), new Guid("b886598d-6ef5-4728-be16-884a871c6af2"), "Liebherr", "Kirill" },
                    { new Guid("5be2422e-38af-4430-b63a-ab6763e637b5"), new Guid("b886598d-6ef5-4728-be16-884a871c6af2"), "Liebherr", "Andrew" },
                    { new Guid("fe5dd62b-6830-43df-b77e-2b66bfac6931"), new Guid("04e0b6d9-54aa-474b-b1c5-b1930e242833"), "Liebherr", "Kirill" },
                    { new Guid("6db7840e-63b3-41ff-9815-62074eaaf7a9"), new Guid("82482777-6458-4831-958b-aea7cd8e7deb"), "Atlant", "Polina" },
                    { new Guid("05361784-e6fe-4dcd-b4ff-6d1df45c471b"), new Guid("b6fac9bd-7e75-4cac-9e80-de203a01a184"), "Atlant", "Mariya" }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("e4ad0a2d-979e-4558-81d2-d18af65eb3f1"), new Guid("b3361f45-f0e5-4dc3-81ac-11b7f1ba2203"), new Guid("24c10ccc-63bb-4c26-b95d-2bbde2ec3912"), 13 },
                    { new Guid("d4b92969-75d2-4e22-b08a-59408ea0984d"), new Guid("215c8463-e150-40ec-a6df-17fcb0d39fd6"), new Guid("131d32b0-48f2-400f-ad2f-6d2952b67fcb"), 9 },
                    { new Guid("b48e0fb6-3557-4500-94d4-2b5c1297a830"), new Guid("215c8463-e150-40ec-a6df-17fcb0d39fd6"), new Guid("18961872-e0bc-48c5-9f9d-418f9995ebd7"), 26 },
                    { new Guid("69b3ad7a-6a4a-498f-9dd3-6752755a6a7f"), new Guid("215c8463-e150-40ec-a6df-17fcb0d39fd6"), new Guid("cc9153e0-4527-4b84-b8f0-d6ebeff5da1b"), 7 },
                    { new Guid("4249d0a6-31ea-4371-9a4d-16bddc31f2a5"), new Guid("18d37016-b737-4115-8c27-6b046dd71ba8"), new Guid("a1ea8e85-c7d1-4132-bcef-1ab04cb4299f"), 15 },
                    { new Guid("0e90dad9-dba1-4869-9085-cda92d888d69"), new Guid("18d37016-b737-4115-8c27-6b046dd71ba8"), new Guid("af629e88-9a33-49cf-a1c1-3484d71a5ea9"), 43 },
                    { new Guid("186ffd23-1da8-42f3-94aa-7e6adf5908e0"), new Guid("18d37016-b737-4115-8c27-6b046dd71ba8"), new Guid("d1dbb921-9965-48ff-ad8a-f28a65d37a68"), 23 },
                    { new Guid("8d7bb87b-c362-4bad-87a6-bf25105fa21b"), new Guid("18d37016-b737-4115-8c27-6b046dd71ba8"), new Guid("a811bb40-f419-4633-9df9-f7f73ed66931"), 28 },
                    { new Guid("674718c2-47aa-42dd-b056-477c4c547c4c"), new Guid("18d37016-b737-4115-8c27-6b046dd71ba8"), new Guid("24c10ccc-63bb-4c26-b95d-2bbde2ec3912"), 50 },
                    { new Guid("2a0231c0-e752-4e85-8b6d-c53f551eede1"), new Guid("18d37016-b737-4115-8c27-6b046dd71ba8"), new Guid("e33896f0-eaeb-4f63-ae6f-12f6cb2f2552"), 12 },
                    { new Guid("097ee252-021a-4dc5-a9c8-ef8b345d0e96"), new Guid("215c8463-e150-40ec-a6df-17fcb0d39fd6"), new Guid("7afc45a2-f9b7-41fa-af75-f2fbe9b3c3b7"), 11 },
                    { new Guid("66e576e1-5d56-4ea3-ac5b-9f11ae460552"), new Guid("18d37016-b737-4115-8c27-6b046dd71ba8"), new Guid("9f2ce497-989c-4bde-9889-150c2fd29c63"), 11 },
                    { new Guid("90bc096d-1dd7-48b8-8d9e-eff74ca1c166"), new Guid("b6471e4d-31fd-4214-8778-1b697ad3a655"), new Guid("08969aac-4fba-4d65-935a-d9c97c654011"), 7 },
                    { new Guid("7c78b65c-5ce8-4f90-a914-5221f8c71272"), new Guid("b6471e4d-31fd-4214-8778-1b697ad3a655"), new Guid("e33896f0-eaeb-4f63-ae6f-12f6cb2f2552"), 81 },
                    { new Guid("44dc05c3-c6fa-4b58-b2fc-7dd8ce030f0f"), new Guid("b6471e4d-31fd-4214-8778-1b697ad3a655"), new Guid("7afc45a2-f9b7-41fa-af75-f2fbe9b3c3b7"), 46 },
                    { new Guid("4a30a6f2-fbc3-4da6-97a0-f9bd071cdc09"), new Guid("b6471e4d-31fd-4214-8778-1b697ad3a655"), new Guid("53d2bdf1-94be-4e6f-80ae-8ce1cf42fa55"), 12 },
                    { new Guid("e1192d00-599b-470b-abb6-f40848488f7f"), new Guid("b6471e4d-31fd-4214-8778-1b697ad3a655"), new Guid("a811bb40-f419-4633-9df9-f7f73ed66931"), 27 },
                    { new Guid("346af134-5d42-47f2-92c2-072593694447"), new Guid("b6471e4d-31fd-4214-8778-1b697ad3a655"), new Guid("9f2ce497-989c-4bde-9889-150c2fd29c63"), 24 },
                    { new Guid("c893fc75-8c34-4ea0-be07-97184b755230"), new Guid("b6471e4d-31fd-4214-8778-1b697ad3a655"), new Guid("eb4de3de-f595-4c7b-ab89-90301dafad59"), 36 },
                    { new Guid("f07b320c-5944-4bd7-9bf8-bc00cb34606a"), new Guid("b6471e4d-31fd-4214-8778-1b697ad3a655"), new Guid("71898d20-d3fc-49e6-b14d-fdf144cce37d"), 10 },
                    { new Guid("efba7fa4-f42e-477a-b229-e35e4bdf607c"), new Guid("b6471e4d-31fd-4214-8778-1b697ad3a655"), new Guid("af629e88-9a33-49cf-a1c1-3484d71a5ea9"), 11 },
                    { new Guid("fbf4843d-224a-459c-bf93-374a5bad5d47"), new Guid("18d37016-b737-4115-8c27-6b046dd71ba8"), new Guid("2afded9f-ac57-469c-92f4-3ed713a149e3"), 10 },
                    { new Guid("7813fa5a-f9dd-431c-8ac2-ad9b879f5b21"), new Guid("215c8463-e150-40ec-a6df-17fcb0d39fd6"), new Guid("1317e147-39b8-4d37-b15f-07930f5c6de4"), 2 },
                    { new Guid("6fda86f1-7371-4ef4-9521-17f16039d2f6"), new Guid("215c8463-e150-40ec-a6df-17fcb0d39fd6"), new Guid("eb4de3de-f595-4c7b-ab89-90301dafad59"), 10 },
                    { new Guid("c187762b-0e0b-4342-91d4-e584f5532060"), new Guid("215c8463-e150-40ec-a6df-17fcb0d39fd6"), new Guid("2ab2ba56-fe04-4a53-ae20-2215b7fc87b8"), 9 },
                    { new Guid("4c4f1c1c-7331-428f-900c-706ea08da80a"), new Guid("c60d7c0a-08b1-444a-957f-6604b1535a74"), new Guid("9ff4e8ca-c439-477d-900a-e1f25ca3e2dd"), 13 },
                    { new Guid("0121cd59-08c0-44ef-b908-5ed05ecfa110"), new Guid("c60d7c0a-08b1-444a-957f-6604b1535a74"), new Guid("38ed1c57-e732-4adc-a5f8-94469d6c1805"), 26 },
                    { new Guid("a0aa9b9d-5978-4c23-823e-0e14c7315f81"), new Guid("c60d7c0a-08b1-444a-957f-6604b1535a74"), new Guid("cc9153e0-4527-4b84-b8f0-d6ebeff5da1b"), 0 },
                    { new Guid("9827b767-b4a0-4edc-a28d-81db695c6543"), new Guid("c60d7c0a-08b1-444a-957f-6604b1535a74"), new Guid("6f4ffe3f-f510-493a-ad6e-2efed8bd5e2d"), 57 },
                    { new Guid("f85d0271-bfc2-4d15-925f-14312a9bbdf0"), new Guid("c60d7c0a-08b1-444a-957f-6604b1535a74"), new Guid("4762edaf-efde-42e8-a33d-bb552d05e855"), 21 },
                    { new Guid("24ba2df1-adcc-412e-832a-9b87a52f1a03"), new Guid("c60d7c0a-08b1-444a-957f-6604b1535a74"), new Guid("20fb524d-979b-4ab2-b6e9-afe6ce408509"), 16 },
                    { new Guid("a541156f-9781-4158-82bb-37224f107c30"), new Guid("c60d7c0a-08b1-444a-957f-6604b1535a74"), new Guid("08969aac-4fba-4d65-935a-d9c97c654011"), 13 },
                    { new Guid("6493dec2-b801-4644-b8e3-4979035cadfb"), new Guid("d5cf3d4f-2215-4e2c-b394-1b500badf74d"), new Guid("71898d20-d3fc-49e6-b14d-fdf144cce37d"), 10 },
                    { new Guid("388dfb53-33b4-4882-9cf8-60f33cf9cfae"), new Guid("d5cf3d4f-2215-4e2c-b394-1b500badf74d"), new Guid("a1ea8e85-c7d1-4132-bcef-1ab04cb4299f"), 2 },
                    { new Guid("384035fe-76dd-4b9f-b7c5-40596029173c"), new Guid("d5cf3d4f-2215-4e2c-b394-1b500badf74d"), new Guid("ae6804ab-f48c-48b0-a140-9e730a22d767"), 9 },
                    { new Guid("8fc34847-0d68-4b5c-959b-ec814f04c9a6"), new Guid("d5cf3d4f-2215-4e2c-b394-1b500badf74d"), new Guid("2ab2ba56-fe04-4a53-ae20-2215b7fc87b8"), 13 },
                    { new Guid("4234ea5f-00a9-4721-b6d1-6a523ae9f321"), new Guid("d5cf3d4f-2215-4e2c-b394-1b500badf74d"), new Guid("1317e147-39b8-4d37-b15f-07930f5c6de4"), 4 },
                    { new Guid("c0796c58-f463-43f9-998d-2ec33fb82794"), new Guid("d5cf3d4f-2215-4e2c-b394-1b500badf74d"), new Guid("c67c7ccd-1560-47b5-bcc2-26c2624decdd"), 2 },
                    { new Guid("359ab292-573d-426d-be7b-cc5d70b81183"), new Guid("d5cf3d4f-2215-4e2c-b394-1b500badf74d"), new Guid("61702535-e238-4fa0-9ec0-629ccb9e99b4"), 7 },
                    { new Guid("eeda106d-95b4-40cb-a920-f0482caa665e"), new Guid("d5cf3d4f-2215-4e2c-b394-1b500badf74d"), new Guid("131d32b0-48f2-400f-ad2f-6d2952b67fcb"), 9 },
                    { new Guid("18690e43-4fcc-4f40-a335-7768cb54f29e"), new Guid("215c8463-e150-40ec-a6df-17fcb0d39fd6"), new Guid("2d31c815-ced7-4e5a-89f1-c6733a461aab"), 15 },
                    { new Guid("15432971-84ee-463a-b5d9-96bbfa4b5729"), new Guid("215c8463-e150-40ec-a6df-17fcb0d39fd6"), new Guid("08969aac-4fba-4d65-935a-d9c97c654011"), 6 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("fae8643b-f146-43f5-8d91-ef7a2a4027cc"), new Guid("215c8463-e150-40ec-a6df-17fcb0d39fd6"), new Guid("e33896f0-eaeb-4f63-ae6f-12f6cb2f2552"), 5 },
                    { new Guid("82e9a743-84d5-47f5-8bd5-f6aa5c0118db"), new Guid("215c8463-e150-40ec-a6df-17fcb0d39fd6"), new Guid("d032460d-cd60-4bb5-83be-9ccdb4f93253"), 62 },
                    { new Guid("a2b6644f-cdfb-4c82-b593-85830b946789"), new Guid("215c8463-e150-40ec-a6df-17fcb0d39fd6"), new Guid("c67c7ccd-1560-47b5-bcc2-26c2624decdd"), 4 },
                    { new Guid("f9949a46-02d8-4676-81b2-18585fe29b39"), new Guid("215c8463-e150-40ec-a6df-17fcb0d39fd6"), new Guid("53d2bdf1-94be-4e6f-80ae-8ce1cf42fa55"), 10 },
                    { new Guid("d6c2ffac-5d99-44dc-b686-8e24d6c23a0a"), new Guid("b6471e4d-31fd-4214-8778-1b697ad3a655"), new Guid("a1ea8e85-c7d1-4132-bcef-1ab04cb4299f"), 9 },
                    { new Guid("3a76a9a2-cd83-4721-9e44-1bc07fd3735a"), new Guid("c58b5550-7887-433f-b8e9-2e38c2f27ce3"), new Guid("7afc45a2-f9b7-41fa-af75-f2fbe9b3c3b7"), 46 },
                    { new Guid("daf59d23-8f9d-4751-9aa0-ea4907e8af2a"), new Guid("c58b5550-7887-433f-b8e9-2e38c2f27ce3"), new Guid("53d2bdf1-94be-4e6f-80ae-8ce1cf42fa55"), 102 },
                    { new Guid("c69ad99f-aa01-4806-b96d-994d668dcad9"), new Guid("c58b5550-7887-433f-b8e9-2e38c2f27ce3"), new Guid("9f2ce497-989c-4bde-9889-150c2fd29c63"), 5 },
                    { new Guid("127d7e15-53bc-4779-bb94-072e9bf41446"), new Guid("e9719ef1-b2c1-4c78-bdcc-7c1ac37ac3c7"), new Guid("a811bb40-f419-4633-9df9-f7f73ed66931"), 15 },
                    { new Guid("a080e22b-a9c0-4d31-aa6f-ad0f11566c06"), new Guid("e9719ef1-b2c1-4c78-bdcc-7c1ac37ac3c7"), new Guid("53d2bdf1-94be-4e6f-80ae-8ce1cf42fa55"), 13 },
                    { new Guid("7e926294-d7ee-47d2-986b-67e4b4c4d437"), new Guid("6db7840e-63b3-41ff-9815-62074eaaf7a9"), new Guid("bf73d9a1-0390-4257-adae-1efb0320b6fd"), 11 },
                    { new Guid("0b639954-bf80-446d-85da-c8dee8589eb0"), new Guid("6db7840e-63b3-41ff-9815-62074eaaf7a9"), new Guid("a4865afa-8bcd-4560-b673-598b03e8a3e5"), 9 },
                    { new Guid("c98df45c-d1cc-49ca-947e-7546dcbf650d"), new Guid("6db7840e-63b3-41ff-9815-62074eaaf7a9"), new Guid("9d7badd4-54c3-407d-a24d-c3d0ccf91225"), 10 },
                    { new Guid("dd18a4b1-1c93-4513-8cda-96d84b4ff25b"), new Guid("6db7840e-63b3-41ff-9815-62074eaaf7a9"), new Guid("7828910e-7238-40d6-9055-572a7cecf305"), 8 },
                    { new Guid("cbc80092-80b8-4c9c-b8ee-2318150a734d"), new Guid("6db7840e-63b3-41ff-9815-62074eaaf7a9"), new Guid("26d9a0e4-6e8c-4398-a566-76b6c9bfccc2"), 22 },
                    { new Guid("0d6ca4d2-33bc-4f5b-ac4d-7cdb9f3da1e5"), new Guid("6db7840e-63b3-41ff-9815-62074eaaf7a9"), new Guid("d2339776-f23d-4ee1-ac80-5d545466e526"), 11 },
                    { new Guid("c9adf21a-b9a2-4f9a-b6a9-3eb425047ea5"), new Guid("6db7840e-63b3-41ff-9815-62074eaaf7a9"), new Guid("4762edaf-efde-42e8-a33d-bb552d05e855"), 7 },
                    { new Guid("509e2af2-d8b3-4591-ac3f-8764f88f5f7c"), new Guid("6db7840e-63b3-41ff-9815-62074eaaf7a9"), new Guid("20fb524d-979b-4ab2-b6e9-afe6ce408509"), 8 },
                    { new Guid("021bd0de-f3ec-4f86-9f48-bf8462a08ca5"), new Guid("6db7840e-63b3-41ff-9815-62074eaaf7a9"), new Guid("a1ea8e85-c7d1-4132-bcef-1ab04cb4299f"), 5 },
                    { new Guid("b94d3136-12c1-4585-9174-086a49cd519d"), new Guid("6db7840e-63b3-41ff-9815-62074eaaf7a9"), new Guid("6f4ffe3f-f510-493a-ad6e-2efed8bd5e2d"), 0 },
                    { new Guid("6b99669a-7dbe-449a-8b10-f4c41a14302b"), new Guid("05361784-e6fe-4dcd-b4ff-6d1df45c471b"), new Guid("e33896f0-eaeb-4f63-ae6f-12f6cb2f2552"), 12 },
                    { new Guid("c5555935-2bec-4440-839b-daed2f4c52ed"), new Guid("05361784-e6fe-4dcd-b4ff-6d1df45c471b"), new Guid("a811bb40-f419-4633-9df9-f7f73ed66931"), 38 },
                    { new Guid("3fe416c4-df3f-4ea9-8b4f-f73271899a10"), new Guid("05361784-e6fe-4dcd-b4ff-6d1df45c471b"), new Guid("f53d9efd-6a01-498c-b804-923e8e843d63"), 41 },
                    { new Guid("c277dcb4-46f7-4d07-8021-a553924db106"), new Guid("05361784-e6fe-4dcd-b4ff-6d1df45c471b"), new Guid("9f2ce497-989c-4bde-9889-150c2fd29c63"), 12 },
                    { new Guid("39174421-538a-4009-b546-334792277810"), new Guid("05361784-e6fe-4dcd-b4ff-6d1df45c471b"), new Guid("d1dbb921-9965-48ff-ad8a-f28a65d37a68"), 3 },
                    { new Guid("6dbe6ac4-10ac-4f09-bd97-fdad039d7620"), new Guid("05361784-e6fe-4dcd-b4ff-6d1df45c471b"), new Guid("4762edaf-efde-42e8-a33d-bb552d05e855"), 0 },
                    { new Guid("9cd26aa2-051e-46d9-a01e-8262210f0ed6"), new Guid("05361784-e6fe-4dcd-b4ff-6d1df45c471b"), new Guid("24c10ccc-63bb-4c26-b95d-2bbde2ec3912"), 34 },
                    { new Guid("03899f04-09cd-496b-8bbc-fae1d45b8bba"), new Guid("05361784-e6fe-4dcd-b4ff-6d1df45c471b"), new Guid("7afc45a2-f9b7-41fa-af75-f2fbe9b3c3b7"), 6 },
                    { new Guid("3c2c38eb-7604-47f6-abba-6b2f70a6eab2"), new Guid("05361784-e6fe-4dcd-b4ff-6d1df45c471b"), new Guid("a1ea8e85-c7d1-4132-bcef-1ab04cb4299f"), 12 },
                    { new Guid("1d2a9bdb-daca-481d-a40d-ff09aa550033"), new Guid("e9719ef1-b2c1-4c78-bdcc-7c1ac37ac3c7"), new Guid("7afc45a2-f9b7-41fa-af75-f2fbe9b3c3b7"), 6 },
                    { new Guid("6c223880-af1f-4880-8346-e93fcbf511b3"), new Guid("c60d7c0a-08b1-444a-957f-6604b1535a74"), new Guid("a4865afa-8bcd-4560-b673-598b03e8a3e5"), 1 },
                    { new Guid("ce063ba4-1873-43f9-afb2-f34cc42cd2fd"), new Guid("e9719ef1-b2c1-4c78-bdcc-7c1ac37ac3c7"), new Guid("a1ea8e85-c7d1-4132-bcef-1ab04cb4299f"), 25 },
                    { new Guid("df270c5a-dce0-41a4-a0fa-e9da74bc58d5"), new Guid("e9719ef1-b2c1-4c78-bdcc-7c1ac37ac3c7"), new Guid("9f2ce497-989c-4bde-9889-150c2fd29c63"), 58 },
                    { new Guid("7e68b354-21e2-4a28-9880-30c9c7202ce7"), new Guid("c58b5550-7887-433f-b8e9-2e38c2f27ce3"), new Guid("38ed1c57-e732-4adc-a5f8-94469d6c1805"), 13 },
                    { new Guid("3ca0ffa4-5e7f-4deb-87f7-9f4f347ac8a3"), new Guid("c58b5550-7887-433f-b8e9-2e38c2f27ce3"), new Guid("d032460d-cd60-4bb5-83be-9ccdb4f93253"), 40 },
                    { new Guid("d1dcdbc2-2b97-4593-9f80-b3f0a600ae8d"), new Guid("c58b5550-7887-433f-b8e9-2e38c2f27ce3"), new Guid("2d31c815-ced7-4e5a-89f1-c6733a461aab"), 6 },
                    { new Guid("3fb9e391-37c6-40ba-b788-46f7564380ff"), new Guid("c58b5550-7887-433f-b8e9-2e38c2f27ce3"), new Guid("18961872-e0bc-48c5-9f9d-418f9995ebd7"), 13 },
                    { new Guid("2f31c954-4587-4efa-8083-28242f7ca0bc"), new Guid("c58b5550-7887-433f-b8e9-2e38c2f27ce3"), new Guid("08969aac-4fba-4d65-935a-d9c97c654011"), 13 },
                    { new Guid("94be6f04-c6b4-43cb-b301-7e97fc17caaa"), new Guid("c58b5550-7887-433f-b8e9-2e38c2f27ce3"), new Guid("eb4de3de-f595-4c7b-ab89-90301dafad59"), 13 },
                    { new Guid("ed0df6ea-4b43-4091-9fff-f827263b6a22"), new Guid("d7fdf207-aa20-4400-8cbf-97b13351c3ee"), new Guid("61702535-e238-4fa0-9ec0-629ccb9e99b4"), 10 },
                    { new Guid("41a6bc1f-18cc-4019-bc3c-2ba7d2c1fc9f"), new Guid("d7fdf207-aa20-4400-8cbf-97b13351c3ee"), new Guid("26d9a0e4-6e8c-4398-a566-76b6c9bfccc2"), 8 },
                    { new Guid("57335a8d-d82b-407b-a6b8-f8e516b103a3"), new Guid("d7fdf207-aa20-4400-8cbf-97b13351c3ee"), new Guid("4f4d0ce7-a137-477c-b39e-4102b95fbb2c"), 4 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("f5e18135-452b-493d-ab78-910c7c2a9756"), new Guid("d7fdf207-aa20-4400-8cbf-97b13351c3ee"), new Guid("9ff4e8ca-c439-477d-900a-e1f25ca3e2dd"), 13 },
                    { new Guid("4b5ad604-d9b2-4522-9c10-953101a9f5c0"), new Guid("d7fdf207-aa20-4400-8cbf-97b13351c3ee"), new Guid("cc9153e0-4527-4b84-b8f0-d6ebeff5da1b"), 39 },
                    { new Guid("b0dc8b08-69fa-4e07-ba7d-5d5f684410aa"), new Guid("d7fdf207-aa20-4400-8cbf-97b13351c3ee"), new Guid("18961872-e0bc-48c5-9f9d-418f9995ebd7"), 6 },
                    { new Guid("8b5a95ab-e539-495c-a840-f0a43d8c0d57"), new Guid("d7fdf207-aa20-4400-8cbf-97b13351c3ee"), new Guid("f55e4540-a81c-4d8a-a084-d5467372c4c8"), 3 },
                    { new Guid("d178b0c5-3748-4558-aa09-1b13e10d0a54"), new Guid("d7fdf207-aa20-4400-8cbf-97b13351c3ee"), new Guid("6f4ffe3f-f510-493a-ad6e-2efed8bd5e2d"), 17 },
                    { new Guid("24725342-329b-44f3-bf4f-82cfbdb89ace"), new Guid("d7fdf207-aa20-4400-8cbf-97b13351c3ee"), new Guid("2d31c815-ced7-4e5a-89f1-c6733a461aab"), 19 },
                    { new Guid("4e1c703e-d466-453e-9708-9cccc0446cad"), new Guid("d7fdf207-aa20-4400-8cbf-97b13351c3ee"), new Guid("7828910e-7238-40d6-9055-572a7cecf305"), 8 },
                    { new Guid("182a9a88-4ef8-4463-b629-8cbe6ce3db5e"), new Guid("d7fdf207-aa20-4400-8cbf-97b13351c3ee"), new Guid("a4865afa-8bcd-4560-b673-598b03e8a3e5"), 16 },
                    { new Guid("5d9889e8-6aad-4fa3-adb5-450643af3cb5"), new Guid("d7fdf207-aa20-4400-8cbf-97b13351c3ee"), new Guid("af629e88-9a33-49cf-a1c1-3484d71a5ea9"), 5 },
                    { new Guid("5dcf578f-a764-4bad-9c40-5f5b88b3236f"), new Guid("d7fdf207-aa20-4400-8cbf-97b13351c3ee"), new Guid("4762edaf-efde-42e8-a33d-bb552d05e855"), 7 },
                    { new Guid("8a9d5eda-f0f8-4cef-82ae-2bf61efcc4e2"), new Guid("e9719ef1-b2c1-4c78-bdcc-7c1ac37ac3c7"), new Guid("2afded9f-ac57-469c-92f4-3ed713a149e3"), 5 },
                    { new Guid("7f40447c-abdc-4f3a-8e78-4cbf6e78c8ac"), new Guid("e9719ef1-b2c1-4c78-bdcc-7c1ac37ac3c7"), new Guid("e33896f0-eaeb-4f63-ae6f-12f6cb2f2552"), 32 },
                    { new Guid("ccdd84be-2e8d-4b66-88af-0159f048a3f7"), new Guid("e9719ef1-b2c1-4c78-bdcc-7c1ac37ac3c7"), new Guid("24c10ccc-63bb-4c26-b95d-2bbde2ec3912"), 11 },
                    { new Guid("3a5a2494-61d4-4d90-b97e-c89e3690a900"), new Guid("05361784-e6fe-4dcd-b4ff-6d1df45c471b"), new Guid("af629e88-9a33-49cf-a1c1-3484d71a5ea9"), 8 },
                    { new Guid("536f2d24-7db6-4095-857f-33062d3ccf2a"), new Guid("f6a11456-c59a-4e93-b3c0-4d48cb03b2c3"), new Guid("61702535-e238-4fa0-9ec0-629ccb9e99b4"), 3 },
                    { new Guid("f080067a-3f40-4bbe-b2fc-119aa8841be7"), new Guid("f6a11456-c59a-4e93-b3c0-4d48cb03b2c3"), new Guid("af629e88-9a33-49cf-a1c1-3484d71a5ea9"), 5 },
                    { new Guid("30dae148-fa16-4abf-ab76-2904042bb550"), new Guid("5be2422e-38af-4430-b63a-ab6763e637b5"), new Guid("6f4ffe3f-f510-493a-ad6e-2efed8bd5e2d"), 8 },
                    { new Guid("2966f11c-d5ab-412c-9b57-0eed59b72e2d"), new Guid("5be2422e-38af-4430-b63a-ab6763e637b5"), new Guid("a4865afa-8bcd-4560-b673-598b03e8a3e5"), 17 },
                    { new Guid("8ae88d36-138e-4f53-81ed-f91543354329"), new Guid("5be2422e-38af-4430-b63a-ab6763e637b5"), new Guid("7828910e-7238-40d6-9055-572a7cecf305"), 0 },
                    { new Guid("4b097680-0d6f-4e9b-82b2-2ba8a0747394"), new Guid("bd60ad7f-dc58-4401-b094-a9b379325634"), new Guid("131d32b0-48f2-400f-ad2f-6d2952b67fcb"), 11 },
                    { new Guid("52114a95-08d8-4e9c-8fb7-50781501d80c"), new Guid("bd60ad7f-dc58-4401-b094-a9b379325634"), new Guid("2ab2ba56-fe04-4a53-ae20-2215b7fc87b8"), 18 },
                    { new Guid("3063ede0-027d-4124-97a5-9979b6b51000"), new Guid("bd60ad7f-dc58-4401-b094-a9b379325634"), new Guid("2d31c815-ced7-4e5a-89f1-c6733a461aab"), 11 },
                    { new Guid("8d607ae2-cada-4f10-9719-27e12b34c02a"), new Guid("bd60ad7f-dc58-4401-b094-a9b379325634"), new Guid("d2339776-f23d-4ee1-ac80-5d545466e526"), 28 },
                    { new Guid("5ad86e7c-5056-4b08-933b-0240c0fb9278"), new Guid("bd60ad7f-dc58-4401-b094-a9b379325634"), new Guid("9d7badd4-54c3-407d-a24d-c3d0ccf91225"), 17 },
                    { new Guid("f95e4801-8402-4679-aeab-94aa77fc2960"), new Guid("bd60ad7f-dc58-4401-b094-a9b379325634"), new Guid("88cf1bad-edb4-49f1-9206-b6a212d816d5"), 15 },
                    { new Guid("68222190-e26d-404e-8db5-3cc3517b3c1b"), new Guid("5be2422e-38af-4430-b63a-ab6763e637b5"), new Guid("4762edaf-efde-42e8-a33d-bb552d05e855"), 0 },
                    { new Guid("7e55abb5-f92d-4109-adba-14494e05af75"), new Guid("bd60ad7f-dc58-4401-b094-a9b379325634"), new Guid("bf73d9a1-0390-4257-adae-1efb0320b6fd"), 3 },
                    { new Guid("bddb5cd5-8ea2-471e-8499-5e05d06cfa23"), new Guid("4f4c1b3f-adc8-4ff4-902a-38e835133f6b"), new Guid("6f4ffe3f-f510-493a-ad6e-2efed8bd5e2d"), 2 },
                    { new Guid("66364f35-3344-4d03-9bc3-0e3cd6324e89"), new Guid("4f4c1b3f-adc8-4ff4-902a-38e835133f6b"), new Guid("4762edaf-efde-42e8-a33d-bb552d05e855"), 7 },
                    { new Guid("4cf3d8d8-d439-4209-a535-ed08c46de413"), new Guid("4f4c1b3f-adc8-4ff4-902a-38e835133f6b"), new Guid("9ff4e8ca-c439-477d-900a-e1f25ca3e2dd"), 13 },
                    { new Guid("f6f6be8c-5b50-4a11-b602-b8d7b025d076"), new Guid("4f4c1b3f-adc8-4ff4-902a-38e835133f6b"), new Guid("2d31c815-ced7-4e5a-89f1-c6733a461aab"), 26 },
                    { new Guid("3b34f529-c18d-4e33-8301-fe38b8a22281"), new Guid("4f4c1b3f-adc8-4ff4-902a-38e835133f6b"), new Guid("08969aac-4fba-4d65-935a-d9c97c654011"), 13 },
                    { new Guid("7b2adcf2-3d38-4723-bb84-731ec7ecce2c"), new Guid("4f4c1b3f-adc8-4ff4-902a-38e835133f6b"), new Guid("cc9153e0-4527-4b84-b8f0-d6ebeff5da1b"), 0 },
                    { new Guid("50fb326a-6523-4293-ac9d-37a51249d977"), new Guid("4f4c1b3f-adc8-4ff4-902a-38e835133f6b"), new Guid("53d2bdf1-94be-4e6f-80ae-8ce1cf42fa55"), 39 },
                    { new Guid("3033155c-4209-4241-9062-52eb9fccfe8f"), new Guid("4f4c1b3f-adc8-4ff4-902a-38e835133f6b"), new Guid("4f4d0ce7-a137-477c-b39e-4102b95fbb2c"), 10 },
                    { new Guid("e2900f3f-cd2e-4d16-ba34-656e6721adb1"), new Guid("4f4c1b3f-adc8-4ff4-902a-38e835133f6b"), new Guid("d032460d-cd60-4bb5-83be-9ccdb4f93253"), 13 },
                    { new Guid("c8afedb4-b4c2-4c0e-890e-b4e751eec0fb"), new Guid("bd60ad7f-dc58-4401-b094-a9b379325634"), new Guid("7828910e-7238-40d6-9055-572a7cecf305"), 9 },
                    { new Guid("b8b02b22-b548-4ab3-a15e-0060b3ed534e"), new Guid("5be2422e-38af-4430-b63a-ab6763e637b5"), new Guid("9d7badd4-54c3-407d-a24d-c3d0ccf91225"), 2 },
                    { new Guid("5ebd3568-7a74-4297-80e1-1e95dd99415a"), new Guid("5be2422e-38af-4430-b63a-ab6763e637b5"), new Guid("26d9a0e4-6e8c-4398-a566-76b6c9bfccc2"), 19 },
                    { new Guid("8ef8c837-68a8-4a7b-8af6-b9a822e8cd10"), new Guid("5be2422e-38af-4430-b63a-ab6763e637b5"), new Guid("d2339776-f23d-4ee1-ac80-5d545466e526"), 2 },
                    { new Guid("f2736ab7-0541-41de-8a06-4b056aafd92d"), new Guid("b3361f45-f0e5-4dc3-81ac-11b7f1ba2203"), new Guid("d1dbb921-9965-48ff-ad8a-f28a65d37a68"), 3 },
                    { new Guid("1798840e-09e6-487c-a2ba-ccc72217a19a"), new Guid("b3361f45-f0e5-4dc3-81ac-11b7f1ba2203"), new Guid("61702535-e238-4fa0-9ec0-629ccb9e99b4"), 10 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("6e0e4963-fc9d-4e9c-a16f-eb4563d1c98d"), new Guid("b3361f45-f0e5-4dc3-81ac-11b7f1ba2203"), new Guid("131d32b0-48f2-400f-ad2f-6d2952b67fcb"), 2 },
                    { new Guid("eea1cfef-f274-4091-835f-d870c0a7ed4c"), new Guid("b3361f45-f0e5-4dc3-81ac-11b7f1ba2203"), new Guid("f55e4540-a81c-4d8a-a084-d5467372c4c8"), 35 },
                    { new Guid("448a3728-11dc-48f4-8dea-d50c2ae63c07"), new Guid("b3361f45-f0e5-4dc3-81ac-11b7f1ba2203"), new Guid("71898d20-d3fc-49e6-b14d-fdf144cce37d"), 15 },
                    { new Guid("f00dbdd2-ce26-44f3-8adf-ef22e8384267"), new Guid("b3361f45-f0e5-4dc3-81ac-11b7f1ba2203"), new Guid("4f4d0ce7-a137-477c-b39e-4102b95fbb2c"), 22 },
                    { new Guid("80c4b04a-842b-43f9-981e-04f7e2a1f3de"), new Guid("b3361f45-f0e5-4dc3-81ac-11b7f1ba2203"), new Guid("2afded9f-ac57-469c-92f4-3ed713a149e3"), 4 },
                    { new Guid("67e7ed49-881b-4b90-9ef4-c70da46d161d"), new Guid("b3361f45-f0e5-4dc3-81ac-11b7f1ba2203"), new Guid("1317e147-39b8-4d37-b15f-07930f5c6de4"), 2 },
                    { new Guid("fad0fcfa-e1f1-452c-b63b-5d6730f2d2fe"), new Guid("b3361f45-f0e5-4dc3-81ac-11b7f1ba2203"), new Guid("ae6804ab-f48c-48b0-a140-9e730a22d767"), 18 },
                    { new Guid("b2fe86b4-d94a-4614-8a89-ebccae3a3a7a"), new Guid("fe5dd62b-6830-43df-b77e-2b66bfac6931"), new Guid("38ed1c57-e732-4adc-a5f8-94469d6c1805"), 7 },
                    { new Guid("db7492b3-9ecb-4b45-82e1-5e6935beb4d1"), new Guid("fe5dd62b-6830-43df-b77e-2b66bfac6931"), new Guid("ae6804ab-f48c-48b0-a140-9e730a22d767"), 19 },
                    { new Guid("a3eb6a18-7cff-4d35-9c02-d25fe5ab35b9"), new Guid("fe5dd62b-6830-43df-b77e-2b66bfac6931"), new Guid("1317e147-39b8-4d37-b15f-07930f5c6de4"), 11 },
                    { new Guid("1352b198-233f-4fb9-9426-4026070ffbd3"), new Guid("fe5dd62b-6830-43df-b77e-2b66bfac6931"), new Guid("88cf1bad-edb4-49f1-9206-b6a212d816d5"), 19 },
                    { new Guid("195916b8-d4f4-4d89-b7b6-9b8f312cb2fa"), new Guid("fe5dd62b-6830-43df-b77e-2b66bfac6931"), new Guid("131d32b0-48f2-400f-ad2f-6d2952b67fcb"), 9 },
                    { new Guid("7e7feb84-ce50-44fd-8e0e-76d8cc9e3c25"), new Guid("fe5dd62b-6830-43df-b77e-2b66bfac6931"), new Guid("61702535-e238-4fa0-9ec0-629ccb9e99b4"), 11 },
                    { new Guid("e5b5688a-24db-44cd-8b93-26f6e553debd"), new Guid("fe5dd62b-6830-43df-b77e-2b66bfac6931"), new Guid("c67c7ccd-1560-47b5-bcc2-26c2624decdd"), 16 },
                    { new Guid("f7e59422-e5f1-45f6-96a9-c4c3fa1ea2f1"), new Guid("fe5dd62b-6830-43df-b77e-2b66bfac6931"), new Guid("71898d20-d3fc-49e6-b14d-fdf144cce37d"), 12 },
                    { new Guid("77f4402b-e956-4f58-9a12-69f2a66e08e5"), new Guid("fe5dd62b-6830-43df-b77e-2b66bfac6931"), new Guid("2ab2ba56-fe04-4a53-ae20-2215b7fc87b8"), 4 },
                    { new Guid("9c713139-3d4d-4e41-96f2-eb58cc0411ba"), new Guid("fe5dd62b-6830-43df-b77e-2b66bfac6931"), new Guid("d2339776-f23d-4ee1-ac80-5d545466e526"), 5 },
                    { new Guid("319ff931-76af-4076-9619-d7c698ed4aac"), new Guid("fe5dd62b-6830-43df-b77e-2b66bfac6931"), new Guid("bf73d9a1-0390-4257-adae-1efb0320b6fd"), 10 },
                    { new Guid("5f64bc16-27a2-4fc7-89d9-fb48ed62cf3f"), new Guid("5be2422e-38af-4430-b63a-ab6763e637b5"), new Guid("20fb524d-979b-4ab2-b6e9-afe6ce408509"), 30 },
                    { new Guid("07eac842-c4e2-4a17-a896-ed03f0258ce9"), new Guid("dd7763d2-3b5d-4b28-a566-399c607b4eed"), new Guid("2ab2ba56-fe04-4a53-ae20-2215b7fc87b8"), 12 },
                    { new Guid("12cc8064-62cc-4d32-9ed7-9841d89111d5"), new Guid("dd7763d2-3b5d-4b28-a566-399c607b4eed"), new Guid("26d9a0e4-6e8c-4398-a566-76b6c9bfccc2"), 7 },
                    { new Guid("b5f30613-00ee-4ee1-ac48-e492fd1f8258"), new Guid("dd7763d2-3b5d-4b28-a566-399c607b4eed"), new Guid("20fb524d-979b-4ab2-b6e9-afe6ce408509"), 17 },
                    { new Guid("6700119c-6640-4723-8a55-084841bca30c"), new Guid("dd7763d2-3b5d-4b28-a566-399c607b4eed"), new Guid("7828910e-7238-40d6-9055-572a7cecf305"), 10 },
                    { new Guid("28ba587e-d7f3-4ad7-b7b4-83d1a4f81c09"), new Guid("db2f2c19-7e3d-4dbe-a90c-973fbfad8e56"), new Guid("4762edaf-efde-42e8-a33d-bb552d05e855"), 0 },
                    { new Guid("3e2cf4c2-d933-4cca-be0e-00f0ffb9f272"), new Guid("6605e28c-3bc1-4a44-b5db-43e309e17d7a"), new Guid("cc9153e0-4527-4b84-b8f0-d6ebeff5da1b"), 7 },
                    { new Guid("de12631c-d111-4979-b4ad-243967ff0d99"), new Guid("6605e28c-3bc1-4a44-b5db-43e309e17d7a"), new Guid("2d31c815-ced7-4e5a-89f1-c6733a461aab"), 7 },
                    { new Guid("9b44957d-87e1-412e-9178-2aebc0f19d7d"), new Guid("6605e28c-3bc1-4a44-b5db-43e309e17d7a"), new Guid("d2339776-f23d-4ee1-ac80-5d545466e526"), 2 },
                    { new Guid("9c54b9e7-e1aa-4483-927c-4da09d2d6d0e"), new Guid("6605e28c-3bc1-4a44-b5db-43e309e17d7a"), new Guid("18961872-e0bc-48c5-9f9d-418f9995ebd7"), 45 },
                    { new Guid("03939623-2e90-4d67-b8d2-fa97ffce9da4"), new Guid("6605e28c-3bc1-4a44-b5db-43e309e17d7a"), new Guid("38ed1c57-e732-4adc-a5f8-94469d6c1805"), 32 },
                    { new Guid("365e41f7-9fb6-4021-81dc-622b124e50c1"), new Guid("6605e28c-3bc1-4a44-b5db-43e309e17d7a"), new Guid("d032460d-cd60-4bb5-83be-9ccdb4f93253"), 33 },
                    { new Guid("d912e28e-9456-405c-902b-48db24b728a7"), new Guid("6605e28c-3bc1-4a44-b5db-43e309e17d7a"), new Guid("f55e4540-a81c-4d8a-a084-d5467372c4c8"), 3 },
                    { new Guid("f16db62f-4d84-4287-97c0-36955b6b8f8f"), new Guid("6605e28c-3bc1-4a44-b5db-43e309e17d7a"), new Guid("9ff4e8ca-c439-477d-900a-e1f25ca3e2dd"), 21 },
                    { new Guid("aa10bc85-15b3-48f5-b090-405438801615"), new Guid("6605e28c-3bc1-4a44-b5db-43e309e17d7a"), new Guid("a4865afa-8bcd-4560-b673-598b03e8a3e5"), 8 },
                    { new Guid("5c30ea2d-db2f-4d69-9f5a-4b99ea151ce5"), new Guid("6605e28c-3bc1-4a44-b5db-43e309e17d7a"), new Guid("1317e147-39b8-4d37-b15f-07930f5c6de4"), 10 },
                    { new Guid("61eb46b2-05a0-4307-aa80-bbff2223ce3b"), new Guid("6605e28c-3bc1-4a44-b5db-43e309e17d7a"), new Guid("08969aac-4fba-4d65-935a-d9c97c654011"), 32 },
                    { new Guid("980658e2-ee04-4f15-8a73-b882f46e645c"), new Guid("6605e28c-3bc1-4a44-b5db-43e309e17d7a"), new Guid("53d2bdf1-94be-4e6f-80ae-8ce1cf42fa55"), 6 },
                    { new Guid("b60125ed-d7a6-4922-ac57-c3b26c481911"), new Guid("f6a11456-c59a-4e93-b3c0-4d48cb03b2c3"), new Guid("d032460d-cd60-4bb5-83be-9ccdb4f93253"), 13 },
                    { new Guid("4a0013e8-f48c-44f5-95bd-4205a9ba66ab"), new Guid("f6a11456-c59a-4e93-b3c0-4d48cb03b2c3"), new Guid("4f4d0ce7-a137-477c-b39e-4102b95fbb2c"), 49 },
                    { new Guid("00bd7c12-1477-4225-b9a5-900f5a443717"), new Guid("f6a11456-c59a-4e93-b3c0-4d48cb03b2c3"), new Guid("2afded9f-ac57-469c-92f4-3ed713a149e3"), 70 },
                    { new Guid("cff56867-6054-4951-a85b-5b3f597da803"), new Guid("f6a11456-c59a-4e93-b3c0-4d48cb03b2c3"), new Guid("d1dbb921-9965-48ff-ad8a-f28a65d37a68"), 14 },
                    { new Guid("e42e02fe-912d-454e-a2a7-b1f85a99b71c"), new Guid("f6a11456-c59a-4e93-b3c0-4d48cb03b2c3"), new Guid("20fb524d-979b-4ab2-b6e9-afe6ce408509"), 8 },
                    { new Guid("78e42288-90c4-47a2-866b-f66864e44179"), new Guid("f6a11456-c59a-4e93-b3c0-4d48cb03b2c3"), new Guid("f55e4540-a81c-4d8a-a084-d5467372c4c8"), 10 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("ffe2b09f-0d16-4e17-9034-1a333b8a6138"), new Guid("f6a11456-c59a-4e93-b3c0-4d48cb03b2c3"), new Guid("f53d9efd-6a01-498c-b804-923e8e843d63"), 46 },
                    { new Guid("7b1f5dcf-6382-4560-a7ff-4d31bf8d8d52"), new Guid("f6a11456-c59a-4e93-b3c0-4d48cb03b2c3"), new Guid("6f4ffe3f-f510-493a-ad6e-2efed8bd5e2d"), 7 },
                    { new Guid("3258e7e6-0998-4265-8701-6c2fa6f0e1dd"), new Guid("db2f2c19-7e3d-4dbe-a90c-973fbfad8e56"), new Guid("4f4d0ce7-a137-477c-b39e-4102b95fbb2c"), 10 },
                    { new Guid("38eb2ab3-54b7-4e1f-acd5-1864df505e6f"), new Guid("f6a11456-c59a-4e93-b3c0-4d48cb03b2c3"), new Guid("24c10ccc-63bb-4c26-b95d-2bbde2ec3912"), 0 },
                    { new Guid("6bb77fd1-21c1-430f-9c0c-b9b566d3f4bc"), new Guid("db2f2c19-7e3d-4dbe-a90c-973fbfad8e56"), new Guid("61702535-e238-4fa0-9ec0-629ccb9e99b4"), 4 },
                    { new Guid("6b746696-c0b2-4874-bd2a-413044afba70"), new Guid("db2f2c19-7e3d-4dbe-a90c-973fbfad8e56"), new Guid("2afded9f-ac57-469c-92f4-3ed713a149e3"), 4 },
                    { new Guid("90767240-ab19-4a18-bb3c-c42ee796c6b5"), new Guid("dd7763d2-3b5d-4b28-a566-399c607b4eed"), new Guid("131d32b0-48f2-400f-ad2f-6d2952b67fcb"), 13 },
                    { new Guid("9e85accb-9b39-4e86-b1cf-f88f6e0411e6"), new Guid("dd7763d2-3b5d-4b28-a566-399c607b4eed"), new Guid("d2339776-f23d-4ee1-ac80-5d545466e526"), 19 },
                    { new Guid("7def4c34-b35c-4975-8223-401058b7cc90"), new Guid("dd7763d2-3b5d-4b28-a566-399c607b4eed"), new Guid("bf73d9a1-0390-4257-adae-1efb0320b6fd"), 44 },
                    { new Guid("5f437b2f-1d47-47ee-acc7-6ef17968f8ae"), new Guid("dd7763d2-3b5d-4b28-a566-399c607b4eed"), new Guid("88cf1bad-edb4-49f1-9206-b6a212d816d5"), 40 },
                    { new Guid("0b2e8264-fd93-4da2-b22a-c9e75136efad"), new Guid("dd7763d2-3b5d-4b28-a566-399c607b4eed"), new Guid("9d7badd4-54c3-407d-a24d-c3d0ccf91225"), 37 },
                    { new Guid("2e08e826-185a-4b02-91b5-ff634fca319d"), new Guid("dd7763d2-3b5d-4b28-a566-399c607b4eed"), new Guid("4f4d0ce7-a137-477c-b39e-4102b95fbb2c"), 3 },
                    { new Guid("ce459ce4-6064-4a1f-988b-4b6fb127e21a"), new Guid("8017a3aa-c9f2-4382-afca-f22e2212e6b4"), new Guid("24c10ccc-63bb-4c26-b95d-2bbde2ec3912"), 12 },
                    { new Guid("dfd93fec-f4d2-47d5-952f-8089333836ce"), new Guid("8017a3aa-c9f2-4382-afca-f22e2212e6b4"), new Guid("d1dbb921-9965-48ff-ad8a-f28a65d37a68"), 14 },
                    { new Guid("7f603cad-ec0a-45f5-be52-eaa3f02ecfe4"), new Guid("8017a3aa-c9f2-4382-afca-f22e2212e6b4"), new Guid("61702535-e238-4fa0-9ec0-629ccb9e99b4"), 27 },
                    { new Guid("0dd54f3c-bbaf-41c6-abdf-f14d6153424d"), new Guid("8017a3aa-c9f2-4382-afca-f22e2212e6b4"), new Guid("4f4d0ce7-a137-477c-b39e-4102b95fbb2c"), 36 },
                    { new Guid("bef35bac-febc-42ae-b408-d351737f7240"), new Guid("8017a3aa-c9f2-4382-afca-f22e2212e6b4"), new Guid("2afded9f-ac57-469c-92f4-3ed713a149e3"), 34 },
                    { new Guid("fc5f3935-5ca7-4db2-9683-bacf9c521117"), new Guid("8017a3aa-c9f2-4382-afca-f22e2212e6b4"), new Guid("71898d20-d3fc-49e6-b14d-fdf144cce37d"), 3 },
                    { new Guid("0e0c84fa-4fae-4c33-a4e0-967d7fd63f21"), new Guid("8017a3aa-c9f2-4382-afca-f22e2212e6b4"), new Guid("af629e88-9a33-49cf-a1c1-3484d71a5ea9"), 4 },
                    { new Guid("47214f2a-35c6-4a76-8af7-b88156a40bd0"), new Guid("8017a3aa-c9f2-4382-afca-f22e2212e6b4"), new Guid("6f4ffe3f-f510-493a-ad6e-2efed8bd5e2d"), 0 },
                    { new Guid("8d4d989c-85f8-4acc-8493-58f4bf19220b"), new Guid("8017a3aa-c9f2-4382-afca-f22e2212e6b4"), new Guid("f55e4540-a81c-4d8a-a084-d5467372c4c8"), 3 },
                    { new Guid("7aa1cade-1c05-487d-92fd-65eeb92f67ee"), new Guid("8017a3aa-c9f2-4382-afca-f22e2212e6b4"), new Guid("f53d9efd-6a01-498c-b804-923e8e843d63"), 22 },
                    { new Guid("db9315b8-dde0-42ca-b29d-353dfd9ecfbd"), new Guid("db2f2c19-7e3d-4dbe-a90c-973fbfad8e56"), new Guid("ae6804ab-f48c-48b0-a140-9e730a22d767"), 48 },
                    { new Guid("7179ac87-bdca-4d67-b7f8-64e810b46869"), new Guid("db2f2c19-7e3d-4dbe-a90c-973fbfad8e56"), new Guid("c67c7ccd-1560-47b5-bcc2-26c2624decdd"), 63 },
                    { new Guid("26e6eeda-e5e6-422b-8f4d-53a704864219"), new Guid("db2f2c19-7e3d-4dbe-a90c-973fbfad8e56"), new Guid("1317e147-39b8-4d37-b15f-07930f5c6de4"), 2 },
                    { new Guid("3afa6beb-6f70-4309-8abc-d197c55e5a6c"), new Guid("db2f2c19-7e3d-4dbe-a90c-973fbfad8e56"), new Guid("f53d9efd-6a01-498c-b804-923e8e843d63"), 11 },
                    { new Guid("75f86b36-954b-4a4f-96f6-e03bbfe41fac"), new Guid("db2f2c19-7e3d-4dbe-a90c-973fbfad8e56"), new Guid("71898d20-d3fc-49e6-b14d-fdf144cce37d"), 39 },
                    { new Guid("605e83ab-0ff1-456a-991c-39c611346f60"), new Guid("db2f2c19-7e3d-4dbe-a90c-973fbfad8e56"), new Guid("f55e4540-a81c-4d8a-a084-d5467372c4c8"), 28 },
                    { new Guid("2e73a8cd-850a-4327-aad1-6b1501e29b98"), new Guid("05361784-e6fe-4dcd-b4ff-6d1df45c471b"), new Guid("4f4d0ce7-a137-477c-b39e-4102b95fbb2c"), 3 }
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
