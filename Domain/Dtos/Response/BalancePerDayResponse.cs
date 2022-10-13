using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Debe devolver la reacaudacion del dia, con las ventas realizadas y sus respectivos productos
 */
namespace Domain.Dtos.Response
{
    public record BalancePerDayResponse(decimal TotalRevenue,
        IList<SalesResponse> Sales);
    public record SalesResponse(Guid OrdenId,
        Guid CarritoId,
        string ClientName,
        string ClientDNI,
        DateTime Date,
        decimal Total,
        CartSalesResponse Cart);
    public record CartSalesResponse(
        ICollection<ProductSalesResponse> Products);
    public record ProductSalesResponse(string Nombre,
        string Marca,
        string Codigo,
        decimal Precio, 
        int Cantidad,
        string ImagenUrl);
}