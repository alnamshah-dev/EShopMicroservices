namespace Basket.API.Basket.StoreBasket
{
    public record StoreBasketRequest(ShoppingCart Cart);
    public record StoreBasketResponse(string UserName);
    public class StoreBasketEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/basket", async (StoreBasketRequest request, ISender Sender) =>
            {
                var command= request.Adapt<StoreBasketCommand>();
                var result=await Sender.Send(command);
                var response=result.Adapt<StoreBasketResponse>();
                return Results.Created($"basket/{response.UserName}",response);
            })
                .WithName("StoreBasket")
                .Produces<StoreBasketResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithDescription("Store Basket")
                .WithSummary("Store Basket")
                ;
        }
    }
}
