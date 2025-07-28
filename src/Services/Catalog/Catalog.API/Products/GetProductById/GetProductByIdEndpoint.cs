namespace Catalog.API.Products.GetProductById
{    
    public record GetProductByIdResponse(Product Product);
    public class GetProductByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{Id}", async (Guid Id, ISender Sender) =>
            {
                var result = await Sender.Send(new GetProductByIdQuery(Id));
                var response=result.Adapt<GetProductByIdResponse>();
                return Results.Ok(response);
            })
                .WithName("GetProductById")
                .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithDescription("Get Product By Id")
                .WithSummary("Get Product By Id");
        }
    }
}