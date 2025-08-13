using Ordering.Application.Orders.Queries.GetOrdersByCustomer;
namespace Ordering.API.Endpoints;
public record GetOrdersByCustomerResponse(IEnumerable<OrderDto> Orders);
public class GetOrdersByCustomer : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders/{customerId}", async (Guid customerId, ISender Sender) =>
        {
            var result = await Sender.Send(new GetOrdersByCustomerQuery(customerId));
            var response = result.Adapt<GetOrdersByCustomerResponse>();
            return Results.Ok(response);
        })
            .WithName("GetOrdersByCustomer")
            .Produces<GetOrdersByCustomerResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Orders By Customer")
            .WithDescription("Get Orders By Customer");
    }
}
