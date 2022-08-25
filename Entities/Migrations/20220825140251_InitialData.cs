using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FridgeModels",
                columns: new[] { "Id", "Name", "Year" },
                values: new object[,]
                {
                    { new Guid("89432c98-ed08-4f29-ad65-c048aa54e66f"), "TH-803", 2013 },
                    { new Guid("636c9cc3-6d74-4d18-a236-55b3b6b36271"), "RSA1SHVB1", 2019 },
                    { new Guid("5d643efa-3320-4602-b34f-ad683c6a1e9d"), "VF 395-1 SBS", 2015 },
                    { new Guid("7a5521f6-c232-4938-9804-acd18d1c6b67"), "SBS 7212", 2011 },
                    { new Guid("da882f2b-a9d1-4885-ad7a-4fb21b037561"), "Electric MR-CR46G-HS-R", 2016 },
                    { new Guid("673099f8-5b2d-496c-8c02-0f0466a530b7"), "VF 910 X", 2011 },
                    { new Guid("0977597e-b6ab-4960-8ac1-4ed96224ca04"), "RB-34 K6220SS", 2010 },
                    { new Guid("ecf08f01-0604-4c7c-9234-5d9f345734c0"), "RF-61 K90407F", 2013 },
                    { new Guid("97e496af-060b-477d-a285-847f4991dfd8"), "VF 466 EB", 2010 },
                    { new Guid("c227ed9e-4b5c-4d34-af1b-0956a0e883c4"), "DS 333020", 2016 },
                    { new Guid("a57f4319-b951-40e9-92b3-eac5fba21003"), "DF 5180 W", 2016 },
                    { new Guid("35771bd8-26bd-497b-938c-a55099f952c2"), "XM 4021-000", 2011 },
                    { new Guid("70684b7d-92bf-49f1-bedb-ca7bc4ba4b14"), "RC-54", 2012 },
                    { new Guid("787d1096-7547-4a5e-b0e9-af06789682f1"), "514-NWE", 2018 },
                    { new Guid("9cdeb1aa-0036-41b7-855f-50b7df8b6a9c"), "KGN36S55", 2012 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DefaultQuantity", "Name" },
                values: new object[,]
                {
                    { new Guid("a0727fce-fdab-4e90-ae51-c1e2edf8c566"), 9, "Raspberry" },
                    { new Guid("e07d13af-670a-4007-81b0-fee1549a4cdd"), 11, "Cherry" },
                    { new Guid("7722ebfc-348b-4a21-b4c3-92885d502243"), 17, "Grape" },
                    { new Guid("cb3ede17-203b-4d62-86a6-58e6c450eab9"), 14, "Lemon" },
                    { new Guid("a018210b-34a6-4936-adfd-d71f847945e7"), 6, "Orange" },
                    { new Guid("267b0412-ec7a-414b-8261-bcde651a5d8c"), 11, "Peach" },
                    { new Guid("0c8d3521-d24e-49e7-b56f-598fb443065a"), 16, "Strawberry" },
                    { new Guid("6f911a57-e7a3-4ff5-84af-50644af5eba5"), 9, "Watermelon" },
                    { new Guid("0da14e05-3453-4244-9fbe-8adb4d677910"), 13, "Jelly" },
                    { new Guid("18ef1ad3-45eb-4f81-b2a4-d4edefd0eb67"), 7, "Milk" },
                    { new Guid("4124cddb-9ab2-418c-ae07-f28ef8c9d9b6"), 6, "Kefir" },
                    { new Guid("c0ee6038-f5e2-4fa1-a8fe-4b0d175d3c17"), 5, "Chocolate" },
                    { new Guid("58dd9c8d-05c6-472c-9db6-e0fb6c40dd82"), 15, "Jam" },
                    { new Guid("70707f26-d2c5-4308-8512-fd69b6dafe57"), 14, "Pudding" },
                    { new Guid("82093098-15d2-4cc4-b8d3-67b66eee0a23"), 6, "Banana" },
                    { new Guid("d844ecc8-8cf9-485a-aaf1-73da20822d1f"), 12, "Pancake" },
                    { new Guid("df76aeb1-3c2f-4f6a-bf7d-90d50847d2b4"), 15, "Butter" },
                    { new Guid("739f2bf4-0f45-4e49-9a28-545d2480a4d3"), 7, "Potato" },
                    { new Guid("ceaff4f6-a3e0-438a-b26d-a5efe8f85aa1"), 7, "Avocado" },
                    { new Guid("2d9c1c30-ea45-4c31-bd85-23e8d3a1a51c"), 15, "Onion" },
                    { new Guid("22b511bb-bdd7-4224-a596-da3f2904f3ef"), 15, "Bread" },
                    { new Guid("214f319f-4a77-40a5-b386-8bb02531c72c"), 15, "Apple" },
                    { new Guid("a5d673b5-7e29-4e5a-9afb-2f08bdcce7f0"), 17, "Yoghurt" },
                    { new Guid("38c1541f-7377-42fb-997e-9dc5d63541d9"), 16, "Egg" },
                    { new Guid("8f753d8c-61ce-4b6c-b5be-daa3ae81986e"), 16, "Cheese" },
                    { new Guid("29800b01-12d3-48fe-a2b1-9683c54fb675"), 13, "Mashroom" },
                    { new Guid("3fedf8b0-73b2-4da1-8e8d-04855a166f7c"), 6, "Chicken" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DefaultQuantity", "Name" },
                values: new object[,]
                {
                    { new Guid("e251d874-d59d-4b1c-b1bd-4f909df9f9e9"), 14, "Garlic" },
                    { new Guid("ec491952-30b7-4f54-8509-3795c1d412b0"), 6, "Pork" },
                    { new Guid("ea2d7c77-61e9-48e5-96ae-059738191711"), 8, "Sausage" },
                    { new Guid("a1fef996-b37c-44b7-846a-d5363d25e762"), 14, "Fish" },
                    { new Guid("7ca21d7c-dc0b-43b5-ac90-ef067100a65a"), 16, "Juice" },
                    { new Guid("fef3cfc6-7238-4bbe-9b5e-5892a66413f4"), 13, "Broccoli" },
                    { new Guid("3cec2a04-0e6d-4608-bd82-6aa0e479f615"), 6, "Beans" },
                    { new Guid("2aef949d-09a2-49ff-b763-a74b3b464c7a"), 11, "Carrot" },
                    { new Guid("10e854c7-c49c-4752-91c6-128abc68e3cb"), 11, "Cucumber" },
                    { new Guid("62f6c28b-ed7d-4f4f-9d05-4e12d543c5cd"), 15, "Beef" },
                    { new Guid("3c1a0f0e-90e9-48cc-9fd4-d38deac70b52"), 8, "Soda" }
                });

            migrationBuilder.InsertData(
                table: "Fridges",
                columns: new[] { "Id", "FridgeModelId", "Name", "OwnerName" },
                values: new object[,]
                {
                    { new Guid("9ca69a10-1689-4de6-8a70-87522495fa30"), new Guid("89432c98-ed08-4f29-ad65-c048aa54e66f"), "Atlant", "Nastya" },
                    { new Guid("f5de0450-7ded-40ab-9d2f-546851161b6f"), new Guid("5d643efa-3320-4602-b34f-ad683c6a1e9d"), "Philips", "Andrew" },
                    { new Guid("1bc3301d-e132-41d7-b4d5-6fb639aac4c1"), new Guid("5d643efa-3320-4602-b34f-ad683c6a1e9d"), "Philips", "Kirill" },
                    { new Guid("4e189220-d31b-4cef-a19c-82f5acc92dc6"), new Guid("7a5521f6-c232-4938-9804-acd18d1c6b67"), "Indesit", "Andrew" },
                    { new Guid("2921fe0c-f6f2-4939-923e-8fd878c1c243"), new Guid("7a5521f6-c232-4938-9804-acd18d1c6b67"), "Indesit", "Kirill" },
                    { new Guid("ea581127-602c-4f5e-b601-b61da930855e"), new Guid("ecf08f01-0604-4c7c-9234-5d9f345734c0"), "Indesit", "Andrew" },
                    { new Guid("957d2895-38d4-4ae0-96c1-1d7a87fdc6bc"), new Guid("0977597e-b6ab-4960-8ac1-4ed96224ca04"), "Vestfrost", "Nastya" },
                    { new Guid("7d9663ec-ff37-4dd3-9a14-1eb6d6f7d8df"), new Guid("9cdeb1aa-0036-41b7-855f-50b7df8b6a9c"), "Vestfrost", "Mariya" },
                    { new Guid("16ceb523-89fb-4141-9d0b-a9d94dd9e4d3"), new Guid("9cdeb1aa-0036-41b7-855f-50b7df8b6a9c"), "Liebherr", "Polina" },
                    { new Guid("db6c1c25-77ed-456c-8dd7-e9e491a62f35"), new Guid("97e496af-060b-477d-a285-847f4991dfd8"), "Liebherr", "Polina" },
                    { new Guid("4d40b3e7-dae1-4410-8619-a16a9646c445"), new Guid("97e496af-060b-477d-a285-847f4991dfd8"), "Beko", "Polina" },
                    { new Guid("467a286d-fb73-47e4-9696-5c7e9efe36ed"), new Guid("c227ed9e-4b5c-4d34-af1b-0956a0e883c4"), "Philips", "Kirill" },
                    { new Guid("3dddc8a5-d1d4-428a-9552-f62b6728bac5"), new Guid("c227ed9e-4b5c-4d34-af1b-0956a0e883c4"), "Philips", "Andrew" },
                    { new Guid("1eca9dd4-85c1-4f39-a298-e18a8f435db2"), new Guid("a57f4319-b951-40e9-92b3-eac5fba21003"), "Samsung", "Kirill" },
                    { new Guid("570a85c1-3431-4875-9844-b3b91d0dbc5f"), new Guid("a57f4319-b951-40e9-92b3-eac5fba21003"), "Samsung", "Andrew" },
                    { new Guid("2a2a9044-813d-44ac-ad8a-80f377bef1db"), new Guid("35771bd8-26bd-497b-938c-a55099f952c2"), "Bosch", "Anna" },
                    { new Guid("ffe5652b-5cc1-4cb2-9976-aba17cff3f67"), new Guid("70684b7d-92bf-49f1-bedb-ca7bc4ba4b14"), "Stinol", "Vlada" },
                    { new Guid("68d87710-9322-4143-95f7-b0462c8741ca"), new Guid("787d1096-7547-4a5e-b0e9-af06789682f1"), "Bosch", "Mariya" },
                    { new Guid("3d683e69-5118-489c-ba23-94a14836ee2d"), new Guid("5d643efa-3320-4602-b34f-ad683c6a1e9d"), "Beko", "Polina" },
                    { new Guid("e8c640e8-f666-4341-8e6e-f15b9d3a32e5"), new Guid("636c9cc3-6d74-4d18-a236-55b3b6b36271"), "Liebherr", "Nastya" }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("bcdac1da-a65e-43cd-9ea8-e6902292abbb"), new Guid("9ca69a10-1689-4de6-8a70-87522495fa30"), new Guid("ec491952-30b7-4f54-8509-3795c1d412b0"), 33 },
                    { new Guid("18b605cb-e711-4a41-a95c-5bcc68d1436d"), new Guid("ea581127-602c-4f5e-b601-b61da930855e"), new Guid("62f6c28b-ed7d-4f4f-9d05-4e12d543c5cd"), 28 },
                    { new Guid("afe00aee-4393-462b-b260-712be381f9b0"), new Guid("ea581127-602c-4f5e-b601-b61da930855e"), new Guid("a0727fce-fdab-4e90-ae51-c1e2edf8c566"), 20 },
                    { new Guid("794cf8ba-ecd2-4dce-b7ed-12154122c704"), new Guid("ea581127-602c-4f5e-b601-b61da930855e"), new Guid("0c8d3521-d24e-49e7-b56f-598fb443065a"), 67 },
                    { new Guid("d55c98d0-b0d5-4c25-9606-a07cec6c933e"), new Guid("ea581127-602c-4f5e-b601-b61da930855e"), new Guid("ec491952-30b7-4f54-8509-3795c1d412b0"), 10 },
                    { new Guid("52b0b148-b007-4531-a688-c288eaa8807c"), new Guid("ea581127-602c-4f5e-b601-b61da930855e"), new Guid("8f753d8c-61ce-4b6c-b5be-daa3ae81986e"), 4 },
                    { new Guid("175738c6-354b-47a3-a301-9b2ffdea648d"), new Guid("ea581127-602c-4f5e-b601-b61da930855e"), new Guid("267b0412-ec7a-414b-8261-bcde651a5d8c"), 12 },
                    { new Guid("81496350-f60c-46b4-831d-87447f304647"), new Guid("ea581127-602c-4f5e-b601-b61da930855e"), new Guid("2d9c1c30-ea45-4c31-bd85-23e8d3a1a51c"), 6 },
                    { new Guid("3d8fba9a-84df-423b-a93e-d49bec3db333"), new Guid("ea581127-602c-4f5e-b601-b61da930855e"), new Guid("6f911a57-e7a3-4ff5-84af-50644af5eba5"), 10 },
                    { new Guid("5b77f46f-f7c1-4679-979b-a4619f1d1fc1"), new Guid("ea581127-602c-4f5e-b601-b61da930855e"), new Guid("29800b01-12d3-48fe-a2b1-9683c54fb675"), 56 },
                    { new Guid("4f8aff52-28e0-4fff-b1cf-ede94b305844"), new Guid("2921fe0c-f6f2-4939-923e-8fd878c1c243"), new Guid("58dd9c8d-05c6-472c-9db6-e0fb6c40dd82"), 36 },
                    { new Guid("8afdcee5-1d33-4938-b9ff-633451b8af4b"), new Guid("2921fe0c-f6f2-4939-923e-8fd878c1c243"), new Guid("3cec2a04-0e6d-4608-bd82-6aa0e479f615"), 12 },
                    { new Guid("53848cb9-83e8-445b-945d-dce40ac8cc23"), new Guid("2921fe0c-f6f2-4939-923e-8fd878c1c243"), new Guid("ceaff4f6-a3e0-438a-b26d-a5efe8f85aa1"), 11 },
                    { new Guid("2004a2ea-0df6-460a-9ac7-eec181744c34"), new Guid("2921fe0c-f6f2-4939-923e-8fd878c1c243"), new Guid("2aef949d-09a2-49ff-b763-a74b3b464c7a"), 54 },
                    { new Guid("fd8e5949-77ef-40a9-8bfa-4169d2ff082b"), new Guid("2921fe0c-f6f2-4939-923e-8fd878c1c243"), new Guid("70707f26-d2c5-4308-8512-fd69b6dafe57"), 56 },
                    { new Guid("f8a95b97-cbd7-4e6a-8207-5fb41f1320b9"), new Guid("2921fe0c-f6f2-4939-923e-8fd878c1c243"), new Guid("d844ecc8-8cf9-485a-aaf1-73da20822d1f"), 14 },
                    { new Guid("a0d636d0-4004-4b11-96f1-977c26342982"), new Guid("2921fe0c-f6f2-4939-923e-8fd878c1c243"), new Guid("10e854c7-c49c-4752-91c6-128abc68e3cb"), 29 },
                    { new Guid("5551067f-4f44-4ab2-8d18-412bdb260bc0"), new Guid("2921fe0c-f6f2-4939-923e-8fd878c1c243"), new Guid("0da14e05-3453-4244-9fbe-8adb4d677910"), 13 },
                    { new Guid("f3029c17-29aa-4fc9-bd3d-a2736d0d8aac"), new Guid("2921fe0c-f6f2-4939-923e-8fd878c1c243"), new Guid("4124cddb-9ab2-418c-ae07-f28ef8c9d9b6"), 5 },
                    { new Guid("2ee38acf-ce7b-48a6-8cf2-7c093f8904a2"), new Guid("2921fe0c-f6f2-4939-923e-8fd878c1c243"), new Guid("c0ee6038-f5e2-4fa1-a8fe-4b0d175d3c17"), 6 },
                    { new Guid("946e5d65-fadd-45cb-a86a-49784f0be5e8"), new Guid("2921fe0c-f6f2-4939-923e-8fd878c1c243"), new Guid("a018210b-34a6-4936-adfd-d71f847945e7"), 9 },
                    { new Guid("89b6d3a8-0f27-4885-847c-786515f7a145"), new Guid("957d2895-38d4-4ae0-96c1-1d7a87fdc6bc"), new Guid("ea2d7c77-61e9-48e5-96ae-059738191711"), 3 },
                    { new Guid("8f69b08f-bdef-4ede-9f99-51b4a0ca6268"), new Guid("957d2895-38d4-4ae0-96c1-1d7a87fdc6bc"), new Guid("38c1541f-7377-42fb-997e-9dc5d63541d9"), 9 },
                    { new Guid("a44457a7-b744-434b-858c-f825bedc7349"), new Guid("16ceb523-89fb-4141-9d0b-a9d94dd9e4d3"), new Guid("e07d13af-670a-4007-81b0-fee1549a4cdd"), 29 },
                    { new Guid("f419e1fc-3b4a-4edf-9fc6-7b4f07ee2162"), new Guid("16ceb523-89fb-4141-9d0b-a9d94dd9e4d3"), new Guid("739f2bf4-0f45-4e49-9a28-545d2480a4d3"), 0 },
                    { new Guid("009503e6-c3b7-40c6-8501-b339833e9123"), new Guid("16ceb523-89fb-4141-9d0b-a9d94dd9e4d3"), new Guid("22b511bb-bdd7-4224-a596-da3f2904f3ef"), 10 },
                    { new Guid("77087145-9ad3-4ec3-b27e-5f7eb14827eb"), new Guid("16ceb523-89fb-4141-9d0b-a9d94dd9e4d3"), new Guid("a5d673b5-7e29-4e5a-9afb-2f08bdcce7f0"), 1 },
                    { new Guid("4785a00b-818f-4107-9b4d-7ff1facbfd19"), new Guid("7d9663ec-ff37-4dd3-9a14-1eb6d6f7d8df"), new Guid("df76aeb1-3c2f-4f6a-bf7d-90d50847d2b4"), 14 },
                    { new Guid("74d6f43d-57cb-4b8b-8470-58d5b86fc5cd"), new Guid("7d9663ec-ff37-4dd3-9a14-1eb6d6f7d8df"), new Guid("ceaff4f6-a3e0-438a-b26d-a5efe8f85aa1"), 8 },
                    { new Guid("92e4221f-2a14-4928-8ed7-c179257db54f"), new Guid("7d9663ec-ff37-4dd3-9a14-1eb6d6f7d8df"), new Guid("a1fef996-b37c-44b7-846a-d5363d25e762"), 39 },
                    { new Guid("0732192a-9455-496c-a6b4-5ac63e8e78dd"), new Guid("7d9663ec-ff37-4dd3-9a14-1eb6d6f7d8df"), new Guid("ea2d7c77-61e9-48e5-96ae-059738191711"), 7 },
                    { new Guid("1b00ed2a-d906-458e-a016-2e4077e55ccb"), new Guid("957d2895-38d4-4ae0-96c1-1d7a87fdc6bc"), new Guid("e07d13af-670a-4007-81b0-fee1549a4cdd"), 7 },
                    { new Guid("241fe6b0-918e-4827-8fc8-236ebd0613a2"), new Guid("7d9663ec-ff37-4dd3-9a14-1eb6d6f7d8df"), new Guid("fef3cfc6-7238-4bbe-9b5e-5892a66413f4"), 11 },
                    { new Guid("2902784d-09e2-49b4-bdaf-bcb6a391416f"), new Guid("7d9663ec-ff37-4dd3-9a14-1eb6d6f7d8df"), new Guid("c0ee6038-f5e2-4fa1-a8fe-4b0d175d3c17"), 12 },
                    { new Guid("1aba23c0-0f84-4270-a9e5-187cc352bada"), new Guid("7d9663ec-ff37-4dd3-9a14-1eb6d6f7d8df"), new Guid("4124cddb-9ab2-418c-ae07-f28ef8c9d9b6"), 4 },
                    { new Guid("653bdacd-131c-4011-aab2-a0c65c1c933f"), new Guid("7d9663ec-ff37-4dd3-9a14-1eb6d6f7d8df"), new Guid("6f911a57-e7a3-4ff5-84af-50644af5eba5"), 3 },
                    { new Guid("2e22820f-dd21-4698-95f3-aca3574db55d"), new Guid("957d2895-38d4-4ae0-96c1-1d7a87fdc6bc"), new Guid("a0727fce-fdab-4e90-ae51-c1e2edf8c566"), 13 },
                    { new Guid("386f18ae-efe2-4914-a29b-2121eb9737fc"), new Guid("957d2895-38d4-4ae0-96c1-1d7a87fdc6bc"), new Guid("a5d673b5-7e29-4e5a-9afb-2f08bdcce7f0"), 27 },
                    { new Guid("2acdf4c5-0710-4dec-9af7-c91a8717df03"), new Guid("957d2895-38d4-4ae0-96c1-1d7a87fdc6bc"), new Guid("7722ebfc-348b-4a21-b4c3-92885d502243"), 31 },
                    { new Guid("4c0305c5-66bd-42fd-a778-ce5eae0fadd8"), new Guid("957d2895-38d4-4ae0-96c1-1d7a87fdc6bc"), new Guid("cb3ede17-203b-4d62-86a6-58e6c450eab9"), 12 },
                    { new Guid("7a9820d5-a6fd-4db0-a08c-7a9448b1a684"), new Guid("957d2895-38d4-4ae0-96c1-1d7a87fdc6bc"), new Guid("58dd9c8d-05c6-472c-9db6-e0fb6c40dd82"), 5 },
                    { new Guid("dfd1f06d-cc27-43e7-a018-177f913fbbd2"), new Guid("7d9663ec-ff37-4dd3-9a14-1eb6d6f7d8df"), new Guid("18ef1ad3-45eb-4f81-b2a4-d4edefd0eb67"), 27 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("434f6fad-fc94-4358-ab36-cd2f9cca04f7"), new Guid("16ceb523-89fb-4141-9d0b-a9d94dd9e4d3"), new Guid("7722ebfc-348b-4a21-b4c3-92885d502243"), 2 },
                    { new Guid("70312332-696f-4319-841c-9e151a464bb5"), new Guid("4e189220-d31b-4cef-a19c-82f5acc92dc6"), new Guid("10e854c7-c49c-4752-91c6-128abc68e3cb"), 12 },
                    { new Guid("ccb2475f-d660-42e4-ae4d-9ddb5f7fc2f4"), new Guid("4e189220-d31b-4cef-a19c-82f5acc92dc6"), new Guid("d844ecc8-8cf9-485a-aaf1-73da20822d1f"), 19 },
                    { new Guid("391294ab-2430-453b-9c4e-311d253bb48d"), new Guid("f5de0450-7ded-40ab-9d2f-546851161b6f"), new Guid("4124cddb-9ab2-418c-ae07-f28ef8c9d9b6"), 4 },
                    { new Guid("362e69e4-0491-441c-b283-b349bbf196bd"), new Guid("f5de0450-7ded-40ab-9d2f-546851161b6f"), new Guid("0da14e05-3453-4244-9fbe-8adb4d677910"), 33 },
                    { new Guid("c949dc67-9313-4a78-989b-6c66802acabc"), new Guid("3d683e69-5118-489c-ba23-94a14836ee2d"), new Guid("3c1a0f0e-90e9-48cc-9fd4-d38deac70b52"), 39 },
                    { new Guid("35e4eb67-f7b2-4a73-be38-dedca8fbc7c4"), new Guid("3d683e69-5118-489c-ba23-94a14836ee2d"), new Guid("739f2bf4-0f45-4e49-9a28-545d2480a4d3"), 23 },
                    { new Guid("bc9c5286-73fc-40b3-b258-acf32beb446b"), new Guid("3d683e69-5118-489c-ba23-94a14836ee2d"), new Guid("7ca21d7c-dc0b-43b5-ac90-ef067100a65a"), 21 },
                    { new Guid("0ff58656-eff5-4405-a0cf-105f23c53b27"), new Guid("3d683e69-5118-489c-ba23-94a14836ee2d"), new Guid("82093098-15d2-4cc4-b8d3-67b66eee0a23"), 1 },
                    { new Guid("bfd5c4e9-085e-47bc-84e5-6b04dcef6b19"), new Guid("3d683e69-5118-489c-ba23-94a14836ee2d"), new Guid("ec491952-30b7-4f54-8509-3795c1d412b0"), 3 },
                    { new Guid("203ebc35-c70b-4df3-abd5-16a5a9ce051a"), new Guid("3d683e69-5118-489c-ba23-94a14836ee2d"), new Guid("22b511bb-bdd7-4224-a596-da3f2904f3ef"), 15 },
                    { new Guid("665efce3-80d0-465d-b841-5ccb0e425ade"), new Guid("f5de0450-7ded-40ab-9d2f-546851161b6f"), new Guid("2aef949d-09a2-49ff-b763-a74b3b464c7a"), 6 },
                    { new Guid("8dbc81a8-0fed-4c37-8eb7-df54e3999b4c"), new Guid("3d683e69-5118-489c-ba23-94a14836ee2d"), new Guid("2d9c1c30-ea45-4c31-bd85-23e8d3a1a51c"), 14 },
                    { new Guid("06844d88-6246-4277-876e-18fcb2ee011a"), new Guid("e8c640e8-f666-4341-8e6e-f15b9d3a32e5"), new Guid("fef3cfc6-7238-4bbe-9b5e-5892a66413f4"), 5 },
                    { new Guid("51fbd1af-12fe-47b9-bc5e-b9e9b9a3c7e6"), new Guid("e8c640e8-f666-4341-8e6e-f15b9d3a32e5"), new Guid("18ef1ad3-45eb-4f81-b2a4-d4edefd0eb67"), 11 },
                    { new Guid("5d4b8561-4905-4146-9d1f-27ee7c92ad4e"), new Guid("e8c640e8-f666-4341-8e6e-f15b9d3a32e5"), new Guid("ea2d7c77-61e9-48e5-96ae-059738191711"), 41 },
                    { new Guid("1e8f132c-e295-4e62-8d9d-08e803c11a40"), new Guid("e8c640e8-f666-4341-8e6e-f15b9d3a32e5"), new Guid("a0727fce-fdab-4e90-ae51-c1e2edf8c566"), 19 },
                    { new Guid("cc9da592-7f56-4412-b49d-c79c4c23a59b"), new Guid("e8c640e8-f666-4341-8e6e-f15b9d3a32e5"), new Guid("6f911a57-e7a3-4ff5-84af-50644af5eba5"), 28 },
                    { new Guid("6cd88648-63a7-4208-81d2-be6298986f46"), new Guid("e8c640e8-f666-4341-8e6e-f15b9d3a32e5"), new Guid("df76aeb1-3c2f-4f6a-bf7d-90d50847d2b4"), 18 },
                    { new Guid("4e263d7c-420b-4c3f-ad60-cd136c57e95a"), new Guid("e8c640e8-f666-4341-8e6e-f15b9d3a32e5"), new Guid("ec491952-30b7-4f54-8509-3795c1d412b0"), 20 },
                    { new Guid("33d47fe9-0541-4fa0-9f0b-ecd97610973f"), new Guid("e8c640e8-f666-4341-8e6e-f15b9d3a32e5"), new Guid("62f6c28b-ed7d-4f4f-9d05-4e12d543c5cd"), 50 },
                    { new Guid("03527ffd-d4fa-45ac-9951-824a32bb8d42"), new Guid("3d683e69-5118-489c-ba23-94a14836ee2d"), new Guid("e251d874-d59d-4b1c-b1bd-4f909df9f9e9"), 13 },
                    { new Guid("a7e471e0-7517-4f7f-856c-ffec02d79e36"), new Guid("4e189220-d31b-4cef-a19c-82f5acc92dc6"), new Guid("58dd9c8d-05c6-472c-9db6-e0fb6c40dd82"), 25 },
                    { new Guid("df683b64-3bda-4cfc-9a94-9884188298c8"), new Guid("f5de0450-7ded-40ab-9d2f-546851161b6f"), new Guid("7ca21d7c-dc0b-43b5-ac90-ef067100a65a"), 0 },
                    { new Guid("67ff68c1-15c1-4799-98d2-14576be646c0"), new Guid("f5de0450-7ded-40ab-9d2f-546851161b6f"), new Guid("29800b01-12d3-48fe-a2b1-9683c54fb675"), 3 },
                    { new Guid("ee57c437-d61f-436c-b435-275eb0e99454"), new Guid("4e189220-d31b-4cef-a19c-82f5acc92dc6"), new Guid("70707f26-d2c5-4308-8512-fd69b6dafe57"), 24 },
                    { new Guid("bb7243c7-85c4-4897-ace5-fd9569acda85"), new Guid("4e189220-d31b-4cef-a19c-82f5acc92dc6"), new Guid("2aef949d-09a2-49ff-b763-a74b3b464c7a"), 24 },
                    { new Guid("fbfd03a5-0ca2-42b6-831e-c8e24fa74358"), new Guid("4e189220-d31b-4cef-a19c-82f5acc92dc6"), new Guid("3cec2a04-0e6d-4608-bd82-6aa0e479f615"), 29 },
                    { new Guid("cfa06e20-e696-4922-9d92-cf1be5bfdd15"), new Guid("4e189220-d31b-4cef-a19c-82f5acc92dc6"), new Guid("c0ee6038-f5e2-4fa1-a8fe-4b0d175d3c17"), 12 },
                    { new Guid("67a75e86-60c5-4ce5-95bc-484eda2e21b8"), new Guid("1bc3301d-e132-41d7-b4d5-6fb639aac4c1"), new Guid("ea2d7c77-61e9-48e5-96ae-059738191711"), 42 },
                    { new Guid("bbf0f55c-d20a-4c2a-8215-fc65adacbafc"), new Guid("1bc3301d-e132-41d7-b4d5-6fb639aac4c1"), new Guid("62f6c28b-ed7d-4f4f-9d05-4e12d543c5cd"), 32 },
                    { new Guid("6e84f67c-1028-43e0-86f7-ad28cbc35bb4"), new Guid("1bc3301d-e132-41d7-b4d5-6fb639aac4c1"), new Guid("6f911a57-e7a3-4ff5-84af-50644af5eba5"), 44 },
                    { new Guid("9ea75804-57d9-4b3a-a6a6-c2d410f081c0"), new Guid("1bc3301d-e132-41d7-b4d5-6fb639aac4c1"), new Guid("a1fef996-b37c-44b7-846a-d5363d25e762"), 4 },
                    { new Guid("22251f50-0a29-4c5c-8e39-22fd9a14bde4"), new Guid("f5de0450-7ded-40ab-9d2f-546851161b6f"), new Guid("10e854c7-c49c-4752-91c6-128abc68e3cb"), 12 },
                    { new Guid("8c96dbd3-f12b-4493-a93f-120631af3e7a"), new Guid("1bc3301d-e132-41d7-b4d5-6fb639aac4c1"), new Guid("18ef1ad3-45eb-4f81-b2a4-d4edefd0eb67"), 22 },
                    { new Guid("b44c8c6e-36f5-48b8-9b71-7541e4bc624b"), new Guid("1bc3301d-e132-41d7-b4d5-6fb639aac4c1"), new Guid("df76aeb1-3c2f-4f6a-bf7d-90d50847d2b4"), 50 },
                    { new Guid("ddbaa6f1-e6aa-43d2-85e1-6e06b695f81d"), new Guid("1bc3301d-e132-41d7-b4d5-6fb639aac4c1"), new Guid("3c1a0f0e-90e9-48cc-9fd4-d38deac70b52"), 7 },
                    { new Guid("ac66dccc-ac51-489c-b6ce-caee5c194b53"), new Guid("1bc3301d-e132-41d7-b4d5-6fb639aac4c1"), new Guid("ec491952-30b7-4f54-8509-3795c1d412b0"), 3 },
                    { new Guid("0c1fed35-91b5-42ef-ba68-fcf42ba0ef35"), new Guid("f5de0450-7ded-40ab-9d2f-546851161b6f"), new Guid("3cec2a04-0e6d-4608-bd82-6aa0e479f615"), 12 },
                    { new Guid("05763bde-31fa-42a0-b4ea-b451d9cb32c5"), new Guid("f5de0450-7ded-40ab-9d2f-546851161b6f"), new Guid("d844ecc8-8cf9-485a-aaf1-73da20822d1f"), 12 },
                    { new Guid("1f41f786-6897-4550-81d6-f1b90bb6c9b4"), new Guid("f5de0450-7ded-40ab-9d2f-546851161b6f"), new Guid("3c1a0f0e-90e9-48cc-9fd4-d38deac70b52"), 0 },
                    { new Guid("28e002d7-edb5-4c47-95ab-2444a12215a9"), new Guid("f5de0450-7ded-40ab-9d2f-546851161b6f"), new Guid("2d9c1c30-ea45-4c31-bd85-23e8d3a1a51c"), 39 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("a740ba57-ac7b-4d23-a363-b18cdadf4072"), new Guid("f5de0450-7ded-40ab-9d2f-546851161b6f"), new Guid("e251d874-d59d-4b1c-b1bd-4f909df9f9e9"), 0 },
                    { new Guid("29358abe-91c4-4515-be3e-671b1d1671cc"), new Guid("1bc3301d-e132-41d7-b4d5-6fb639aac4c1"), new Guid("a0727fce-fdab-4e90-ae51-c1e2edf8c566"), 30 },
                    { new Guid("5eef8641-4e7d-49df-81f6-52dc0e5e7610"), new Guid("16ceb523-89fb-4141-9d0b-a9d94dd9e4d3"), new Guid("82093098-15d2-4cc4-b8d3-67b66eee0a23"), 8 },
                    { new Guid("eb8118ab-2e4e-4a77-9867-449b461ee9d1"), new Guid("16ceb523-89fb-4141-9d0b-a9d94dd9e4d3"), new Guid("214f319f-4a77-40a5-b386-8bb02531c72c"), 51 },
                    { new Guid("926a8b73-3beb-44b9-862f-3a95600c1c73"), new Guid("db6c1c25-77ed-456c-8dd7-e9e491a62f35"), new Guid("22b511bb-bdd7-4224-a596-da3f2904f3ef"), 1 },
                    { new Guid("4cfef9dc-df64-41ee-9a5d-3b5be3d3a1cd"), new Guid("ffe5652b-5cc1-4cb2-9976-aba17cff3f67"), new Guid("18ef1ad3-45eb-4f81-b2a4-d4edefd0eb67"), 9 },
                    { new Guid("8a9aa61f-ea86-47e1-a00d-0b1afffebc99"), new Guid("ffe5652b-5cc1-4cb2-9976-aba17cff3f67"), new Guid("214f319f-4a77-40a5-b386-8bb02531c72c"), 1 },
                    { new Guid("255a0e43-f42c-458c-a247-2ce9a26612af"), new Guid("ffe5652b-5cc1-4cb2-9976-aba17cff3f67"), new Guid("a018210b-34a6-4936-adfd-d71f847945e7"), 9 },
                    { new Guid("47d660c9-460a-4da8-b7bb-8685b2528f5a"), new Guid("ffe5652b-5cc1-4cb2-9976-aba17cff3f67"), new Guid("2aef949d-09a2-49ff-b763-a74b3b464c7a"), 13 },
                    { new Guid("569d8813-eac6-44bc-ac73-adb4b5fccb3c"), new Guid("ffe5652b-5cc1-4cb2-9976-aba17cff3f67"), new Guid("c0ee6038-f5e2-4fa1-a8fe-4b0d175d3c17"), 17 },
                    { new Guid("00e4f7eb-d5fa-45df-9cf4-22d40b471374"), new Guid("ffe5652b-5cc1-4cb2-9976-aba17cff3f67"), new Guid("4124cddb-9ab2-418c-ae07-f28ef8c9d9b6"), 40 },
                    { new Guid("3e0cc690-6878-4899-9ef6-8e23d2ee6f9e"), new Guid("ffe5652b-5cc1-4cb2-9976-aba17cff3f67"), new Guid("a1fef996-b37c-44b7-846a-d5363d25e762"), 5 },
                    { new Guid("3ddab5d6-84f5-4c43-a97c-3a7f456422e3"), new Guid("ffe5652b-5cc1-4cb2-9976-aba17cff3f67"), new Guid("3fedf8b0-73b2-4da1-8e8d-04855a166f7c"), 10 },
                    { new Guid("d85bfcee-5cce-4608-b23a-76412aa8c196"), new Guid("ffe5652b-5cc1-4cb2-9976-aba17cff3f67"), new Guid("fef3cfc6-7238-4bbe-9b5e-5892a66413f4"), 29 },
                    { new Guid("723293b4-4431-49ab-91a4-280fe2801018"), new Guid("2a2a9044-813d-44ac-ad8a-80f377bef1db"), new Guid("0da14e05-3453-4244-9fbe-8adb4d677910"), 12 },
                    { new Guid("d81a082d-5c06-4eec-8d53-a38802f5a63e"), new Guid("2a2a9044-813d-44ac-ad8a-80f377bef1db"), new Guid("267b0412-ec7a-414b-8261-bcde651a5d8c"), 49 },
                    { new Guid("e900cfbd-3f9a-4caa-bf1a-3b84ef0976b3"), new Guid("2a2a9044-813d-44ac-ad8a-80f377bef1db"), new Guid("a018210b-34a6-4936-adfd-d71f847945e7"), 26 },
                    { new Guid("150fb49b-e3f2-494c-946a-7872c42ee57e"), new Guid("2a2a9044-813d-44ac-ad8a-80f377bef1db"), new Guid("3fedf8b0-73b2-4da1-8e8d-04855a166f7c"), 32 },
                    { new Guid("491801ca-9589-4897-bca4-132810d6f7d0"), new Guid("2a2a9044-813d-44ac-ad8a-80f377bef1db"), new Guid("29800b01-12d3-48fe-a2b1-9683c54fb675"), 12 },
                    { new Guid("2102e762-84d4-4a3d-a050-8f3170ecc0b6"), new Guid("2a2a9044-813d-44ac-ad8a-80f377bef1db"), new Guid("a1fef996-b37c-44b7-846a-d5363d25e762"), 11 },
                    { new Guid("9e1e6601-fd30-4137-9c03-7174c147b7be"), new Guid("570a85c1-3431-4875-9844-b3b91d0dbc5f"), new Guid("7722ebfc-348b-4a21-b4c3-92885d502243"), 28 },
                    { new Guid("c99a9006-dbf3-4778-921f-ea445c747e47"), new Guid("570a85c1-3431-4875-9844-b3b91d0dbc5f"), new Guid("a5d673b5-7e29-4e5a-9afb-2f08bdcce7f0"), 20 },
                    { new Guid("93d913c6-5369-423f-8617-88cbe0462625"), new Guid("570a85c1-3431-4875-9844-b3b91d0dbc5f"), new Guid("38c1541f-7377-42fb-997e-9dc5d63541d9"), 25 },
                    { new Guid("708ed2ce-7b1e-496b-a328-2ea4860921d3"), new Guid("2a2a9044-813d-44ac-ad8a-80f377bef1db"), new Guid("8f753d8c-61ce-4b6c-b5be-daa3ae81986e"), 41 },
                    { new Guid("d4261d60-6b8d-4e40-87dd-0e47aaf36bf3"), new Guid("570a85c1-3431-4875-9844-b3b91d0dbc5f"), new Guid("3c1a0f0e-90e9-48cc-9fd4-d38deac70b52"), 0 },
                    { new Guid("9f18dacf-73d2-4671-be9c-3b624d8b2340"), new Guid("ffe5652b-5cc1-4cb2-9976-aba17cff3f67"), new Guid("58dd9c8d-05c6-472c-9db6-e0fb6c40dd82"), 66 },
                    { new Guid("415ace7f-56b2-4093-8b5b-482f26d59e88"), new Guid("ffe5652b-5cc1-4cb2-9976-aba17cff3f67"), new Guid("3cec2a04-0e6d-4608-bd82-6aa0e479f615"), 17 },
                    { new Guid("7ba69eed-abbd-487b-b431-1e445efcdd23"), new Guid("9ca69a10-1689-4de6-8a70-87522495fa30"), new Guid("8f753d8c-61ce-4b6c-b5be-daa3ae81986e"), 2 },
                    { new Guid("d49d8cd3-b65b-470a-a080-d87942589672"), new Guid("9ca69a10-1689-4de6-8a70-87522495fa30"), new Guid("a0727fce-fdab-4e90-ae51-c1e2edf8c566"), 29 },
                    { new Guid("44c53c74-f86c-4832-8a1f-5d79d0eac619"), new Guid("9ca69a10-1689-4de6-8a70-87522495fa30"), new Guid("29800b01-12d3-48fe-a2b1-9683c54fb675"), 32 },
                    { new Guid("9a140fbf-a806-4474-b66d-68694fcd3cc9"), new Guid("9ca69a10-1689-4de6-8a70-87522495fa30"), new Guid("6f911a57-e7a3-4ff5-84af-50644af5eba5"), 22 },
                    { new Guid("c4ef3177-49aa-46e9-9847-380a8cd228d4"), new Guid("9ca69a10-1689-4de6-8a70-87522495fa30"), new Guid("0c8d3521-d24e-49e7-b56f-598fb443065a"), 9 },
                    { new Guid("23820f1b-fe22-478b-8584-6de11c2fc412"), new Guid("9ca69a10-1689-4de6-8a70-87522495fa30"), new Guid("62f6c28b-ed7d-4f4f-9d05-4e12d543c5cd"), 10 },
                    { new Guid("89bfd518-364a-4fd0-a592-dee5bb3d364a"), new Guid("9ca69a10-1689-4de6-8a70-87522495fa30"), new Guid("3fedf8b0-73b2-4da1-8e8d-04855a166f7c"), 13 },
                    { new Guid("8e42a086-9c27-4ed8-bf20-9b5d1314b548"), new Guid("68d87710-9322-4143-95f7-b0462c8741ca"), new Guid("3cec2a04-0e6d-4608-bd82-6aa0e479f615"), 5 },
                    { new Guid("050d1f6a-fe7a-4d70-9f57-f5bb07271661"), new Guid("ffe5652b-5cc1-4cb2-9976-aba17cff3f67"), new Guid("ceaff4f6-a3e0-438a-b26d-a5efe8f85aa1"), 33 },
                    { new Guid("df1d0cb9-3b15-4497-a430-f6b8d8e65ee4"), new Guid("68d87710-9322-4143-95f7-b0462c8741ca"), new Guid("38c1541f-7377-42fb-997e-9dc5d63541d9"), 10 },
                    { new Guid("d73fbbe9-7cd6-4098-a855-c2a681f3fea1"), new Guid("68d87710-9322-4143-95f7-b0462c8741ca"), new Guid("29800b01-12d3-48fe-a2b1-9683c54fb675"), 10 },
                    { new Guid("5f24751f-1108-42f1-a4c8-57e473dfbcf5"), new Guid("68d87710-9322-4143-95f7-b0462c8741ca"), new Guid("267b0412-ec7a-414b-8261-bcde651a5d8c"), 2 },
                    { new Guid("ac0b5e8b-dab5-437d-8670-4c5dcd0d2098"), new Guid("68d87710-9322-4143-95f7-b0462c8741ca"), new Guid("3fedf8b0-73b2-4da1-8e8d-04855a166f7c"), 3 },
                    { new Guid("4fcc4443-dc6e-476b-b263-bd62edf72187"), new Guid("68d87710-9322-4143-95f7-b0462c8741ca"), new Guid("0da14e05-3453-4244-9fbe-8adb4d677910"), 6 },
                    { new Guid("53acf3a2-2722-46a3-b2c5-73c5ee9f185f"), new Guid("68d87710-9322-4143-95f7-b0462c8741ca"), new Guid("a018210b-34a6-4936-adfd-d71f847945e7"), 13 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("431cd348-fdff-40f5-a7ef-e277cf06bf61"), new Guid("68d87710-9322-4143-95f7-b0462c8741ca"), new Guid("0c8d3521-d24e-49e7-b56f-598fb443065a"), 3 },
                    { new Guid("c40845f2-98bb-42c2-9f61-271c6e4b1816"), new Guid("68d87710-9322-4143-95f7-b0462c8741ca"), new Guid("c0ee6038-f5e2-4fa1-a8fe-4b0d175d3c17"), 5 },
                    { new Guid("21efd648-c21e-4d02-8996-2096d25ee424"), new Guid("68d87710-9322-4143-95f7-b0462c8741ca"), new Guid("cb3ede17-203b-4d62-86a6-58e6c450eab9"), 11 },
                    { new Guid("07f4450b-c789-4508-838c-b85b531a16a0"), new Guid("68d87710-9322-4143-95f7-b0462c8741ca"), new Guid("8f753d8c-61ce-4b6c-b5be-daa3ae81986e"), 36 },
                    { new Guid("d30bcbcd-dd8b-4ad8-a6c8-1767372cfc82"), new Guid("570a85c1-3431-4875-9844-b3b91d0dbc5f"), new Guid("214f319f-4a77-40a5-b386-8bb02531c72c"), 25 },
                    { new Guid("8f24055d-4cb1-4c1e-9fd5-6d8f8c7422aa"), new Guid("570a85c1-3431-4875-9844-b3b91d0dbc5f"), new Guid("e07d13af-670a-4007-81b0-fee1549a4cdd"), 1 },
                    { new Guid("b95e40a8-0f3d-4440-b402-06c78e8c3511"), new Guid("570a85c1-3431-4875-9844-b3b91d0dbc5f"), new Guid("8f753d8c-61ce-4b6c-b5be-daa3ae81986e"), 9 },
                    { new Guid("035659fd-eb84-425c-8b0a-7e6a75e5c96a"), new Guid("467a286d-fb73-47e4-9696-5c7e9efe36ed"), new Guid("82093098-15d2-4cc4-b8d3-67b66eee0a23"), 1 },
                    { new Guid("17140e5b-259d-46e0-b465-c332234702ab"), new Guid("467a286d-fb73-47e4-9696-5c7e9efe36ed"), new Guid("7ca21d7c-dc0b-43b5-ac90-ef067100a65a"), 7 },
                    { new Guid("2e339d24-d484-43f7-b2f7-15a35634ceec"), new Guid("4d40b3e7-dae1-4410-8619-a16a9646c445"), new Guid("3c1a0f0e-90e9-48cc-9fd4-d38deac70b52"), 7 },
                    { new Guid("fd845df3-f26d-4e35-8972-07654a7e834f"), new Guid("4d40b3e7-dae1-4410-8619-a16a9646c445"), new Guid("df76aeb1-3c2f-4f6a-bf7d-90d50847d2b4"), 51 },
                    { new Guid("4c5965c7-79b3-464d-b62b-b41db27ee496"), new Guid("4d40b3e7-dae1-4410-8619-a16a9646c445"), new Guid("ceaff4f6-a3e0-438a-b26d-a5efe8f85aa1"), 43 },
                    { new Guid("3efb0839-2d33-4736-8b5e-0cf97c2b98a3"), new Guid("4d40b3e7-dae1-4410-8619-a16a9646c445"), new Guid("18ef1ad3-45eb-4f81-b2a4-d4edefd0eb67"), 42 },
                    { new Guid("7c5ec7f8-6922-4caf-9251-05e6515bbd76"), new Guid("4d40b3e7-dae1-4410-8619-a16a9646c445"), new Guid("62f6c28b-ed7d-4f4f-9d05-4e12d543c5cd"), 15 },
                    { new Guid("8b84be2b-101d-48fb-96cd-25217ee24963"), new Guid("4d40b3e7-dae1-4410-8619-a16a9646c445"), new Guid("4124cddb-9ab2-418c-ae07-f28ef8c9d9b6"), 17 },
                    { new Guid("06775948-535f-4bbe-bb65-64e7165b1f18"), new Guid("467a286d-fb73-47e4-9696-5c7e9efe36ed"), new Guid("d844ecc8-8cf9-485a-aaf1-73da20822d1f"), 0 },
                    { new Guid("8e8e737f-de53-4608-bf4a-9cb0a39a8bfe"), new Guid("4d40b3e7-dae1-4410-8619-a16a9646c445"), new Guid("a1fef996-b37c-44b7-846a-d5363d25e762"), 21 },
                    { new Guid("1342c601-0e25-4825-b10f-49f04f055275"), new Guid("db6c1c25-77ed-456c-8dd7-e9e491a62f35"), new Guid("3cec2a04-0e6d-4608-bd82-6aa0e479f615"), 12 },
                    { new Guid("ec499ca0-16b6-4eef-b08c-7f8637ff8c69"), new Guid("db6c1c25-77ed-456c-8dd7-e9e491a62f35"), new Guid("e07d13af-670a-4007-81b0-fee1549a4cdd"), 13 },
                    { new Guid("8b49fc8e-6489-4a78-8ee5-9f517ad207fe"), new Guid("db6c1c25-77ed-456c-8dd7-e9e491a62f35"), new Guid("a5d673b5-7e29-4e5a-9afb-2f08bdcce7f0"), 10 },
                    { new Guid("c55ba825-2fe5-422e-a0ea-0afd1ed63b2f"), new Guid("db6c1c25-77ed-456c-8dd7-e9e491a62f35"), new Guid("3c1a0f0e-90e9-48cc-9fd4-d38deac70b52"), 0 },
                    { new Guid("fb533aaa-c435-48f9-af8d-2bf3b3037c93"), new Guid("db6c1c25-77ed-456c-8dd7-e9e491a62f35"), new Guid("6f911a57-e7a3-4ff5-84af-50644af5eba5"), 11 },
                    { new Guid("933173ad-5926-40d5-82eb-a041f112aca6"), new Guid("db6c1c25-77ed-456c-8dd7-e9e491a62f35"), new Guid("739f2bf4-0f45-4e49-9a28-545d2480a4d3"), 0 },
                    { new Guid("d45a031c-14be-4593-b1d9-8d4d9d2ff263"), new Guid("db6c1c25-77ed-456c-8dd7-e9e491a62f35"), new Guid("214f319f-4a77-40a5-b386-8bb02531c72c"), 16 },
                    { new Guid("cf1d19ea-ce44-4622-b05e-59c10f427a8b"), new Guid("db6c1c25-77ed-456c-8dd7-e9e491a62f35"), new Guid("82093098-15d2-4cc4-b8d3-67b66eee0a23"), 1 },
                    { new Guid("a9d3c244-a823-447c-81a6-27a59852830e"), new Guid("4d40b3e7-dae1-4410-8619-a16a9646c445"), new Guid("ea2d7c77-61e9-48e5-96ae-059738191711"), 19 },
                    { new Guid("aefd32a3-ee91-49b7-94c9-f9b60da119de"), new Guid("467a286d-fb73-47e4-9696-5c7e9efe36ed"), new Guid("3c1a0f0e-90e9-48cc-9fd4-d38deac70b52"), 22 },
                    { new Guid("aa853841-2bd4-49a2-9af0-c88e44eb8328"), new Guid("467a286d-fb73-47e4-9696-5c7e9efe36ed"), new Guid("22b511bb-bdd7-4224-a596-da3f2904f3ef"), 2 },
                    { new Guid("cbd97226-5f63-4a98-832a-dbae809694f5"), new Guid("467a286d-fb73-47e4-9696-5c7e9efe36ed"), new Guid("e251d874-d59d-4b1c-b1bd-4f909df9f9e9"), 7 },
                    { new Guid("56950507-fe6d-43d5-8432-bc0a09d1cd7c"), new Guid("570a85c1-3431-4875-9844-b3b91d0dbc5f"), new Guid("a018210b-34a6-4936-adfd-d71f847945e7"), 2 },
                    { new Guid("ec9e7d6b-0974-4818-a3f1-165b463e3e39"), new Guid("570a85c1-3431-4875-9844-b3b91d0dbc5f"), new Guid("267b0412-ec7a-414b-8261-bcde651a5d8c"), 9 },
                    { new Guid("c0258c90-50cb-47d7-91a9-7d3b43b4d9e0"), new Guid("1eca9dd4-85c1-4f39-a298-e18a8f435db2"), new Guid("58dd9c8d-05c6-472c-9db6-e0fb6c40dd82"), 27 },
                    { new Guid("c2c7ff40-c47e-4130-bdb7-2817bcb0c358"), new Guid("1eca9dd4-85c1-4f39-a298-e18a8f435db2"), new Guid("4124cddb-9ab2-418c-ae07-f28ef8c9d9b6"), 36 },
                    { new Guid("823b340c-bc4d-4807-9b57-d88e362129fe"), new Guid("1eca9dd4-85c1-4f39-a298-e18a8f435db2"), new Guid("fef3cfc6-7238-4bbe-9b5e-5892a66413f4"), 43 },
                    { new Guid("d50fb274-39de-4620-8a2b-ea33b46259a8"), new Guid("1eca9dd4-85c1-4f39-a298-e18a8f435db2"), new Guid("c0ee6038-f5e2-4fa1-a8fe-4b0d175d3c17"), 80 },
                    { new Guid("f6f23a55-b466-4496-82dd-b5ae28afa3e5"), new Guid("1eca9dd4-85c1-4f39-a298-e18a8f435db2"), new Guid("3cec2a04-0e6d-4608-bd82-6aa0e479f615"), 29 },
                    { new Guid("65ded067-609c-4065-b1c7-e6127b2295ec"), new Guid("1eca9dd4-85c1-4f39-a298-e18a8f435db2"), new Guid("a1fef996-b37c-44b7-846a-d5363d25e762"), 11 },
                    { new Guid("4a82f30a-48bb-4deb-8a83-39ec9b3c9723"), new Guid("1eca9dd4-85c1-4f39-a298-e18a8f435db2"), new Guid("ceaff4f6-a3e0-438a-b26d-a5efe8f85aa1"), 5 },
                    { new Guid("93bbea34-d46f-4341-823d-a75eab213107"), new Guid("1eca9dd4-85c1-4f39-a298-e18a8f435db2"), new Guid("18ef1ad3-45eb-4f81-b2a4-d4edefd0eb67"), 11 },
                    { new Guid("02c40018-8ef1-4761-bc14-2ad0524ddc90"), new Guid("3dddc8a5-d1d4-428a-9552-f62b6728bac5"), new Guid("0da14e05-3453-4244-9fbe-8adb4d677910"), 53 },
                    { new Guid("23aac44b-85a8-4a8d-9186-d5c0a3b26804"), new Guid("3dddc8a5-d1d4-428a-9552-f62b6728bac5"), new Guid("2d9c1c30-ea45-4c31-bd85-23e8d3a1a51c"), 59 },
                    { new Guid("81dbcbed-9504-4136-9927-21b10b04472f"), new Guid("3dddc8a5-d1d4-428a-9552-f62b6728bac5"), new Guid("e251d874-d59d-4b1c-b1bd-4f909df9f9e9"), 13 }
                });

            migrationBuilder.InsertData(
                table: "FridgeProducts",
                columns: new[] { "Id", "FridgeId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("a6975f8d-e422-4271-b20d-5f19697f2519"), new Guid("3dddc8a5-d1d4-428a-9552-f62b6728bac5"), new Guid("10e854c7-c49c-4752-91c6-128abc68e3cb"), 61 },
                    { new Guid("b10a45f0-1669-48aa-819f-dc562d21763a"), new Guid("3dddc8a5-d1d4-428a-9552-f62b6728bac5"), new Guid("7ca21d7c-dc0b-43b5-ac90-ef067100a65a"), 0 },
                    { new Guid("611b59fa-7792-44cc-8c92-cedaca53d7f2"), new Guid("3dddc8a5-d1d4-428a-9552-f62b6728bac5"), new Guid("d844ecc8-8cf9-485a-aaf1-73da20822d1f"), 31 },
                    { new Guid("dc22fa9b-3b4e-40be-a519-31c7007e4713"), new Guid("3dddc8a5-d1d4-428a-9552-f62b6728bac5"), new Guid("70707f26-d2c5-4308-8512-fd69b6dafe57"), 6 },
                    { new Guid("c57f157c-ab83-4c47-b972-6c927ac248f7"), new Guid("3dddc8a5-d1d4-428a-9552-f62b6728bac5"), new Guid("a1fef996-b37c-44b7-846a-d5363d25e762"), 11 },
                    { new Guid("5caeaa73-eed6-4004-b87d-3cc8752a6385"), new Guid("467a286d-fb73-47e4-9696-5c7e9efe36ed"), new Guid("739f2bf4-0f45-4e49-9a28-545d2480a4d3"), 17 },
                    { new Guid("ab09ad9b-3026-4f7b-925c-a045db9da27f"), new Guid("e8c640e8-f666-4341-8e6e-f15b9d3a32e5"), new Guid("0c8d3521-d24e-49e7-b56f-598fb443065a"), 11 },
                    { new Guid("ffee1fe5-92f9-4937-9037-95ba63d34f94"), new Guid("e8c640e8-f666-4341-8e6e-f15b9d3a32e5"), new Guid("38c1541f-7377-42fb-997e-9dc5d63541d9"), 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FridgeModels",
                keyColumn: "Id",
                keyValue: new Guid("673099f8-5b2d-496c-8c02-0f0466a530b7"));

            migrationBuilder.DeleteData(
                table: "FridgeModels",
                keyColumn: "Id",
                keyValue: new Guid("da882f2b-a9d1-4885-ad7a-4fb21b037561"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("009503e6-c3b7-40c6-8501-b339833e9123"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("00e4f7eb-d5fa-45df-9cf4-22d40b471374"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("02c40018-8ef1-4761-bc14-2ad0524ddc90"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("03527ffd-d4fa-45ac-9951-824a32bb8d42"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("035659fd-eb84-425c-8b0a-7e6a75e5c96a"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("050d1f6a-fe7a-4d70-9f57-f5bb07271661"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("05763bde-31fa-42a0-b4ea-b451d9cb32c5"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("06775948-535f-4bbe-bb65-64e7165b1f18"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("06844d88-6246-4277-876e-18fcb2ee011a"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("0732192a-9455-496c-a6b4-5ac63e8e78dd"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("07f4450b-c789-4508-838c-b85b531a16a0"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("0c1fed35-91b5-42ef-ba68-fcf42ba0ef35"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("0ff58656-eff5-4405-a0cf-105f23c53b27"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("1342c601-0e25-4825-b10f-49f04f055275"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("150fb49b-e3f2-494c-946a-7872c42ee57e"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("17140e5b-259d-46e0-b465-c332234702ab"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("175738c6-354b-47a3-a301-9b2ffdea648d"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("18b605cb-e711-4a41-a95c-5bcc68d1436d"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("1aba23c0-0f84-4270-a9e5-187cc352bada"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("1b00ed2a-d906-458e-a016-2e4077e55ccb"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("1e8f132c-e295-4e62-8d9d-08e803c11a40"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("1f41f786-6897-4550-81d6-f1b90bb6c9b4"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("2004a2ea-0df6-460a-9ac7-eec181744c34"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("203ebc35-c70b-4df3-abd5-16a5a9ce051a"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("2102e762-84d4-4a3d-a050-8f3170ecc0b6"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("21efd648-c21e-4d02-8996-2096d25ee424"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("22251f50-0a29-4c5c-8e39-22fd9a14bde4"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("23820f1b-fe22-478b-8584-6de11c2fc412"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("23aac44b-85a8-4a8d-9186-d5c0a3b26804"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("241fe6b0-918e-4827-8fc8-236ebd0613a2"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("255a0e43-f42c-458c-a247-2ce9a26612af"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("28e002d7-edb5-4c47-95ab-2444a12215a9"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("2902784d-09e2-49b4-bdaf-bcb6a391416f"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("29358abe-91c4-4515-be3e-671b1d1671cc"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("2acdf4c5-0710-4dec-9af7-c91a8717df03"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("2e22820f-dd21-4698-95f3-aca3574db55d"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("2e339d24-d484-43f7-b2f7-15a35634ceec"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("2ee38acf-ce7b-48a6-8cf2-7c093f8904a2"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("33d47fe9-0541-4fa0-9f0b-ecd97610973f"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("35e4eb67-f7b2-4a73-be38-dedca8fbc7c4"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("362e69e4-0491-441c-b283-b349bbf196bd"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("386f18ae-efe2-4914-a29b-2121eb9737fc"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("391294ab-2430-453b-9c4e-311d253bb48d"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("3d8fba9a-84df-423b-a93e-d49bec3db333"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("3ddab5d6-84f5-4c43-a97c-3a7f456422e3"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("3e0cc690-6878-4899-9ef6-8e23d2ee6f9e"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("3efb0839-2d33-4736-8b5e-0cf97c2b98a3"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("415ace7f-56b2-4093-8b5b-482f26d59e88"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("431cd348-fdff-40f5-a7ef-e277cf06bf61"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("434f6fad-fc94-4358-ab36-cd2f9cca04f7"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("44c53c74-f86c-4832-8a1f-5d79d0eac619"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("4785a00b-818f-4107-9b4d-7ff1facbfd19"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("47d660c9-460a-4da8-b7bb-8685b2528f5a"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("491801ca-9589-4897-bca4-132810d6f7d0"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("4a82f30a-48bb-4deb-8a83-39ec9b3c9723"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("4c0305c5-66bd-42fd-a778-ce5eae0fadd8"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("4c5965c7-79b3-464d-b62b-b41db27ee496"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("4cfef9dc-df64-41ee-9a5d-3b5be3d3a1cd"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("4e263d7c-420b-4c3f-ad60-cd136c57e95a"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("4f8aff52-28e0-4fff-b1cf-ede94b305844"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("4fcc4443-dc6e-476b-b263-bd62edf72187"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("51fbd1af-12fe-47b9-bc5e-b9e9b9a3c7e6"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("52b0b148-b007-4531-a688-c288eaa8807c"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("53848cb9-83e8-445b-945d-dce40ac8cc23"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("53acf3a2-2722-46a3-b2c5-73c5ee9f185f"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("5551067f-4f44-4ab2-8d18-412bdb260bc0"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("56950507-fe6d-43d5-8432-bc0a09d1cd7c"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("569d8813-eac6-44bc-ac73-adb4b5fccb3c"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("5b77f46f-f7c1-4679-979b-a4619f1d1fc1"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("5caeaa73-eed6-4004-b87d-3cc8752a6385"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("5d4b8561-4905-4146-9d1f-27ee7c92ad4e"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("5eef8641-4e7d-49df-81f6-52dc0e5e7610"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("5f24751f-1108-42f1-a4c8-57e473dfbcf5"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("611b59fa-7792-44cc-8c92-cedaca53d7f2"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("653bdacd-131c-4011-aab2-a0c65c1c933f"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("65ded067-609c-4065-b1c7-e6127b2295ec"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("665efce3-80d0-465d-b841-5ccb0e425ade"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("67a75e86-60c5-4ce5-95bc-484eda2e21b8"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("67ff68c1-15c1-4799-98d2-14576be646c0"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("6cd88648-63a7-4208-81d2-be6298986f46"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("6e84f67c-1028-43e0-86f7-ad28cbc35bb4"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("70312332-696f-4319-841c-9e151a464bb5"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("708ed2ce-7b1e-496b-a328-2ea4860921d3"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("723293b4-4431-49ab-91a4-280fe2801018"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("74d6f43d-57cb-4b8b-8470-58d5b86fc5cd"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("77087145-9ad3-4ec3-b27e-5f7eb14827eb"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("794cf8ba-ecd2-4dce-b7ed-12154122c704"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("7a9820d5-a6fd-4db0-a08c-7a9448b1a684"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("7ba69eed-abbd-487b-b431-1e445efcdd23"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("7c5ec7f8-6922-4caf-9251-05e6515bbd76"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("81496350-f60c-46b4-831d-87447f304647"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("81dbcbed-9504-4136-9927-21b10b04472f"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("823b340c-bc4d-4807-9b57-d88e362129fe"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("89b6d3a8-0f27-4885-847c-786515f7a145"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("89bfd518-364a-4fd0-a592-dee5bb3d364a"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("8a9aa61f-ea86-47e1-a00d-0b1afffebc99"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("8afdcee5-1d33-4938-b9ff-633451b8af4b"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("8b49fc8e-6489-4a78-8ee5-9f517ad207fe"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("8b84be2b-101d-48fb-96cd-25217ee24963"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("8c96dbd3-f12b-4493-a93f-120631af3e7a"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("8dbc81a8-0fed-4c37-8eb7-df54e3999b4c"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("8e42a086-9c27-4ed8-bf20-9b5d1314b548"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("8e8e737f-de53-4608-bf4a-9cb0a39a8bfe"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("8f24055d-4cb1-4c1e-9fd5-6d8f8c7422aa"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("8f69b08f-bdef-4ede-9f99-51b4a0ca6268"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("926a8b73-3beb-44b9-862f-3a95600c1c73"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("92e4221f-2a14-4928-8ed7-c179257db54f"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("933173ad-5926-40d5-82eb-a041f112aca6"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("93bbea34-d46f-4341-823d-a75eab213107"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("93d913c6-5369-423f-8617-88cbe0462625"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("946e5d65-fadd-45cb-a86a-49784f0be5e8"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("9a140fbf-a806-4474-b66d-68694fcd3cc9"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("9e1e6601-fd30-4137-9c03-7174c147b7be"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("9ea75804-57d9-4b3a-a6a6-c2d410f081c0"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("9f18dacf-73d2-4671-be9c-3b624d8b2340"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("a0d636d0-4004-4b11-96f1-977c26342982"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("a44457a7-b744-434b-858c-f825bedc7349"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("a6975f8d-e422-4271-b20d-5f19697f2519"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("a740ba57-ac7b-4d23-a363-b18cdadf4072"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("a7e471e0-7517-4f7f-856c-ffec02d79e36"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("a9d3c244-a823-447c-81a6-27a59852830e"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("aa853841-2bd4-49a2-9af0-c88e44eb8328"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("ab09ad9b-3026-4f7b-925c-a045db9da27f"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("ac0b5e8b-dab5-437d-8670-4c5dcd0d2098"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("ac66dccc-ac51-489c-b6ce-caee5c194b53"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("aefd32a3-ee91-49b7-94c9-f9b60da119de"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("afe00aee-4393-462b-b260-712be381f9b0"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("b10a45f0-1669-48aa-819f-dc562d21763a"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("b44c8c6e-36f5-48b8-9b71-7541e4bc624b"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("b95e40a8-0f3d-4440-b402-06c78e8c3511"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("bb7243c7-85c4-4897-ace5-fd9569acda85"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("bbf0f55c-d20a-4c2a-8215-fc65adacbafc"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("bc9c5286-73fc-40b3-b258-acf32beb446b"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("bcdac1da-a65e-43cd-9ea8-e6902292abbb"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("bfd5c4e9-085e-47bc-84e5-6b04dcef6b19"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("c0258c90-50cb-47d7-91a9-7d3b43b4d9e0"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("c2c7ff40-c47e-4130-bdb7-2817bcb0c358"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("c40845f2-98bb-42c2-9f61-271c6e4b1816"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("c4ef3177-49aa-46e9-9847-380a8cd228d4"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("c55ba825-2fe5-422e-a0ea-0afd1ed63b2f"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("c57f157c-ab83-4c47-b972-6c927ac248f7"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("c949dc67-9313-4a78-989b-6c66802acabc"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("c99a9006-dbf3-4778-921f-ea445c747e47"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("cbd97226-5f63-4a98-832a-dbae809694f5"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("cc9da592-7f56-4412-b49d-c79c4c23a59b"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("ccb2475f-d660-42e4-ae4d-9ddb5f7fc2f4"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("cf1d19ea-ce44-4622-b05e-59c10f427a8b"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("cfa06e20-e696-4922-9d92-cf1be5bfdd15"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("d30bcbcd-dd8b-4ad8-a6c8-1767372cfc82"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("d4261d60-6b8d-4e40-87dd-0e47aaf36bf3"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("d45a031c-14be-4593-b1d9-8d4d9d2ff263"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("d49d8cd3-b65b-470a-a080-d87942589672"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("d50fb274-39de-4620-8a2b-ea33b46259a8"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("d55c98d0-b0d5-4c25-9606-a07cec6c933e"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("d73fbbe9-7cd6-4098-a855-c2a681f3fea1"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("d81a082d-5c06-4eec-8d53-a38802f5a63e"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("d85bfcee-5cce-4608-b23a-76412aa8c196"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("dc22fa9b-3b4e-40be-a519-31c7007e4713"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("ddbaa6f1-e6aa-43d2-85e1-6e06b695f81d"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("df1d0cb9-3b15-4497-a430-f6b8d8e65ee4"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("df683b64-3bda-4cfc-9a94-9884188298c8"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("dfd1f06d-cc27-43e7-a018-177f913fbbd2"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("e900cfbd-3f9a-4caa-bf1a-3b84ef0976b3"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("eb8118ab-2e4e-4a77-9867-449b461ee9d1"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("ec499ca0-16b6-4eef-b08c-7f8637ff8c69"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("ec9e7d6b-0974-4818-a3f1-165b463e3e39"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("ee57c437-d61f-436c-b435-275eb0e99454"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("f3029c17-29aa-4fc9-bd3d-a2736d0d8aac"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("f419e1fc-3b4a-4edf-9fc6-7b4f07ee2162"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("f6f23a55-b466-4496-82dd-b5ae28afa3e5"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("f8a95b97-cbd7-4e6a-8207-5fb41f1320b9"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("fb533aaa-c435-48f9-af8d-2bf3b3037c93"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("fbfd03a5-0ca2-42b6-831e-c8e24fa74358"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("fd845df3-f26d-4e35-8972-07654a7e834f"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("fd8e5949-77ef-40a9-8bfa-4169d2ff082b"));

            migrationBuilder.DeleteData(
                table: "FridgeProducts",
                keyColumn: "Id",
                keyValue: new Guid("ffee1fe5-92f9-4937-9037-95ba63d34f94"));

            migrationBuilder.DeleteData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: new Guid("16ceb523-89fb-4141-9d0b-a9d94dd9e4d3"));

            migrationBuilder.DeleteData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: new Guid("1bc3301d-e132-41d7-b4d5-6fb639aac4c1"));

            migrationBuilder.DeleteData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: new Guid("1eca9dd4-85c1-4f39-a298-e18a8f435db2"));

            migrationBuilder.DeleteData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: new Guid("2921fe0c-f6f2-4939-923e-8fd878c1c243"));

            migrationBuilder.DeleteData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: new Guid("2a2a9044-813d-44ac-ad8a-80f377bef1db"));

            migrationBuilder.DeleteData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: new Guid("3d683e69-5118-489c-ba23-94a14836ee2d"));

            migrationBuilder.DeleteData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: new Guid("3dddc8a5-d1d4-428a-9552-f62b6728bac5"));

            migrationBuilder.DeleteData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: new Guid("467a286d-fb73-47e4-9696-5c7e9efe36ed"));

            migrationBuilder.DeleteData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: new Guid("4d40b3e7-dae1-4410-8619-a16a9646c445"));

            migrationBuilder.DeleteData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: new Guid("4e189220-d31b-4cef-a19c-82f5acc92dc6"));

            migrationBuilder.DeleteData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: new Guid("570a85c1-3431-4875-9844-b3b91d0dbc5f"));

            migrationBuilder.DeleteData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: new Guid("68d87710-9322-4143-95f7-b0462c8741ca"));

            migrationBuilder.DeleteData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: new Guid("7d9663ec-ff37-4dd3-9a14-1eb6d6f7d8df"));

            migrationBuilder.DeleteData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: new Guid("957d2895-38d4-4ae0-96c1-1d7a87fdc6bc"));

            migrationBuilder.DeleteData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: new Guid("9ca69a10-1689-4de6-8a70-87522495fa30"));

            migrationBuilder.DeleteData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: new Guid("db6c1c25-77ed-456c-8dd7-e9e491a62f35"));

            migrationBuilder.DeleteData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: new Guid("e8c640e8-f666-4341-8e6e-f15b9d3a32e5"));

            migrationBuilder.DeleteData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: new Guid("ea581127-602c-4f5e-b601-b61da930855e"));

            migrationBuilder.DeleteData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: new Guid("f5de0450-7ded-40ab-9d2f-546851161b6f"));

            migrationBuilder.DeleteData(
                table: "Fridges",
                keyColumn: "Id",
                keyValue: new Guid("ffe5652b-5cc1-4cb2-9976-aba17cff3f67"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0c8d3521-d24e-49e7-b56f-598fb443065a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0da14e05-3453-4244-9fbe-8adb4d677910"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10e854c7-c49c-4752-91c6-128abc68e3cb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("18ef1ad3-45eb-4f81-b2a4-d4edefd0eb67"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("214f319f-4a77-40a5-b386-8bb02531c72c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("22b511bb-bdd7-4224-a596-da3f2904f3ef"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("267b0412-ec7a-414b-8261-bcde651a5d8c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("29800b01-12d3-48fe-a2b1-9683c54fb675"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2aef949d-09a2-49ff-b763-a74b3b464c7a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2d9c1c30-ea45-4c31-bd85-23e8d3a1a51c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("38c1541f-7377-42fb-997e-9dc5d63541d9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3c1a0f0e-90e9-48cc-9fd4-d38deac70b52"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3cec2a04-0e6d-4608-bd82-6aa0e479f615"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3fedf8b0-73b2-4da1-8e8d-04855a166f7c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4124cddb-9ab2-418c-ae07-f28ef8c9d9b6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("58dd9c8d-05c6-472c-9db6-e0fb6c40dd82"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("62f6c28b-ed7d-4f4f-9d05-4e12d543c5cd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6f911a57-e7a3-4ff5-84af-50644af5eba5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("70707f26-d2c5-4308-8512-fd69b6dafe57"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("739f2bf4-0f45-4e49-9a28-545d2480a4d3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7722ebfc-348b-4a21-b4c3-92885d502243"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7ca21d7c-dc0b-43b5-ac90-ef067100a65a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("82093098-15d2-4cc4-b8d3-67b66eee0a23"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8f753d8c-61ce-4b6c-b5be-daa3ae81986e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a018210b-34a6-4936-adfd-d71f847945e7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a0727fce-fdab-4e90-ae51-c1e2edf8c566"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a1fef996-b37c-44b7-846a-d5363d25e762"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a5d673b5-7e29-4e5a-9afb-2f08bdcce7f0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c0ee6038-f5e2-4fa1-a8fe-4b0d175d3c17"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cb3ede17-203b-4d62-86a6-58e6c450eab9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ceaff4f6-a3e0-438a-b26d-a5efe8f85aa1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d844ecc8-8cf9-485a-aaf1-73da20822d1f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("df76aeb1-3c2f-4f6a-bf7d-90d50847d2b4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e07d13af-670a-4007-81b0-fee1549a4cdd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e251d874-d59d-4b1c-b1bd-4f909df9f9e9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ea2d7c77-61e9-48e5-96ae-059738191711"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ec491952-30b7-4f54-8509-3795c1d412b0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fef3cfc6-7238-4bbe-9b5e-5892a66413f4"));

            migrationBuilder.DeleteData(
                table: "FridgeModels",
                keyColumn: "Id",
                keyValue: new Guid("0977597e-b6ab-4960-8ac1-4ed96224ca04"));

            migrationBuilder.DeleteData(
                table: "FridgeModels",
                keyColumn: "Id",
                keyValue: new Guid("35771bd8-26bd-497b-938c-a55099f952c2"));

            migrationBuilder.DeleteData(
                table: "FridgeModels",
                keyColumn: "Id",
                keyValue: new Guid("5d643efa-3320-4602-b34f-ad683c6a1e9d"));

            migrationBuilder.DeleteData(
                table: "FridgeModels",
                keyColumn: "Id",
                keyValue: new Guid("636c9cc3-6d74-4d18-a236-55b3b6b36271"));

            migrationBuilder.DeleteData(
                table: "FridgeModels",
                keyColumn: "Id",
                keyValue: new Guid("70684b7d-92bf-49f1-bedb-ca7bc4ba4b14"));

            migrationBuilder.DeleteData(
                table: "FridgeModels",
                keyColumn: "Id",
                keyValue: new Guid("787d1096-7547-4a5e-b0e9-af06789682f1"));

            migrationBuilder.DeleteData(
                table: "FridgeModels",
                keyColumn: "Id",
                keyValue: new Guid("7a5521f6-c232-4938-9804-acd18d1c6b67"));

            migrationBuilder.DeleteData(
                table: "FridgeModels",
                keyColumn: "Id",
                keyValue: new Guid("89432c98-ed08-4f29-ad65-c048aa54e66f"));

            migrationBuilder.DeleteData(
                table: "FridgeModels",
                keyColumn: "Id",
                keyValue: new Guid("97e496af-060b-477d-a285-847f4991dfd8"));

            migrationBuilder.DeleteData(
                table: "FridgeModels",
                keyColumn: "Id",
                keyValue: new Guid("9cdeb1aa-0036-41b7-855f-50b7df8b6a9c"));

            migrationBuilder.DeleteData(
                table: "FridgeModels",
                keyColumn: "Id",
                keyValue: new Guid("a57f4319-b951-40e9-92b3-eac5fba21003"));

            migrationBuilder.DeleteData(
                table: "FridgeModels",
                keyColumn: "Id",
                keyValue: new Guid("c227ed9e-4b5c-4d34-af1b-0956a0e883c4"));

            migrationBuilder.DeleteData(
                table: "FridgeModels",
                keyColumn: "Id",
                keyValue: new Guid("ecf08f01-0604-4c7c-9234-5d9f345734c0"));
        }
    }
}
