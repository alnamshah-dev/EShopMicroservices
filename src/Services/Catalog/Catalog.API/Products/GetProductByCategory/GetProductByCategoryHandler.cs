namespace Catalog.API.Products.GetProductByCategory
{
    public record GetProductByCategoryQuery(string category):IQuery<GetProductByCategoryResult>;
    public record GetProductByCategoryResult(IEnumerable<Product> Products);
    public class GetProductByCategoryQueryHandler(IDocumentSession session) : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery Query, CancellationToken cancellationToken)
        {
            var products=await session.Query<Product>().Where(p=>p.Category.Contains(Query.category)).ToListAsync();
            return new GetProductByCategoryResult(products);
        }
    }
}