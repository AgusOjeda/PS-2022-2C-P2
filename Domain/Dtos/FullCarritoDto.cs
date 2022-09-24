namespace Domain.Dtos
{
    public class FullCarritoDto
    {
        public Guid CarritoId { get; set; }
        public Boolean Estado { get; set; }
        public ClienteDto Cliente { get; set; }
        public ICollection<FullCarritoProductoDto> CarritoProducto { get; set; }
    }
}