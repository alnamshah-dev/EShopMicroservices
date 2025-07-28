namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductResponse(bool IsSuccess);
    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/products/{Id}", async (Guid Id, ISender Sender) => {
                var result = await Sender.Send(new DeleteProductCommand(Id));
                var response = result.Adapt<DeleteProductResponse>();
                return Results.Ok(response);
            })
                .WithName("DeleteProduct")
                .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .ProducesProblem(StatusCodes.Status404NotFound)
                .WithDescription("Delete Product")
                .WithSummary("Delete Product");
        }
    }
}