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
                Id = new Guid("c8d9e0f1-a2b3-4c4d-5e6f-7a8b9c0d1e2f"),
                Name = "Sony WH-1000XM5",
                Description = "Premium noise-cancelling wireless headphones with 30-hour battery life",
                ImageFile = "sony-headphones.png",
                Price = 349.99M,
                Category = new List<string>{"Headphones", "Audio"}
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
