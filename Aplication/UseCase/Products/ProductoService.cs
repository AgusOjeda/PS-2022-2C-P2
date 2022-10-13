using Application.Interfaces.Products;
using Domain.Dtos.Response;


namespace Application.UseCase.Products
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoQuery _query;

        public ProductoService(IProductoQuery query)
        {
            _query = query;
        }
        public async Task<IList<ProductoResponse>> GetAllProductsSort(bool sort)
        {
            var products = await _query.GetProductsSorted(sort);
            return products;
        }
        public async Task<ProductoResponse> GetProductById(int productId)
        {
            var product = await _query.GetById(productId);
            return product;
        }
        public async Task<IList<ProductoResponse>> GetProductsByName(string name, bool sort)
        {
            var product = await _query.GetProductsByNameSorted(name, sort);
            return product;
        }
        public async Task<bool> Find(int id)
        {
            return await _query.FindById(id);
        }
    }
}
