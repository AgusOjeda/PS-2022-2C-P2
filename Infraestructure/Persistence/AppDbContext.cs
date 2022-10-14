using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infraestructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Carrito> Carrito { get; set; }
        public DbSet<CarritoProducto> CarritoProducto { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Orden> Orden { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator != null)
                {
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Cliente");
                entity.HasKey(e => e.ClienteId);
                entity.Property(e => e.ClienteId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ClienteId")
                    .HasColumnType("int");
                entity.Property(e => e.DNI)
                    .IsRequired()
                    .HasColumnName("DNI")
                    .HasColumnType("nvarchar(10)");
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("Nombre")
                    .HasColumnType("nvarchar(25)");
                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasColumnName("Apellido")
                    .HasColumnType("nvarchar(25)");
                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("Direccion")
                    .HasColumnType("nvarchar(max)");
                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("Telefono")
                    .HasColumnType("nvarchar(13)");

                entity.HasMany<Carrito>(e => e.CarritoNavigation)
                    .WithOne(c => c.ClienteNavigation)
                    .HasForeignKey(c => c.ClienteId);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Producto");
                entity.HasKey(e => e.ProductoId);
                entity.Property(e => e.ProductoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ProductoId")
                    .HasColumnType("int");
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("Nombre")
                    .HasColumnType("nvarchar(max)");
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("Descripcion")
                    .HasColumnType("nvarchar(max)");
                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasColumnName("Marca")
                    .HasColumnType("nvarchar(25)");
                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasColumnName("Codigo")
                    .HasColumnType("nvarchar(25)");
                entity.Property(e => e.Precio)
                    .IsRequired()
                    .HasColumnName("Precio")
                    .HasColumnType("decimal(15, 2)");
                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnName("Image")
                    .HasColumnType("nvarchar(max)");

                entity.HasMany<CarritoProducto>(e => e.CarritoProductoNavigation)
                    .WithOne(cp => cp.ProductoNavigation)
                    .HasForeignKey(cp => cp.ProductoId);
            });

            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.ToTable("Carrito");
                entity.HasKey(e => e.CarritoId);
                entity.Property(e => e.CarritoId)
                    .HasDefaultValueSql("NEWID()")
                    .HasColumnName("CarritoId")
                    .HasColumnType("uniqueidentifier");
                entity.Property(e => e.ClienteId)
                    .IsRequired()
                    .HasColumnName("ClienteId")
                    .HasColumnType("int");
                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("Estado")
                    .HasColumnType("bit");

                entity.HasOne<Orden>(c => c.OrdenNavigation)
                    .WithOne(o => o.CarritoNavigation)
                    .HasForeignKey<Orden>(o => o.CarritoId);
            });

            modelBuilder.Entity<CarritoProducto>(entity =>
            {
                entity.ToTable("CarritoProducto");
                entity.HasKey(cp => new { cp.CarritoId, cp.ProductoId });
                entity.Property(e => e.Cantidad)
                    .IsRequired()
                    .HasColumnName("Cantidad")
                    .HasColumnType("int");

                entity.HasOne<Carrito>(cp => cp.CarritoNavigation)
                    .WithMany(c => c.CarritoProductoNavigation)
                    .HasForeignKey(cp => cp.CarritoId);

                entity.HasOne<Producto>(cp => cp.ProductoNavigation)
                    .WithMany(p => p.CarritoProductoNavigation)
                    .HasForeignKey(cp => cp.ProductoId);
            });

            modelBuilder.Entity<Orden>(entity =>
            {
                entity.ToTable("Orden");
                entity.HasKey(e => e.OrdenId);
                entity.Property(e => e.OrdenId)
                    .HasDefaultValueSql("NEWID()")
                    .HasColumnName("OrdenId")
                    .HasColumnType("uniqueidentifier");
                entity.Property(e => e.Fecha)
                    .IsRequired()
                    .HasColumnName("Fecha")
                    .HasColumnType("datetime");
                entity.Property(e => e.Total)
                    .IsRequired()
                    .HasColumnName("Total")
                    .HasColumnType("decimal(15, 2)");
            });


            modelBuilder.Entity<Cliente>().HasData(
                new Cliente
                {
                    ClienteId = 1,
                    DNI = "12345678",
                    Nombre = "Juan",
                    Apellido = "Perez",
                    Direccion = "Av. Siempre Viva 123",
                    Telefono = "123456789"
                }
            );

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasData(new Producto
                {
                    ProductoId = 1,
                    Nombre = "Yerba Mate Playadito Suave X1kg",
                    Descripcion = "Yerba Mate x1kg",
                    Marca = "Playadito",
                    Codigo = "11230376006",
                    Precio = 790.00M,
                    Image = "https://res.cloudinary.com/dywphbg73/image/upload/v1663098494/PS-2022-ProductImages/Yerba-Mate-Playadito-Suave-X1kg-1-854539_rhbph6.webp"
                }, new Producto
                {
                    ProductoId = 2,
                    Nombre = "Atún En Aceite La Campagnola 120 Gr",
                    Descripcion = "Atuen en aceite 120gr",
                    Marca = "La Campagnola",
                    Codigo = "11640503002",
                    Precio = 407.00M,
                    Image = "https://res.cloudinary.com/dywphbg73/image/upload/v1663098494/PS-2022-ProductImages/At-n-En-Aceite-La-Campagnola-120-Gr-1-3616_h50msj.webp"
                }, new Producto
                {
                    ProductoId = 3,
                    Nombre = "Harina Pureza Para Pizza 1 Kg",
                    Descripcion = "Harina Para Pizza 1 Kg",
                    Marca = "Pureza",
                    Codigo = "11410401001",
                    Precio = 170.08M,
                    Image = "https://res.cloudinary.com/dywphbg73/image/upload/v1663098494/PS-2022-ProductImages/Harina-Pureza-Para-Pizza-1-Kg-1-27922_lmijmu.webp"
                }, new Producto
                {
                    ProductoId = 4,
                    Nombre = "Agua Baja En Sodio Glaciar 2 L",
                    Descripcion = "Agua Baja En Sodio 2 L",
                    Marca = "Glaciar",
                    Codigo = "12120102003",
                    Precio = 158.00M,
                    Image = "https://res.cloudinary.com/dywphbg73/image/upload/v1663098493/PS-2022-ProductImages/Agua-Baja-En-Sodio-Glaciar-2-L-2-237513_u085yv.webp"
                }, new Producto
                {
                    ProductoId = 5,
                    Nombre = "Agua Saborizada Aquarius Pera 2,25 Lt",
                    Descripcion = "Agua Saborizada Pera 2,25 Lt",
                    Marca = "Aquarius",
                    Codigo = "12150101021",
                    Precio = 277.00M,
                    Image = "https://res.cloudinary.com/dywphbg73/image/upload/v1663098493/PS-2022-ProductImages/Aquarius-Pera-225-L-2-468830_u3fcjl.webp"
                }, new Producto
                {
                    ProductoId = 6,
                    Nombre = "Café Instantaneo X 100g Segafredo",
                    Descripcion = "Café Instantaneo X 100g",
                    Marca = "Segafredo Zanetti",
                    Codigo = "11210551001",
                    Precio = 1285.00M,
                    Image = "https://res.cloudinary.com/dywphbg73/image/upload/v1663098494/PS-2022-ProductImages/Caf-Instantaneo-X-100g-Segafredo-1-879237_qcjkkp.webp"
                }, new Producto
                {
                    ProductoId = 7,
                    Nombre = "Cerveza Imperial Golden 473cc Lata",
                    Descripcion = "Cerveza 473cc Lata",
                    Marca = "Imperial",
                    Codigo = "12440120041",
                    Precio = 240.00M,
                    Image = "https://res.cloudinary.com/dywphbg73/image/upload/v1663098494/PS-2022-ProductImages/Cerveza-Imperial-Goden-473cc-Six-Pack-1-829046_nc2fyu.webp"
                }, new Producto
                {
                    ProductoId = 8,
                    Nombre = "Acondicionador Elvive Dream Long 400ml",
                    Descripcion = "Acondicionador 400ml",
                    Marca = "Elvive",
                    Codigo = "13720705002",
                    Precio = 624.00M,
                    Image = "https://res.cloudinary.com/dywphbg73/image/upload/v1663098494/PS-2022-ProductImages/Acondicionador-Dream-Long-Liss-Elvive-L-oreal-Paris-400-Ml-1-844714_cziujj.webp"
                }, new Producto
                {
                    ProductoId = 9,
                    Nombre = "Shampoo Elvive Dream Long Liss 400ml",
                    Descripcion = "Shampoo 400ml",
                    Marca = "Elvive",
                    Codigo = "13710203002",
                    Precio = 790.00M,
                    Image = "https://res.cloudinary.com/dywphbg73/image/upload/v1663098494/PS-2022-ProductImages/Shampoo-Dream-Long-Liss-Elvive-L-oreal-Paris-400-Ml-1-844667_ghkyas.webp"
                }, new Producto
                {
                    ProductoId = 10,
                    Nombre = "Aceite De Girasol Natura 1.5 L",
                    Descripcion = "Aceite De Girasol 1.5 L",
                    Marca = "Natura",
                    Codigo = "12610902002",
                    Precio = 390.00M,
                    Image = "https://res.cloudinary.com/dywphbg73/image/upload/v1663098494/PS-2022-ProductImages/Aceite-De-Girasol-Natura-15-L-1-247928_vsufc6.jpg"
                });

            });


        }
    }
}
