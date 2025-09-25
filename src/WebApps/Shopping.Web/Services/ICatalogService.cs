namespace Shopping.Web.Services;
public interface ICatalogService
{
    [Get("/catalog-service/products?pageNumber={pageNumber}&pageSize={pageSize}")]
    Task<GetProductsResponse> GetProducts(int? pageNumber=1, int? pageSize=10);

    [Get("/catalog-service/products/{Id}")]
    Task<GetProductByIdResponse> GetProduct(Guid Id);
    
    [Get("/catalog-service/products/category/{category}")]
    Task<GetProductByCategoryResponse> GetProductsByCategory(string category);
}