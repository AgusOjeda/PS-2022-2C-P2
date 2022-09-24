using Application.Interfaces;
using Application.Interfaces.Products;
using Application.Response;
using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.Products
{
    public class ProductoService : IProductoService
    {
        private readonly ICommandHandler<Producto> _command;
        private readonly IProductoQuery _query;

        public ProductoService(ICommandHandler<Producto> command, IProductoQuery query)
        {
            _command = command;
            _query = query;
        }
        
        public Task<ICollection<ProductoDto>> GetAllProducts()
        {
            var products = _query.GetAll();
            return Task.FromResult(products);
        }

        public Task<ICollection<ProductoDto>> GetAllProductsByCarritoId(Guid carritoId)
        {
            throw new NotImplementedException();
        }

        public Task<ProductoDto> GetProductById(int productId)
        {
            var product = _query.GetById(productId);
            return product;
        }
    }
}
