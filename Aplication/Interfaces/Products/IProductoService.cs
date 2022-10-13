using Domain.Dtos.Response;

namespace Application.Interfaces.Products
{
    public interface IProductoService
    {
        Task<ProductoResponse> GetProductById(int productId);
        Task<IList<ProductoResponse>> GetAllProductsSort(bool sort);
        Task<IList<ProductoResponse>> GetProductsByName(string name, bool sort);
        Task<bool> Find(int id);
    }
}
