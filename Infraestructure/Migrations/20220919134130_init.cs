using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(13)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "Carrito",
                columns: table => new
                {
                    CarritoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrito", x => x.CarritoId);
                    table.ForeignKey(
                        name: "FK_Carrito_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarritoProducto",
                columns: table => new
                {
                    CarritoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoProducto", x => new { x.CarritoId, x.ProductoId });
                    table.ForeignKey(
                        name: "FK_CarritoProducto_Carrito_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "Carrito",
                        principalColumn: "CarritoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarritoProducto_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orden",
                columns: table => new
                {
                    OrdenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    CarritoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(15,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden", x => x.OrdenId);
                    table.ForeignKey(
                        name: "FK_Orden_Carrito_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "Carrito",
                        principalColumn: "CarritoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "ClienteId", "Apellido", "DNI", "Direccion", "Nombre", "Telefono" },
                values: new object[] { 1, "Perez", "12345678", "Av. Siempre Viva 123", "Juan", "123456789" });

            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "ProductoId", "Codigo", "Descripcion", "Image", "Marca", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, "11230376006", "Yerba Mate x1kg", "https://res.cloudinary.com/dywphbg73/image/upload/v1663098494/PS-2022-ProductImages/Yerba-Mate-Playadito-Suave-X1kg-1-854539_rhbph6.webp", "Playadito", "Yerba Mate Playadito Suave X1kg", 790.00m },
                    { 2, "11640503002", "Atuen en aceite 120gr", "https://res.cloudinary.com/dywphbg73/image/upload/v1663098494/PS-2022-ProductImages/At-n-En-Aceite-La-Campagnola-120-Gr-1-3616_h50msj.webp", "La Campagnola", "Atún En Aceite La Campagnola 120 Gr", 407.00m },
                    { 3, "11410401001", "Harina Para Pizza 1 Kg", "https://res.cloudinary.com/dywphbg73/image/upload/v1663098494/PS-2022-ProductImages/Harina-Pureza-Para-Pizza-1-Kg-1-27922_lmijmu.webp", "Pureza", "Harina Pureza Para Pizza 1 Kg", 170.08m },
                    { 4, "12120102003", "Agua Baja En Sodio 2 L", "https://res.cloudinary.com/dywphbg73/image/upload/v1663098493/PS-2022-ProductImages/Agua-Baja-En-Sodio-Glaciar-2-L-2-237513_u085yv.webp", "Glaciar", "Agua Baja En Sodio Glaciar 2 L", 158.00m },
                    { 5, "12150101021", "Agua Saborizada Pera 2,25 Lt", "https://res.cloudinary.com/dywphbg73/image/upload/v1663098493/PS-2022-ProductImages/Aquarius-Pera-225-L-2-468830_u3fcjl.webp", "Aquarius", "Agua Saborizada Aquarius Pera 2,25 Lt", 277.00m },
                    { 6, "11210551001", "Café Instantaneo X 100g", "https://res.cloudinary.com/dywphbg73/image/upload/v1663098494/PS-2022-ProductImages/Caf-Instantaneo-X-100g-Segafredo-1-879237_qcjkkp.webp", "Segafredo Zanetti", "Café Instantaneo X 100g Segafredo", 1285.00m },
                    { 7, "12440120041", "Cerveza 473cc Lata", "https://res.cloudinary.com/dywphbg73/image/upload/v1663098494/PS-2022-ProductImages/Cerveza-Imperial-Goden-473cc-Six-Pack-1-829046_nc2fyu.webp", "Imperial", "Cerveza Imperial Golden 473cc Lata", 240.00m },
                    { 8, "13720705002", "Acondicionador 400ml", "https://res.cloudinary.com/dywphbg73/image/upload/v1663098494/PS-2022-ProductImages/Acondicionador-Dream-Long-Liss-Elvive-L-oreal-Paris-400-Ml-1-844714_cziujj.webp", "Elvive", "Acondicionador Elvive Dream Long 400ml", 624.00m },
                    { 9, "13710203002", "Shampoo 400ml", "https://res.cloudinary.com/dywphbg73/image/upload/v1663098494/PS-2022-ProductImages/Shampoo-Dream-Long-Liss-Elvive-L-oreal-Paris-400-Ml-1-844667_ghkyas.webp", "Elvive", "Shampoo Elvive Dream Long Liss 400ml", 790.00m },
                    { 10, "12610902002", "Aceite De Girasol 1.5 L", "https://res.cloudinary.com/dywphbg73/image/upload/v1663098494/PS-2022-ProductImages/Aceite-De-Girasol-Natura-15-L-1-247928_vsufc6.jpg", "Natura", "Aceite De Girasol Natura 1.5 L", 390.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carrito_ClienteId",
                table: "Carrito",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_CarritoProducto_ProductoId",
                table: "CarritoProducto",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_CarritoId",
                table: "Orden",
                column: "CarritoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarritoProducto");

            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Carrito");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
