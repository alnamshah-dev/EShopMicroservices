using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            var session = store.LightweightSession();
            if (await session.Query<Product>().AnyAsync())
                return;
            session.Store<Product>(GetPreconfiguredProducts());
            await session.SaveChangesAsync();
        }
        private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>()
        {
            new Product()
            {
                Id = new Guid("a3b4c5d6-e7f8-4a9b-bc1d-2e3f4a5b6c7d"),
                Name = "Samsung S25 Ultra",
                Description = "Flagship smartphone with 200MP camera, 8K video recording, and foldable OLED display",
                ImageFile = "samsung-s25ultra.png",
                Price = 1199.99M,
                Category = new List<string>{"Smartphone", "Android"}
            },
            new Product()
            {
                Id = new Guid("b1a2c3d4-e5f6-4a7b-8c9d-0e1f2a3b4c5d"),
                Name = "iPhone 15 Pro Max",
                Description = "Apple premium smartphone with A17 Pro chip, titanium frame, and 5x optical zoom",
                ImageFile = "iphone-15promax.png",
                Price = 1299.00M,
                Category = new List<string>{"Smartphone", "Apple"}
            },
            new Product()
            {
                Id = new Guid("c2d3e4f5-a6b7-4c8d-9e0f-1a2b3c4d5e6f"),
                Name = "Google Pixel 8 Pro",
                Description = "AI-powered smartphone with Tensor G3 chip and advanced computational photography",
                ImageFile = "pixel-8pro.png",
                Price = 999.00M,
                Category = new List<string>{"Smartphone", "Android"}
            },
            new Product()
            {
                Id = new Guid("d3e4f5a6-b7c8-4d9e-0f1a-2b3c4d5e6f7a"),
                Name = "OnePlus 12",
                Description = "High-performance phone with Snapdragon 8 Gen 3 and 120Hz AMOLED display",
                ImageFile = "oneplus-12.png",
                Price = 799.99M,
                Category = new List<string>{"Smartphone", "Android"}
            },

            // Laptops (4 items)
            new Product()
            {
                Id = new Guid("e4f5a6b7-c8d9-4e0f-1a2b-3c4d5e6f7a8b"),
                Name = "Apple MacBook Pro 16\"",
                Description = "Professional laptop with M3 Pro chip, 32GB RAM, and 1TB SSD storage",
                ImageFile = "macbook-pro-16.png",
                Price = 2499.00M,
                Category = new List<string>{"Laptop", "Apple"}
            },
            new Product()
            {
                Id = new Guid("f5a6b7c8-d9e0-4f1a-2b3c-4d5e6f7a8b9c"),
                Name = "Dell XPS 15",
                Description = "Premium Windows laptop with 4K OLED touchscreen and Intel Core i9 processor",
                ImageFile = "dell-xps15.png",
                Price = 2199.99M,
                Category = new List<string>{"Laptop", "Windows"}
            },
            new Product()
            {
                Id = new Guid("a6b7c8d9-e0f1-4a2b-3c4d-5e6f7a8b9c0d"),
                Name = "Microsoft Surface Laptop 5",
                Description = "Sleek ultrabook with PixelSense touchscreen and 15-hour battery life",
                ImageFile = "surface-laptop5.png",
                Price = 1599.00M,
                Category = new List<string>{"Laptop", "Windows"}
            },
            new Product()
            {
                Id = new Guid("b7c8d9e0-f1a2-4b3c-4d5e-6f7a8b9c0d1e"),
                Name = "Lenovo ThinkPad X1 Carbon",
                Description = "Business laptop with military-grade durability and best-in-class keyboard",
                ImageFile = "thinkpad-x1carbon.png",
                Price = 1899.00M,
                Category = new List<string>{"Laptop", "Business"}
            },

            // Other products (8 items)
            new Product()
            {
                Id = new Guid("c8d9e0f1-a2b3-4c4d-5e6f-7a8b9c0d1e2f"),
                Name = "Sony WH-1000XM5",
                Description = "Premium noise-cancelling wireless headphones with 30-hour battery life",
                ImageFile = "sony-headphones.png",
                Price = 349.99M,
                Category = new List<string>{"Headphones", "Audio"}
            },
            new Product()
            {
                Id = new Guid("d9e0f1a2-b3c4-4d5e-6f7a-8b9c0d1e2f3a"),
                Name = "Dyson V15 Detect",
                Description = "Cordless vacuum cleaner with laser dust detection and 60-minute runtime",
                ImageFile = "dyson-v15.png",
                Price = 699.99M,
                Category = new List<string>{"Home Appliances", "Vacuum Cleaner"}
            },
            new Product()
            {
                Id = new Guid("e0f1a2b3-c4d5-4e6f-7a8b-9c0d1e2f3a4b"),
                Name = "Nintendo Switch OLED",
                Description = "Gaming console with 7-inch OLED screen and 64GB internal storage",
                ImageFile = "switch-oled.png",
                Price = 349.99M,
                Category = new List<string>{"Gaming Console", "Electronics"}
            },
            new Product()
            {
                Id = new Guid("f1a2b3c4-d5e6-4f7a-8b9c-0d1e2f3a4b5c"),
                Name = "Instant Pot Duo 7-in-1",
                Description = "Electric pressure cooker with 7 cooking functions and 6-quart capacity",
                ImageFile = "instant-pot.png",
                Price = 99.95M,
                Category = new List<string>{"Kitchen", "Home Appliances"}
            },
            new Product()
            {
                Id = new Guid("a2b3c4d5-e6f7-4a8b-9c0d-1e2f3a4b5c6d"),
                Name = "Fitbit Charge 6",
                Description = "Advanced fitness tracker with GPS, heart rate monitoring, and 7-day battery",
                ImageFile = "fitbit-charge6.png",
                Price = 159.95M,
                Category = new List<string>{"Wearable", "Fitness"}
            },
            new Product()
            {
                Id = new Guid("b3c4d5e6-f7a8-4b9c-0d1e-2f3a4b5c6d7e"),
                Name = "Canon EOS R5",
                Description = "Mirrorless camera with 45MP sensor and 8K video capability",
                ImageFile = "canon-eos-r5.png",
                Price = 3899.00M,
                Category = new List<string>{"Camera", "Photography"}
            }
        };
    }
}
