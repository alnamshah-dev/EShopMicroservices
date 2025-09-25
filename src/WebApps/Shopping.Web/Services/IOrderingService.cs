namespace Shopping.Web.Services;

public interface IOrderingService
{
    [Get("/order-service/orders?pageNumber=1&pageSize=10")]
    Task<GetOrdersResponse> GetOrders(int? pageNumber=1, int? pageSize=10);

    [Get("/order-service/orders/{orderName}")]
    Task<GetOrdersByNameResponse> GetOrdersByName(string orderName);

    [Get("/order-service/orders/customer/{customerId}")]
    Task<GetOrdersByCustomerResponse> getOrdersByCustomer(Guid customerId);
}
