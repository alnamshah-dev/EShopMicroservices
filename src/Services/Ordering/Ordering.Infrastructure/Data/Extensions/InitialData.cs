namespace Ordering.Infrastructure.Data.Extensions;
internal class InitialData
{
    public static IEnumerable<Customer> Customers=>
    new List<Customer>
    {
        Customer.Create(CustomerId.Of(new Guid("58c49479-ec65-4de2-86e7-033c546291aa")),"Abdulaziz","abdulaziz@gmail.com"),
        Customer.Create(CustomerId.Of(new Guid("d4b5a62a-eb5f-4c1e-9b5a-8b7a6c2d1e3f")),"Mohamed","mohamed@gmail.com")
    };
    public static IEnumerable<Product> Products=>new List<Product>
    {
        Product.Create(ProductId.Of(new Guid("1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d")), "iPhone 15 Pro Max", 1200),
        Product.Create(ProductId.Of(new Guid("2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e")), "Samsung Galaxy S25 Ultra", 1300),
        Product.Create(ProductId.Of(new Guid("3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f")), "Google Pixel 9 Pro", 1000),
        Product.Create(ProductId.Of(new Guid("4d5e6f7a-8b9c-0d1e-2f3a-4b5c6d7e8f9a")), "OnePlus 12 Pro", 900),
        Product.Create(ProductId.Of(new Guid("5e6f7a8b-9c0d-1e2f-3a4b-5c6d7e8f9a0b")), "Xiaomi 14 Ultra", 1100)
    };
    public static IEnumerable<Order> OrdersWithItems
    {
        get
        {
            var address1 = Address.Of("Abdulaziz", "Alnamshah", "abdulaziz@gmail.com","New District", "Yemen", "Sana'a", "12345");

            var address2 = Address.Of("Mohamed", "Ali", "mohamed@gmail.com","New District", "Yemen", "Sana'a", "67890");

            var payment1 = Payment.Of("Abdulaziz", "99444412122547454", "12/28", "355", 1);
            var payment2 = Payment.Of("Mohamed", "8885555555554444", "06/30", "222", 2);

            var order1 = Order.Create(
                            OrderId.Of(Guid.NewGuid()),
                            CustomerId.Of(new Guid("58c49479-ec65-4de2-86e7-033c546291aa")),
                            OrderName.Of("ORD_1"),
                            shippingAddress: address1,
                            billingAddress: address1,
                            payment1);
            order1.Add(ProductId.Of(new Guid("1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d")), 1, 1199.99m); 
            var order2 = Order.Create(
                            OrderId.Of(Guid.NewGuid()),
                            CustomerId.Of(new Guid("d4b5a62a-eb5f-4c1e-9b5a-8b7a6c2d1e3f")),
                            OrderName.Of("ORD_2"),
                            shippingAddress: address2,
                            billingAddress: address2,
                            payment2);
            order2.Add(ProductId.Of(new Guid("2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e")), 2, 1099.99m); 
            return new List<Order> { order1, order2 };
        }
    }
}
