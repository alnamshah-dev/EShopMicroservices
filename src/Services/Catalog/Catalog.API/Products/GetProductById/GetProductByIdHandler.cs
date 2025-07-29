namespace Catalog.API.Products.GetProductById
{
    public record GetProductByIdQuery(Guid Id):IQuery<GetProductByIdResult>;
    public record GetProductByIdResult(Product Product);
    public class GetProductByIdQueryHandler(IDocumentSession session, ILogger<GetProductByIdQueryHandler> logger) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery Query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductByIdQueryHandler.Handle called with {@Query}", Query);
            var product=await session.LoadAsync<Product>(Query.Id,cancellationToken);
            if (product is null)
            {
                throw new ProductNotFoundException(Query.Id);
            }
            return new GetProductByIdResult(product);
        }
    }
}