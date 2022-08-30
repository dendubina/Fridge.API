using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Entities.Configuration
{
    public static class DbInitializer
    {
        public static List<FridgeModel> FridgeModels { get; }
        public static List<Fridge> Fridges { get; }
        public static List<Product> Products { get; }
        public static List<FridgeProduct> FridgeProducts { get; }


        private static readonly string[] _modelsNames = { "TH-803", "514-NWE", "RC-54", "XM 4021-000", "DF 5180 W",
            "DS 333020", "VF 466 EB", "KGN36S55", "RB-34 K6220SS", "VF 910 X", "Electric MR-CR46G-HS-R",
            "RF-61 K90407F", "SBS 7212", "VF 395-1 SBS", "RSA1SHVB1" };

        private static readonly string[] _fridgeNames = { "Atlant", "Indesit", "Beko", "Vestfrost",
            "Bosch", "Samsung", "Philips", "Liebherr", "Stinol" };

        private static readonly string[] _fridgeOwners = { "Vlada", "Anna", "Andrew", "Polina", "Mariya",
            "Dima", "Kirill", "Julia", "Nastya" };

        private static readonly Dictionary<string, string> _productsNamesAndPictures = new Dictionary<string, string>
            {
                { "Bread" , "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7b/Assorted_bread.jpg/274px-Assorted_bread.jpg"},
                { "Apple", "https://id-test-11.slatic.net/p/70f40d8f77f844671af4a5a11755e7ae.jpg"},
                { "Yoghurt", "https://media.istockphoto.com/vectors/yogurt-cup-with-spoon-vector-id1060883416?k=20&m=1060883416&s=612x612&w=0&h=nhPJA8XYohdkGbBojLt72e_q9sbgBuO6mUI-7cnuu6s="},
                { "Egg", "https://www.collinsdictionary.com/images/full/egg_110803370.jpg"},
                { "Cheese", "https://cdn.yamatoscale.com/wp-content/uploads/2016/04/K%C3%A4se-Scheiben_01_00_OH-1.jpg"},
                { "Mashroom", "https://4.imimg.com/data4/JX/UQ/ANDROID-47104262/product-500x500.jpeg"},
                { "Chicken", "https://food.fnr.sndimg.com/content/dam/images/food/fullset/2010/5/1/0/0039592F3_beer-can-chicken_s4x3.jpg.rend.hgtvcom.616.462.suffix/1382539274625.jpeg"},
                { "Pork", "https://www.thespruceeats.com/thmb/OueG44zJ3LnwQt9HwVXmmT6mkNM=/3067x3067/smart/filters:no_upscale()/roasted-boneless-pork-loin-recipe-995289-hero-01-93314ca221a54ecebc45a17e99cb78c4.jpg"},
                { "Beef", "https://hips.hearstapps.com/hmg-prod/images/delish-roast-beef-horizontal-1540505165.jpg"},
                { "Sausage", "https://www.crescentfoods.lk/images/products/PREMIUM_CHICKEN_SAUSAGES.jpg"},
                { "Fish", "https://preview.free3d.com/img/2017/05/2279485108920518249/e92jihnh-900.jpg"},
                { "Avocado", "https://images.absolutdrinks.com/ingredient-images/Raw/Absolut/d391984d-0573-4fb2-aa36-2f18d2ee8ce8.jpg?imwidth=500"},
                { "Broccoli", "http://cdn.shopify.com/s/files/1/0404/0710/5687/products/6000200094505_grande.jpg?v=1595626016"},
                { "Beans", "https://www.eatthis.com/wp-content/uploads/sites/4/2020/03/variety-of-beans.jpg?quality=82&strip=1"},
                { "Carrot", "https://www.jessicagavin.com/wp-content/uploads/2019/02/carrots-7-1200.jpg"},
                { "Cucumber", "https://www.farmersfamily.in/wp-content/uploads/2020/08/Cucumber.jpg"},
                { "Onion", "https://produits.bienmanger.com/36700-0w470h470_Organic_Red_Onion_From_Italy.jpg"},
                { "Garlic", "https://www.ngroceries.com/wp-content/uploads/2021/10/61amdwJRu-L._SX522_.jpg"},
                { "Potato", "https://5.imimg.com/data5/ANDROID/Default/2021/2/UH/HH/LB/44089979/potatoes-jpg-250x250.jpg"},
                { "Banana", "https://images.heb.com/is/image/HEBGrocery/000377497"},
                { "Cherry", "https://sc04.alicdn.com/kf/Ub2b912f5fb6d48ce99dee2bef2a7d2fch.jpg"},
                { "Grape", "https://img.freepik.com/free-vector/isolated-dark-grape-with-green-leaf_317810-1956.jpg?w=2000"},
                { "Lemon", "https://www.seeds-gallery.shop/8291-large_default/lemon-seeds-c-limon.jpg"},
                { "Orange", "https://cdn.shopify.com/s/files/1/2971/2126/products/Orange_f48b955f-9cde-4b90-bbd5-03ce7b8bcf1f_400x.jpg?v=1569304785"},
                { "Peach", "https://static.libertyprim.com/files/familles/peche-large.jpg?1574630286"},
                { "Strawberry", "https://befreshcorp.net/wp-content/uploads/2017/07/product-packshot-strawberrie-558x600.jpg"},
                { "Raspberry", "https://soapatopia.com/wp-content/uploads/2021/01/raspberries.jpg"},
                { "Watermelon", "https://www.seeds-gallery.shop/5488-large_default/400-watermelon-seeds-crimson-sweet.jpg"},
                { "Butter", "https://quintalsonline.com/wp-content/uploads/2020/05/close-up-of-block-of-butter-being-sliced-may-raise-cholesterol_1400x.jpg"},
                { "Milk", "https://static.vecteezy.com/system/resources/previews/006/225/849/original/a-carton-of-milk-cartoon-illustration-vector.jpg"},
                { "Kefir", "https://groceries.morrisons.com/productImages/408/408833011_0_268x268.jpg?identifier=146ae3bbcbb049c8aa859a0fbd47946e"},
                { "Chocolate", "https://andygrimshaw.com/wp-content/uploads/2016/03/Chocolate-bar-melt-explosion.jpg"},
                { "Jam", "https://assets.tmecosys.com/image/upload/t_web767x639/img/recipe/ras/Assets/4B7C3510-7041-4B5D-8000-1D10B1BA4678/Derivates/6749ac4e-586d-4055-9df2-5a96832897f6.jpg"},
                { "Pudding", "https://www.mybakingaddiction.com/wp-content/uploads/2021/03/vanilla-pudding-with-fruit-720x720.jpg"},
                { "Jelly", "https://assets.tmecosys.com/image/upload/t_web767x639/img/recipe/ras/Assets/607dfd53-5b5c-4309-9e1f-5a959d20e16c/Derivates/9ac9e3c1-20d2-4d31-afdb-191c9ba22235.jpg"},
                { "Pancake", "https://www.wholesomeyum.com/wp-content/uploads/2017/03/wholesomeyum-Low-Carb-Keto-Pancakes-Recipe-21.jpg"},
                { "Juice", "https://media.istockphoto.com/photos/fresh-citrus-juices-picture-id158268808?k=20&m=158268808&s=612x612&w=0&h=9mUMCBDaY-JYqR7m9r_mi0-Ta0RIebZ3DpxyimSQ7Fc="},
                { "Soda", "https://img.freepik.com/free-vector/soda-cups-drink_24877-57922.jpg?w=2000"}
        };


        static DbInitializer()
        {
            FridgeModels = new List<FridgeModel>();
            Fridges = new List<Fridge>();
            Products = new List<Product>();
            FridgeProducts = new List<FridgeProduct>();

            // Models
            for (int i = 0; i < _modelsNames.Length; i++)
            {
                FridgeModels.Add(new FridgeModel
                {
                    Id = Guid.NewGuid(),
                    Name = _modelsNames[i],
                    Year = new Random().Next(2010, 2020),
                });
            }

            // Fridges
            for (int i = 0; i < 5; i++)
            {
                int nameIndex = new Random((int)DateTime.Now.Ticks + i).Next(_fridgeNames.Length);
                int ownerIndex = new Random((int)DateTime.Now.Ticks + i).Next(_fridgeOwners.Length);
                int modelIndex = new Random((int)DateTime.Now.Ticks + i).Next(FridgeModels.Count);

                Fridges.Add(new Fridge
                {
                    Id = Guid.NewGuid(),
                    Name = _fridgeNames[nameIndex],
                    OwnerName = _fridgeOwners[ownerIndex],
                    FridgeModelId = FridgeModels[modelIndex].Id,
                });
            }

            // Products
            for (int i = 0; i < _productsNamesAndPictures.Count; i++)
            {
                Products.Add(new Product
                {
                    Id = Guid.NewGuid(),
                    Name = _productsNamesAndPictures.Keys.ElementAt(i),
                    DefaultQuantity = new Random((int)DateTime.Now.Ticks + i).Next(5, 18),
                    ImageSource = _productsNamesAndPictures.Values.ElementAt(i)
                });
            }

            // Products in fridges
            for (int i = 0; i < 500; i++)
            {
                int fridgeIndex = new Random((int)DateTime.Now.Ticks + i).Next(Fridges.Count);
                int productIndex = new Random((int)DateTime.Now.Ticks + i).Next(Products.Count);
                int quantity = new Random((int)DateTime.Now.Ticks + i).Next(14);

                Guid fridgeId = Fridges[fridgeIndex].Id;
                Guid productId = Products[productIndex].Id;

                if (FridgeProducts.FirstOrDefault(fp => fp.FridgeId == fridgeId && fp.ProductId == productId) != null)
                {
                    int index = FridgeProducts.IndexOf(FridgeProducts.First(fp => fp.FridgeId == fridgeId && fp.ProductId == productId));
                    FridgeProducts[index].Quantity += quantity;
                }
                else
                {
                    FridgeProducts.Add(new FridgeProduct
                    {
                        Id = Guid.NewGuid(),
                        FridgeId = fridgeId,
                        ProductId = productId,
                        Quantity = quantity
                    });
                }
            }
        }
    }
}
