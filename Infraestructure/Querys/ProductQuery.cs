using Application.Interfaces.Products;
using Domain.Dtos;
using Application.Mappers;
using Infraestructure.Persistence;
using Domain.Dtos.Response;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Querys
{
    public class ProductQuery : IProductoQuery
    {
        private readonly AppDbContext _context;
        public ProductQuery(AppDbContext context)
        {
            _context = context;
        }     
        public async Task<ProductoResponse> GetById(int id)
        {
            var product = await _context.Producto.FindAsync(id);
            if (product == null)
            {
                return null;
            }
            return product.MapProducto();
        }  
        public async Task<IList<ProductoResponse>> GetProductsByNameSorted(string name, bool order)
        {
            var products = await _context.Producto
                .Where(x => EF.Functions.Like(x.Nombre, $"%{name}%"))
                .Select(x => x.MapProducto())
                .ToListAsync();
            if (products == null)
            {
                return null;
            }
            if (order)
            {
                products = products.OrderBy(x => x.Precio).ToList();
            }
            else
            {
                products = products.OrderByDescending(x => x.Precio).ToList();
            }
            return products;
        }
        public async Task<IList<ProductoResponse>> GetProductsSorted(bool order)
        {
            IList<ProductoResponse> products;
            if (order)
            {
                products = await _context.Producto
                    .OrderBy(x => x.Precio)
                    .Select(x => x.MapProducto())
                    .ToListAsync();
            }
            else
            {
                products = await _context.Producto
                    .OrderByDescending(x => x.Precio)
                    .Select(x => x.MapProducto())
                    .ToListAsync();
            }
            return products;
        }
        public async Task<bool> FindById(int id)
        {
            var product = await _context.Producto.FindAsync(id);
            if (product == null)
            {
                return false;
            }
            return true;
        }
    }
}
