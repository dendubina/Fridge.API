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
                    DefaultQuantity = table.Column<int>(type: "int", nullable: false),
                    ImageSource = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    { new Guid("f80a6ac5-72f5-4ed0-a938-f66570d41845"), "TH-803", 2019 },
                    { new Guid("23abc33d-5f5c-4aaa-86f0-84f2f91c5d6c"), "RSA1SHVB1", 2018 },
                    { new Guid("aa910856-3eb5-4da1-a2f4-5362266e3add"), "VF 395-1 SBS", 2015 },
                    { new Guid("099bf9c9-3541-44e2-8684-b4a45a65465a"), "SBS 7212", 2015 },
                    { new Guid("30482cbb-33a5-4c17-b8c7-717ae49fb48a"), "Electric MR-CR46G-HS-R", 2014 },
                    { new Guid("cfdc5da0-9618-4034-8662-b39f38ca6be2"), "VF 910 X", 2011 },
                    { new Guid("3836cb84-7fb4-45eb-9953-8c63279d4319"), "RB-34 K6220SS", 2014 },
                    { new Guid("357c2fc4-6dd9-4834-a914-8d75d6826cd8"), "RF-61 K90407F", 2018 },
                    { new Guid("a3640b1d-f1f0-49ad-b1ba-b0e7538d91c0"), "VF 466 EB", 2018 },
                    { new Guid("85445561-627a-4899-aa62-d269224a0198"), "DS 333020", 2012 },
                    { new Guid("e8ee1f79-972d-498b-9ad6-eb54128a81bc"), "DF 5180 W", 2012 },
                    { new Guid("24c1b9b9-a1f1-4a08-bbe6-7f55548bc656"), "XM 4021-000", 2010 },
                    { new Guid("3fdbd942-377d-4334-a4a6-a136c362ee17"), "RC-54", 2012 },
                    { new Guid("801e7585-c0e5-48ab-862c-3e0f26eee8e7"), "514-NWE", 2014 },
                    { new Guid("1360d01f-c99a-4a59-b4bf-642f8fa403ba"), "KGN36S55", 2019 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DefaultQuantity", "ImageSource", "Name" },
                values: new object[,]
                {
                    { new Guid("048d4efc-089b-453b-b778-a65d8c5e3d21"), 14, "https://soapatopia.com/wp-content/uploads/2021/01/raspberries.jpg", "Raspberry" },
                    { new Guid("1fa563d3-936b-4217-a200-2d514dd33f94"), 16, "https://sc04.alicdn.com/kf/Ub2b912f5fb6d48ce99dee2bef2a7d2fch.jpg", "Cherry" },
                    { new Guid("5ead8209-d653-4bb9-af6a-5fbf888a9f18"), 14, "https://img.freepik.com/free-vector/isolated-dark-grape-with-green-leaf_317810-1956.jpg?w=2000", "Grape" },
                    { new Guid("5d87fa2a-7402-4796-a154-6fd7347023fa"), 6, "https://www.seeds-gallery.shop/8291-large_default/lemon-seeds-c-limon.jpg", "Lemon" },
                    { new Guid("48cd87ec-0fa5-4725-8f8c-4b018aa8609a"), 5, "https://cdn.shopify.com/s/files/1/2971/2126/products/Orange_f48b955f-9cde-4b90-bbd5-03ce7b8bcf1f_400x.jpg?v=1569304785", "Orange" },
                    { new Guid("7100222f-745f-446a-a519-15b218c62e57"), 10, "https://static.libertyprim.com/files/familles/peche-large.jpg?1574630286", "Peach" },
                    { new Guid("8a794cbe-0bdf-43dc-9553-f8101f49371b"), 10, "https://befreshcorp.net/wp-content/uploads/2017/07/product-packshot-strawberrie-558x600.jpg", "Strawberry" },
                    { new Guid("f32c8667-8c8a-46de-866a-f8888e518b8f"), 13, "https://www.seeds-gallery.shop/5488-large_default/400-watermelon-seeds-crimson-sweet.jpg", "Watermelon" },
                    { new Guid("5e47f106-4a55-4542-a656-c49a71b0ede3"), 13, "https://assets.tmecosys.com/image/upload/t_web767x639/img/recipe/ras/Assets/607dfd53-5b5c-4309-9e1f-5a959d20e16c/Derivates/9ac9e3c1-20d2-4d31-afdb-191c9ba22235.jpg", "Jelly" },
                    { new Guid("7ccc317c-6ddf-4bdb-bdbc-c5b647f68f35"), 17, "https://static.vecteezy.com/system/resources/previews/006/225/849/original/a-carton-of-milk-cartoon-illustration-vector.jpg", "Milk" },
                    { new Guid("f4e5d78c-344b-4126-9ac8-58bbb0fac6a6"), 15, "https://groceries.morrisons.com/productImages/408/408833011_0_268x268.jpg?identifier=146ae3bbcbb049c8aa859a0fbd47946e", "Kefir" },
                    { new Guid("5e761121-326a-49e3-9170-da8b8631dcb6"), 13, "https://andygrimshaw.com/wp-content/uploads/2016/03/Chocolate-bar-melt-explosion.jpg", "Chocolate" },
                    { new Guid("6456db6c-0656-4213-b64c-34c776f9f4f7"), 11, "https://assets.tmecosys.com/image/upload/t_web767x639/img/recipe/ras/Assets/4B7C3510-7041-4B5D-8000-1D10B1BA4678/Derivates/6749ac4e-586d-4055-9df2-5a96832897f6.jpg", "Jam" },
                    { new Guid("54eee9f5-b83c-4344-aaf9-5aa0262e33d8"), 16, "https://www.mybakingaddiction.com/wp-content/uploads/2021/03/vanilla-pudding-with-fruit-720x720.jpg", "Pudding" },
                    { new Guid("780d00bb-7681-440a-8948-0db6091c8785"), 17, "https://images.heb.com/is/image/HEBGrocery/000377497", "Banana" },
                    { new Guid("d5d582a4-0a16-4c8e-b680-dc1711c1867d"), 10, "https://www.wholesomeyum.com/wp-content/uploads/2017/03/wholesomeyum-Low-Carb-Keto-Pancakes-Recipe-21.jpg", "Pancake" },
                    { new Guid("92d00395-2800-4b4f-974e-18b27f27e525"), 6, "https://quintalsonline.com/wp-content/uploads/2020/05/close-up-of-block-of-butter-being-sliced-may-raise-cholesterol_1400x.jpg", "Butter" },
                    { new Guid("e3127588-62ed-4459-bbf5-562030ef456c"), 12, "https://5.imimg.com/data5/ANDROID/Default/2021/2/UH/HH/LB/44089979/potatoes-jpg-250x250.jpg", "Potato" },
                    { new Guid("f0ddb097-faab-41e2-b6fd-8c7475e92d0c"), 9, "https://images.absolutdrinks.com/ingredient-images/Raw/Absolut/d391984d-0573-4fb2-aa36-2f18d2ee8ce8.jpg?imwidth=500", "Avocado" },
                    { new Guid("a53daaf3-9eaa-4736-b5e8-6de65e45e4ec"), 9, "https://produits.bienmanger.com/36700-0w470h470_Organic_Red_Onion_From_Italy.jpg", "Onion" },
                    { new Guid("b7e10d92-d054-41d6-9238-2b000d3cad7a"), 7, "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7b/Assorted_bread.jpg/274px-Assorted_bread.jpg", "Bread" },
                    { new Guid("76295722-b3bb-40f6-8996-8790fd8fa611"), 17, "https://id-test-11.slatic.net/p/70f40d8f77f844671af4a5a11755e7ae.jpg", "Apple" },
                    { new Guid("fd89d73f-8b12-4a4b-bbd7-01b340b83718"), 17, "https://media.istockphoto.com/vectors/yogurt-cup-with-spoon-vector-id1060883416?k=20&m=1060883416&s=612x612&w=0&h=nhPJA8XYohdkGbBojLt72e_q9sbgBuO6mUI-7cnuu6s=", "Yoghurt" },
                    { new Guid("d4017dae-7d91-4aed-a5ce-2b46c5eada93"), 9, "https://www.collinsdictionary.com/images/full/egg_110803370.jpg", "Egg" },
                    { new Guid("5eb62c67-8488-435c-821f-505779e9b43e"), 8, "https://cdn.yamatoscale.com/wp-content/uploads/2016/04/K%C3%A4se-Scheiben_01_00_OH-1.jpg", "Cheese" },
                    { new Guid("6423ad10-758d-4a16-b2d5-36b6f3138290"), 6, "https://4.imimg.com/data4/JX/UQ/ANDROID-47104262/product-500x500.jpeg", "Mashroom" },
                    { new Guid("b6df4f09-41c3-4704-9ba5-a2829f695ae4"), 16, "https://food.fnr.sndimg.com/content/dam/images/food/fullset/2010/5/1/0/0039592F3_beer-can-chicken_s4x3.jpg.rend.hgtvcom.616.462.suffix/1382539274625.jpeg", "Chicken" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DefaultQuantity", "ImageSource", "Name" },
                values: new object[,]
                {
                    { new Guid("8ee72798-bdf7-4871-a94a-02fc34c8f501"), 14, "https://www.ngroceries.com/wp-content/uploads/2021/10/61amdwJRu-L._SX522_.jpg", "Garlic" },
                    { new Guid("abfd8d4c-01a1-44cf-9aee-9df17b295902"), 15, "https://www.thespruceeats.com/thmb/OueG44zJ3LnwQt9HwVXmmT6mkNM=/3067x3067/smart/filters:no_upscale()/roasted-boneless-pork-loin-recipe-995289-hero-01-93314ca221a54ecebc45a17e99cb78c4.jpg", "Pork" },
                    { new Guid("2a6a9318-e7d5-4ea9-9c0f-8c8101bad32d"), 12, "https://www.crescentfoods.lk/images/products/PREMIUM_CHICKEN_SAUSAGES.jpg", "Sausage" },
                    { new Guid("3e66d4df-070b-452c-b016-a9f20f309c2a"), 16, "https://preview.free3d.com/img/2017/05/2279485108920518249/e92jihnh-900.jpg", "Fish" },
                    { new Guid("3e883ff9-9a14-467d-9442-4913487ceb4b"), 9, "https://media.istockphoto.com/photos/fresh-citrus-juices-picture-id158268808?k=20&m=158268808&s=612x612&w=0&h=9mUMCBDaY-JYqR7m9r_mi0-Ta0RIebZ3DpxyimSQ7Fc=", "Juice" },
                    { new Guid("9d8ea165-d819-42be-9c33-785048e9fb35"), 8, "http://cdn.shopify.com/s/files/1/0404/0710/5687/products/6000200094505_grande.jpg?v=1595626016", "Broccoli" },
                    { new Guid("f86fa4a0-fe03-4f3f-8b22-de1ccaa0231d"), 13, "https://www.eatthis.com/wp-content/uploads/sites/4/2020/03/variety-of-beans.jpg?quality=82&strip=1", "Beans" },
                    { new Guid("4495956c-4cd1-485a-a696-ac268df6a414"), 12, "https://www.jessicagavin.com/wp-content/uploads/2019/02/carrots-7-1200.jpg", "Carrot" },
                    { new Guid("e118f4b9-c28f-4253-bc9a-55e35170541c"), 10, "https://www.farmersfamily.in/wp-content/uploads/2020/08/Cucumber.jpg", "Cucumber" },
                    { new Guid("d1ee06ed-55fd-4d16-8f6e-8a61a8f59d9f"), 14, "https://hips.hearstapps.com/hmg-prod/images/delish-roast-beef-horizontal-1540505165.jpg", "Beef" },
                    { new Guid("e758f9db-8764-455f-8859-11ecd11cf977"), 7, "https://img.freepik.com/free-vector/soda-cups-drink_24877-57922.jpg?w=2000", "Soda" }
                });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "Id", "FridgeModelId", "Name", "OwnerName" },
                values: new object[,]
                {
                    { new Guid("6966df84-13ad-4f0e-ad8a-8eb46001c17e"), new Guid("3836cb84-7fb4-45eb-9953-8c63279d4319"), "Liebherr", "Nastya" },
                    { new Guid("2604a4f5-e679-4cbb-93fe-94011f32e49f"), new Guid("cfdc5da0-9618-4034-8662-b39f38ca6be2"), "Stinol", "Vlada" },
                    { new Guid("b7392bbc-adb4-4baa-8709-7b03d7900110"), new Guid("30482cbb-33a5-4c17-b8c7-717ae49fb48a"), "Liebherr", "Anna" },
                    { new Guid("6d4a1831-0793-4282-ad4c-3f023b60a3b9"), new Guid("30482cbb-33a5-4c17-b8c7-717ae49fb48a"), "Atlant", "Anna" },
                    { new Guid("433c50a3-018b-475e-b0a5-e391f0c1fe6a"), new Guid("099bf9c9-3541-44e2-8684-b4a45a65465a"), "Atlant", "Nastya" }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("d4ea3723-742a-4bc8-8607-b556477b399d"), new Guid("6966df84-13ad-4f0e-ad8a-8eb46001c17e"), new Guid("76295722-b3bb-40f6-8996-8790fd8fa611"), 71 },
                    { new Guid("1c8f84a9-1f16-4f59-a715-0dd6272378fc"), new Guid("6d4a1831-0793-4282-ad4c-3f023b60a3b9"), new Guid("e3127588-62ed-4459-bbf5-562030ef456c"), 0 },
                    { new Guid("a21a4e36-aee9-4085-8617-1f6ab4e5a0cf"), new Guid("6d4a1831-0793-4282-ad4c-3f023b60a3b9"), new Guid("e118f4b9-c28f-4253-bc9a-55e35170541c"), 24 },
                    { new Guid("d8ffe227-ee80-48fb-883f-1de883b0b10e"), new Guid("6d4a1831-0793-4282-ad4c-3f023b60a3b9"), new Guid("54eee9f5-b83c-4344-aaf9-5aa0262e33d8"), 43 },
                    { new Guid("a7e26c3f-fad0-436e-bb6a-ea760c483da1"), new Guid("6d4a1831-0793-4282-ad4c-3f023b60a3b9"), new Guid("5e761121-326a-49e3-9170-da8b8631dcb6"), 41 },
                    { new Guid("12707ec3-79a1-4e2f-8405-358a1a82fc64"), new Guid("6d4a1831-0793-4282-ad4c-3f023b60a3b9"), new Guid("e758f9db-8764-455f-8859-11ecd11cf977"), 36 },
                    { new Guid("4e8f6b1d-fe59-4611-844c-fcdbd4422137"), new Guid("6d4a1831-0793-4282-ad4c-3f023b60a3b9"), new Guid("d5d582a4-0a16-4c8e-b680-dc1711c1867d"), 32 },
                    { new Guid("7ab34090-52de-497a-ac6a-660d5f14f7df"), new Guid("6d4a1831-0793-4282-ad4c-3f023b60a3b9"), new Guid("f86fa4a0-fe03-4f3f-8b22-de1ccaa0231d"), 24 },
                    { new Guid("85455191-ceb7-4124-b0d8-aef8530c6d9d"), new Guid("6d4a1831-0793-4282-ad4c-3f023b60a3b9"), new Guid("3e883ff9-9a14-467d-9442-4913487ceb4b"), 40 },
                    { new Guid("08837fba-3aaf-482d-9b80-c11871d8bb1b"), new Guid("6d4a1831-0793-4282-ad4c-3f023b60a3b9"), new Guid("a53daaf3-9eaa-4736-b5e8-6de65e45e4ec"), 72 },
                    { new Guid("0a86d9fc-4b63-420a-85bc-c1d409a508ec"), new Guid("6d4a1831-0793-4282-ad4c-3f023b60a3b9"), new Guid("76295722-b3bb-40f6-8996-8790fd8fa611"), 41 },
                    { new Guid("18312109-6b6e-419a-902c-685472ed25d4"), new Guid("6d4a1831-0793-4282-ad4c-3f023b60a3b9"), new Guid("fd89d73f-8b12-4a4b-bbd7-01b340b83718"), 13 },
                    { new Guid("570ed20a-0f6b-4079-ac38-5027d796df7a"), new Guid("6d4a1831-0793-4282-ad4c-3f023b60a3b9"), new Guid("780d00bb-7681-440a-8948-0db6091c8785"), 33 },
                    { new Guid("8db0c401-4107-4ac0-bad9-d27ddba7fbc0"), new Guid("6d4a1831-0793-4282-ad4c-3f023b60a3b9"), new Guid("b7e10d92-d054-41d6-9238-2b000d3cad7a"), 16 },
                    { new Guid("50870991-aa0e-4569-99c9-baee55e31dc4"), new Guid("6d4a1831-0793-4282-ad4c-3f023b60a3b9"), new Guid("8ee72798-bdf7-4871-a94a-02fc34c8f501"), 7 },
                    { new Guid("9a623512-0aec-4dc8-b902-b33b3409e122"), new Guid("6d4a1831-0793-4282-ad4c-3f023b60a3b9"), new Guid("5e47f106-4a55-4542-a656-c49a71b0ede3"), 65 },
                    { new Guid("4cb00569-4fea-448c-af66-b463365fbe17"), new Guid("6d4a1831-0793-4282-ad4c-3f023b60a3b9"), new Guid("9d8ea165-d819-42be-9c33-785048e9fb35"), 29 },
                    { new Guid("1ae65398-5729-45e5-a963-e1d268ba6d20"), new Guid("6d4a1831-0793-4282-ad4c-3f023b60a3b9"), new Guid("abfd8d4c-01a1-44cf-9aee-9df17b295902"), 10 },
                    { new Guid("23f545d2-fd29-4c3c-8f8f-736f9b083319"), new Guid("b7392bbc-adb4-4baa-8709-7b03d7900110"), new Guid("e3127588-62ed-4459-bbf5-562030ef456c"), 0 },
                    { new Guid("9a19f53e-d837-433e-bca0-d6aff1d6c231"), new Guid("b7392bbc-adb4-4baa-8709-7b03d7900110"), new Guid("a53daaf3-9eaa-4736-b5e8-6de65e45e4ec"), 13 },
                    { new Guid("4dd53005-7301-4698-a8eb-decb47df4d5e"), new Guid("b7392bbc-adb4-4baa-8709-7b03d7900110"), new Guid("d1ee06ed-55fd-4d16-8f6e-8a61a8f59d9f"), 4 },
                    { new Guid("7036bbc9-8d1c-4b6d-8cb1-5a213971e67f"), new Guid("b7392bbc-adb4-4baa-8709-7b03d7900110"), new Guid("92d00395-2800-4b4f-974e-18b27f27e525"), 19 },
                    { new Guid("34c9d737-d5e9-40c3-8776-074f2800f013"), new Guid("b7392bbc-adb4-4baa-8709-7b03d7900110"), new Guid("d4017dae-7d91-4aed-a5ce-2b46c5eada93"), 8 },
                    { new Guid("2843975d-da36-4643-ada3-69d377038018"), new Guid("b7392bbc-adb4-4baa-8709-7b03d7900110"), new Guid("f86fa4a0-fe03-4f3f-8b22-de1ccaa0231d"), 17 },
                    { new Guid("6498ba06-ddb8-4473-af3d-e7ad87b83baf"), new Guid("b7392bbc-adb4-4baa-8709-7b03d7900110"), new Guid("54eee9f5-b83c-4344-aaf9-5aa0262e33d8"), 67 },
                    { new Guid("fbde641f-1b53-4fe0-b478-3bb540880d4c"), new Guid("b7392bbc-adb4-4baa-8709-7b03d7900110"), new Guid("f4e5d78c-344b-4126-9ac8-58bbb0fac6a6"), 37 },
                    { new Guid("b0e9ea19-860e-4cec-a7e7-d061dace9ffb"), new Guid("6d4a1831-0793-4282-ad4c-3f023b60a3b9"), new Guid("1fa563d3-936b-4217-a200-2d514dd33f94"), 29 },
                    { new Guid("a62ef07c-ba75-46ce-aaff-78e84165c2eb"), new Guid("b7392bbc-adb4-4baa-8709-7b03d7900110"), new Guid("e758f9db-8764-455f-8859-11ecd11cf977"), 8 },
                    { new Guid("529f8c5f-359b-4a78-abf6-c426345d968f"), new Guid("6d4a1831-0793-4282-ad4c-3f023b60a3b9"), new Guid("5ead8209-d653-4bb9-af6a-5fbf888a9f18"), 7 },
                    { new Guid("5904aeab-6232-419f-b5e7-3c7c92866d68"), new Guid("6d4a1831-0793-4282-ad4c-3f023b60a3b9"), new Guid("4495956c-4cd1-485a-a696-ac268df6a414"), 31 },
                    { new Guid("5232a64f-ee12-4fe5-b875-2784ac5eac88"), new Guid("433c50a3-018b-475e-b0a5-e391f0c1fe6a"), new Guid("48cd87ec-0fa5-4725-8f8c-4b018aa8609a"), 9 },
                    { new Guid("ae8e2b99-c136-4a77-946d-aac9555d3f91"), new Guid("433c50a3-018b-475e-b0a5-e391f0c1fe6a"), new Guid("3e66d4df-070b-452c-b016-a9f20f309c2a"), 11 },
                    { new Guid("6f9f36d5-09ff-400b-a8ce-d25d95f01d12"), new Guid("433c50a3-018b-475e-b0a5-e391f0c1fe6a"), new Guid("76295722-b3bb-40f6-8996-8790fd8fa611"), 9 },
                    { new Guid("ca132267-27fe-4fce-b72e-ceabddd3dfc9"), new Guid("433c50a3-018b-475e-b0a5-e391f0c1fe6a"), new Guid("780d00bb-7681-440a-8948-0db6091c8785"), 15 },
                    { new Guid("b50c3c12-176d-4540-8f9f-01e40bd14571"), new Guid("433c50a3-018b-475e-b0a5-e391f0c1fe6a"), new Guid("6423ad10-758d-4a16-b2d5-36b6f3138290"), 3 },
                    { new Guid("28d5eea1-184d-49d9-8d29-0dba07bf166d"), new Guid("433c50a3-018b-475e-b0a5-e391f0c1fe6a"), new Guid("e758f9db-8764-455f-8859-11ecd11cf977"), 14 },
                    { new Guid("a87ad84b-6095-499e-9cc7-ac8e5f1ef56f"), new Guid("433c50a3-018b-475e-b0a5-e391f0c1fe6a"), new Guid("d1ee06ed-55fd-4d16-8f6e-8a61a8f59d9f"), 46 },
                    { new Guid("d99e9644-9365-4212-a17f-b2375ce779cc"), new Guid("433c50a3-018b-475e-b0a5-e391f0c1fe6a"), new Guid("f4e5d78c-344b-4126-9ac8-58bbb0fac6a6"), 12 },
                    { new Guid("9876bd7d-a846-4db9-972f-023c3955afb2"), new Guid("433c50a3-018b-475e-b0a5-e391f0c1fe6a"), new Guid("a53daaf3-9eaa-4736-b5e8-6de65e45e4ec"), 6 },
                    { new Guid("7dc48664-812c-45b0-8587-c3f4a243cfc8"), new Guid("433c50a3-018b-475e-b0a5-e391f0c1fe6a"), new Guid("abfd8d4c-01a1-44cf-9aee-9df17b295902"), 40 },
                    { new Guid("c1792ad2-d4fd-4df1-8cb9-5ca663bd3c3f"), new Guid("433c50a3-018b-475e-b0a5-e391f0c1fe6a"), new Guid("5e761121-326a-49e3-9170-da8b8631dcb6"), 4 },
                    { new Guid("b34e0090-9cdf-4ca2-b70b-04554c390ced"), new Guid("433c50a3-018b-475e-b0a5-e391f0c1fe6a"), new Guid("f86fa4a0-fe03-4f3f-8b22-de1ccaa0231d"), 6 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("478a2b52-b487-4697-adab-02526187638f"), new Guid("433c50a3-018b-475e-b0a5-e391f0c1fe6a"), new Guid("2a6a9318-e7d5-4ea9-9c0f-8c8101bad32d"), 15 },
                    { new Guid("a83fe128-6ef9-4ed5-a28d-3aebef8510bb"), new Guid("433c50a3-018b-475e-b0a5-e391f0c1fe6a"), new Guid("7ccc317c-6ddf-4bdb-bdbc-c5b647f68f35"), 22 },
                    { new Guid("cdd7f608-e356-4bef-9e74-eeb252c4de34"), new Guid("433c50a3-018b-475e-b0a5-e391f0c1fe6a"), new Guid("5d87fa2a-7402-4796-a154-6fd7347023fa"), 46 },
                    { new Guid("781ee8f1-bb5f-4ab2-87bc-d63977db63c1"), new Guid("433c50a3-018b-475e-b0a5-e391f0c1fe6a"), new Guid("5ead8209-d653-4bb9-af6a-5fbf888a9f18"), 28 },
                    { new Guid("ea7aa4d4-7c7f-46a5-920b-3e0ff2fb77dc"), new Guid("433c50a3-018b-475e-b0a5-e391f0c1fe6a"), new Guid("5eb62c67-8488-435c-821f-505779e9b43e"), 25 },
                    { new Guid("89494be0-7090-4e99-a9aa-9d901a1fe066"), new Guid("433c50a3-018b-475e-b0a5-e391f0c1fe6a"), new Guid("048d4efc-089b-453b-b778-a65d8c5e3d21"), 20 },
                    { new Guid("77fbc271-952d-4332-ad1b-f2f7e170b7a6"), new Guid("433c50a3-018b-475e-b0a5-e391f0c1fe6a"), new Guid("7100222f-745f-446a-a519-15b218c62e57"), 71 },
                    { new Guid("4da5d668-b6a6-4cb7-982a-7fc56773c597"), new Guid("433c50a3-018b-475e-b0a5-e391f0c1fe6a"), new Guid("d4017dae-7d91-4aed-a5ce-2b46c5eada93"), 26 },
                    { new Guid("cd820b2b-76d3-478e-a173-fbdd3beec491"), new Guid("433c50a3-018b-475e-b0a5-e391f0c1fe6a"), new Guid("f32c8667-8c8a-46de-866a-f8888e518b8f"), 29 },
                    { new Guid("0ee84cbb-ff60-40ba-a3da-3633ef466251"), new Guid("433c50a3-018b-475e-b0a5-e391f0c1fe6a"), new Guid("8a794cbe-0bdf-43dc-9553-f8101f49371b"), 77 },
                    { new Guid("8fe92ca8-6658-4412-b697-1a60b242d3e1"), new Guid("433c50a3-018b-475e-b0a5-e391f0c1fe6a"), new Guid("fd89d73f-8b12-4a4b-bbd7-01b340b83718"), 20 },
                    { new Guid("9f374111-5612-4e7a-95b9-59aa1f0dfba8"), new Guid("433c50a3-018b-475e-b0a5-e391f0c1fe6a"), new Guid("92d00395-2800-4b4f-974e-18b27f27e525"), 41 },
                    { new Guid("2e4aa706-2910-465f-bd64-203df3d36402"), new Guid("433c50a3-018b-475e-b0a5-e391f0c1fe6a"), new Guid("b6df4f09-41c3-4704-9ba5-a2829f695ae4"), 58 },
                    { new Guid("3f58415a-8c83-4a5d-88fc-f80b85e8759d"), new Guid("6d4a1831-0793-4282-ad4c-3f023b60a3b9"), new Guid("6456db6c-0656-4213-b64c-34c776f9f4f7"), 22 },
                    { new Guid("3f00c554-bf0c-40c6-92e1-4cd4b295f1ce"), new Guid("433c50a3-018b-475e-b0a5-e391f0c1fe6a"), new Guid("54eee9f5-b83c-4344-aaf9-5aa0262e33d8"), 26 },
                    { new Guid("74587077-1991-491f-adcd-644bbae18cf2"), new Guid("b7392bbc-adb4-4baa-8709-7b03d7900110"), new Guid("3e66d4df-070b-452c-b016-a9f20f309c2a"), 33 },
                    { new Guid("54c33fed-d54d-4683-81d2-6f5388b383a2"), new Guid("b7392bbc-adb4-4baa-8709-7b03d7900110"), new Guid("f0ddb097-faab-41e2-b6fd-8c7475e92d0c"), 27 },
                    { new Guid("5732fae5-cb36-4286-abce-9a9301ea67bc"), new Guid("2604a4f5-e679-4cbb-93fe-94011f32e49f"), new Guid("7ccc317c-6ddf-4bdb-bdbc-c5b647f68f35"), 41 },
                    { new Guid("66dac321-d4c7-4ad3-b4c9-db75243d6762"), new Guid("2604a4f5-e679-4cbb-93fe-94011f32e49f"), new Guid("f32c8667-8c8a-46de-866a-f8888e518b8f"), 26 },
                    { new Guid("5712946b-bf8c-4778-a877-5848a144ca5f"), new Guid("2604a4f5-e679-4cbb-93fe-94011f32e49f"), new Guid("2a6a9318-e7d5-4ea9-9c0f-8c8101bad32d"), 42 },
                    { new Guid("1d2dc83c-54df-4201-a49c-8db37e688450"), new Guid("6966df84-13ad-4f0e-ad8a-8eb46001c17e"), new Guid("abfd8d4c-01a1-44cf-9aee-9df17b295902"), 11 },
                    { new Guid("a90a3daf-b9ad-482e-bbf9-137c20cec695"), new Guid("6966df84-13ad-4f0e-ad8a-8eb46001c17e"), new Guid("d1ee06ed-55fd-4d16-8f6e-8a61a8f59d9f"), 11 },
                    { new Guid("a4416ece-f182-417d-8b8a-73ff1683a4f2"), new Guid("6966df84-13ad-4f0e-ad8a-8eb46001c17e"), new Guid("f0ddb097-faab-41e2-b6fd-8c7475e92d0c"), 12 },
                    { new Guid("0bdd0107-3e7e-492a-9ab8-2ad81ec17ad6"), new Guid("6966df84-13ad-4f0e-ad8a-8eb46001c17e"), new Guid("5ead8209-d653-4bb9-af6a-5fbf888a9f18"), 20 },
                    { new Guid("bdf697f6-599a-40e4-86cb-411740865f34"), new Guid("6966df84-13ad-4f0e-ad8a-8eb46001c17e"), new Guid("a53daaf3-9eaa-4736-b5e8-6de65e45e4ec"), 19 },
                    { new Guid("075ddcff-bc42-41ac-bf48-471fc2e8a112"), new Guid("6966df84-13ad-4f0e-ad8a-8eb46001c17e"), new Guid("48cd87ec-0fa5-4725-8f8c-4b018aa8609a"), 52 },
                    { new Guid("a15cf4a1-a629-4763-977e-65cf0802cc64"), new Guid("6966df84-13ad-4f0e-ad8a-8eb46001c17e"), new Guid("fd89d73f-8b12-4a4b-bbd7-01b340b83718"), 21 },
                    { new Guid("3cb422d3-0b5d-44fd-81a2-f9bc319bf123"), new Guid("6966df84-13ad-4f0e-ad8a-8eb46001c17e"), new Guid("780d00bb-7681-440a-8948-0db6091c8785"), 18 },
                    { new Guid("3f0cb6bd-c176-42b5-b55d-4e54c68888d8"), new Guid("6966df84-13ad-4f0e-ad8a-8eb46001c17e"), new Guid("7100222f-745f-446a-a519-15b218c62e57"), 26 },
                    { new Guid("0b83c109-7cb4-4ff8-91ce-8896ea7d709b"), new Guid("6966df84-13ad-4f0e-ad8a-8eb46001c17e"), new Guid("1fa563d3-936b-4217-a200-2d514dd33f94"), 36 },
                    { new Guid("37a1079c-c06d-45dd-ad97-96ccc42c1b93"), new Guid("6966df84-13ad-4f0e-ad8a-8eb46001c17e"), new Guid("8a794cbe-0bdf-43dc-9553-f8101f49371b"), 25 },
                    { new Guid("03130250-6158-4049-bd73-ba54684eb3fe"), new Guid("6966df84-13ad-4f0e-ad8a-8eb46001c17e"), new Guid("d4017dae-7d91-4aed-a5ce-2b46c5eada93"), 25 },
                    { new Guid("74e5a977-aab9-48bf-857d-418400c02410"), new Guid("6966df84-13ad-4f0e-ad8a-8eb46001c17e"), new Guid("3e883ff9-9a14-467d-9442-4913487ceb4b"), 11 },
                    { new Guid("bc7708fe-3f5a-4e39-9437-34c534aa73ff"), new Guid("6966df84-13ad-4f0e-ad8a-8eb46001c17e"), new Guid("e3127588-62ed-4459-bbf5-562030ef456c"), 23 },
                    { new Guid("5ee07599-dc16-407f-ac7e-3bd86b3db9ca"), new Guid("6966df84-13ad-4f0e-ad8a-8eb46001c17e"), new Guid("5d87fa2a-7402-4796-a154-6fd7347023fa"), 38 },
                    { new Guid("a84a735d-9784-46db-8d2b-8b8152d9bb74"), new Guid("6966df84-13ad-4f0e-ad8a-8eb46001c17e"), new Guid("b6df4f09-41c3-4704-9ba5-a2829f695ae4"), 16 },
                    { new Guid("31c37a32-b9b5-4e98-a620-8c53e8ac5397"), new Guid("6966df84-13ad-4f0e-ad8a-8eb46001c17e"), new Guid("b7e10d92-d054-41d6-9238-2b000d3cad7a"), 33 },
                    { new Guid("5f2a3285-77dd-43dd-84ec-e20a0ccedaf7"), new Guid("6966df84-13ad-4f0e-ad8a-8eb46001c17e"), new Guid("5eb62c67-8488-435c-821f-505779e9b43e"), 17 },
                    { new Guid("1be04df6-2ecf-4721-928e-a7e251213536"), new Guid("6966df84-13ad-4f0e-ad8a-8eb46001c17e"), new Guid("6423ad10-758d-4a16-b2d5-36b6f3138290"), 44 },
                    { new Guid("4aab5a74-268a-4ec1-9078-52635f214668"), new Guid("6966df84-13ad-4f0e-ad8a-8eb46001c17e"), new Guid("3e66d4df-070b-452c-b016-a9f20f309c2a"), 11 },
                    { new Guid("32b9296b-edbe-4bb2-8b94-8a8dc4170285"), new Guid("6966df84-13ad-4f0e-ad8a-8eb46001c17e"), new Guid("e758f9db-8764-455f-8859-11ecd11cf977"), 45 },
                    { new Guid("a7307b5e-19f5-458a-9f2c-0a4b76348987"), new Guid("6966df84-13ad-4f0e-ad8a-8eb46001c17e"), new Guid("8ee72798-bdf7-4871-a94a-02fc34c8f501"), 7 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("675539fe-4033-46cf-9da2-15136d105964"), new Guid("2604a4f5-e679-4cbb-93fe-94011f32e49f"), new Guid("048d4efc-089b-453b-b778-a65d8c5e3d21"), 50 },
                    { new Guid("ef8ec41c-3eac-410f-b715-018012f5f827"), new Guid("b7392bbc-adb4-4baa-8709-7b03d7900110"), new Guid("5e47f106-4a55-4542-a656-c49a71b0ede3"), 50 },
                    { new Guid("e8ad185c-6ae9-425e-a4e5-ddceb5648138"), new Guid("2604a4f5-e679-4cbb-93fe-94011f32e49f"), new Guid("5eb62c67-8488-435c-821f-505779e9b43e"), 9 },
                    { new Guid("9cc3dd34-785c-458c-b619-ff787a32e0bf"), new Guid("2604a4f5-e679-4cbb-93fe-94011f32e49f"), new Guid("f86fa4a0-fe03-4f3f-8b22-de1ccaa0231d"), 30 },
                    { new Guid("801e30ce-9260-4214-a3da-1d8abc1858c1"), new Guid("b7392bbc-adb4-4baa-8709-7b03d7900110"), new Guid("4495956c-4cd1-485a-a696-ac268df6a414"), 35 },
                    { new Guid("8ec95f12-336f-4765-938c-6abceae44b2f"), new Guid("b7392bbc-adb4-4baa-8709-7b03d7900110"), new Guid("8ee72798-bdf7-4871-a94a-02fc34c8f501"), 7 },
                    { new Guid("a65a9014-05d1-4c9a-84e4-c4dbdf025b28"), new Guid("b7392bbc-adb4-4baa-8709-7b03d7900110"), new Guid("9d8ea165-d819-42be-9c33-785048e9fb35"), 71 },
                    { new Guid("800d11b3-d9e1-463a-82f3-59e290327c58"), new Guid("b7392bbc-adb4-4baa-8709-7b03d7900110"), new Guid("48cd87ec-0fa5-4725-8f8c-4b018aa8609a"), 9 },
                    { new Guid("62ec2c8f-5b55-4ba5-80b4-ac0b13461750"), new Guid("b7392bbc-adb4-4baa-8709-7b03d7900110"), new Guid("d5d582a4-0a16-4c8e-b680-dc1711c1867d"), 20 },
                    { new Guid("79314478-64cf-404f-a076-ab4b15b1c89d"), new Guid("b7392bbc-adb4-4baa-8709-7b03d7900110"), new Guid("7ccc317c-6ddf-4bdb-bdbc-c5b647f68f35"), 44 },
                    { new Guid("5a7e16a0-e28d-4a98-9abc-688234c509a0"), new Guid("b7392bbc-adb4-4baa-8709-7b03d7900110"), new Guid("5e761121-326a-49e3-9170-da8b8631dcb6"), 29 },
                    { new Guid("2e1a9e80-b946-4302-a43c-87daafc10452"), new Guid("b7392bbc-adb4-4baa-8709-7b03d7900110"), new Guid("e118f4b9-c28f-4253-bc9a-55e35170541c"), 104 },
                    { new Guid("08da333e-4cab-468a-8817-1c9275b8ef96"), new Guid("b7392bbc-adb4-4baa-8709-7b03d7900110"), new Guid("6456db6c-0656-4213-b64c-34c776f9f4f7"), 56 },
                    { new Guid("db2174aa-bc86-481f-9a8c-9da9bede44d5"), new Guid("2604a4f5-e679-4cbb-93fe-94011f32e49f"), new Guid("5d87fa2a-7402-4796-a154-6fd7347023fa"), 8 },
                    { new Guid("3fa303bc-bc17-430c-9e66-55da0e44bf80"), new Guid("2604a4f5-e679-4cbb-93fe-94011f32e49f"), new Guid("54eee9f5-b83c-4344-aaf9-5aa0262e33d8"), 12 },
                    { new Guid("46167141-da16-4bab-9ea6-d0062f1ec8d8"), new Guid("2604a4f5-e679-4cbb-93fe-94011f32e49f"), new Guid("abfd8d4c-01a1-44cf-9aee-9df17b295902"), 38 },
                    { new Guid("7336b94b-75c7-448c-91df-535fc614e65f"), new Guid("2604a4f5-e679-4cbb-93fe-94011f32e49f"), new Guid("f4e5d78c-344b-4126-9ac8-58bbb0fac6a6"), 29 },
                    { new Guid("bdba9215-f3bf-44eb-bf3c-a25fa3f084af"), new Guid("2604a4f5-e679-4cbb-93fe-94011f32e49f"), new Guid("6456db6c-0656-4213-b64c-34c776f9f4f7"), 26 },
                    { new Guid("9704bb4c-ee6b-41ae-91c6-848cd4d486d7"), new Guid("2604a4f5-e679-4cbb-93fe-94011f32e49f"), new Guid("3e66d4df-070b-452c-b016-a9f20f309c2a"), 40 },
                    { new Guid("b52fa428-a4a6-46b7-96d4-1066173ed78a"), new Guid("2604a4f5-e679-4cbb-93fe-94011f32e49f"), new Guid("6423ad10-758d-4a16-b2d5-36b6f3138290"), 13 },
                    { new Guid("89c29461-b104-40aa-9345-966b7b6b18e6"), new Guid("2604a4f5-e679-4cbb-93fe-94011f32e49f"), new Guid("4495956c-4cd1-485a-a696-ac268df6a414"), 13 },
                    { new Guid("f8197c3a-97fe-42d4-aaac-9ef6f22eebc6"), new Guid("2604a4f5-e679-4cbb-93fe-94011f32e49f"), new Guid("e118f4b9-c28f-4253-bc9a-55e35170541c"), 13 },
                    { new Guid("5e86a0f3-9e8d-4dc1-95ba-de1f10d7181e"), new Guid("2604a4f5-e679-4cbb-93fe-94011f32e49f"), new Guid("f0ddb097-faab-41e2-b6fd-8c7475e92d0c"), 45 },
                    { new Guid("e3d40398-8c18-4507-96d5-8bc8e47aa792"), new Guid("2604a4f5-e679-4cbb-93fe-94011f32e49f"), new Guid("92d00395-2800-4b4f-974e-18b27f27e525"), 72 },
                    { new Guid("a0ad6a6a-3f0d-419b-88f6-b62d3f3163ea"), new Guid("2604a4f5-e679-4cbb-93fe-94011f32e49f"), new Guid("8a794cbe-0bdf-43dc-9553-f8101f49371b"), 15 },
                    { new Guid("b0f7230e-dd32-4118-adaa-e95471b8fbeb"), new Guid("2604a4f5-e679-4cbb-93fe-94011f32e49f"), new Guid("3e883ff9-9a14-467d-9442-4913487ceb4b"), 17 },
                    { new Guid("232eb078-7d30-49ed-8913-b124d43ae7b0"), new Guid("2604a4f5-e679-4cbb-93fe-94011f32e49f"), new Guid("5e761121-326a-49e3-9170-da8b8631dcb6"), 47 },
                    { new Guid("3087c5d3-2092-4361-88d4-28a5a38bb741"), new Guid("2604a4f5-e679-4cbb-93fe-94011f32e49f"), new Guid("9d8ea165-d819-42be-9c33-785048e9fb35"), 63 },
                    { new Guid("bd748b20-c2ce-4107-bd7d-d39a7a2da631"), new Guid("2604a4f5-e679-4cbb-93fe-94011f32e49f"), new Guid("d1ee06ed-55fd-4d16-8f6e-8a61a8f59d9f"), 61 },
                    { new Guid("c1d22e43-22c8-4624-93ab-b929b7eae692"), new Guid("2604a4f5-e679-4cbb-93fe-94011f32e49f"), new Guid("b6df4f09-41c3-4704-9ba5-a2829f695ae4"), 81 },
                    { new Guid("4b4e7fb5-89a8-4124-b344-80fd7c0e2ee9"), new Guid("433c50a3-018b-475e-b0a5-e391f0c1fe6a"), new Guid("3e883ff9-9a14-467d-9442-4913487ceb4b"), 0 }
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
