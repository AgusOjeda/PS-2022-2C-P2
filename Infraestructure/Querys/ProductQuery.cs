using Application.Interfaces.Products;
using Domain.Dtos;
using Domain.Mappers;
using Infraestructure.Persistence;


namespace Infraestructure.Querys
{
    public class ProductQuery : IProductoQuery
    {
        private readonly AppDbContext _context;

        public ProductQuery(AppDbContext context)
        {
            _context = context;
        }
        
        public ICollection<ProductoDto> GetAll()
        {
            var list = _context.Producto.Select(x => x.MapProducto()).ToList();
            return list;
        }

        public Task<ProductoDto> GetById(int id)
        {
            var product = _context.Producto.Find(id);
            if (product == null)
            {
                return null;
            }
            return Task.FromResult(product.MapProducto());

        }
    }
}
