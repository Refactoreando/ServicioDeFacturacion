using Microsoft.EntityFrameworkCore;

namespace ServicioDeFacturacion.Data
{
    // DbContext representa la sesión con la base de datos para Entity Framework Core.
    // Aquí se configuran las entidades que formarán parte del modelo de datos.
    public class ServicioDeFacturacionDbContext : DbContext
    {
        public ServicioDeFacturacionDbContext(DbContextOptions<ServicioDeFacturacionDbContext> options)
            : base(options)
        {
        }

        // DbSet representa la tabla Facturas en la base de datos.
        public DbSet<Factura> Facturas { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Este bloque es útil para definir reglas adicionales del modelo si más adelante se necesitan.
        //    // Por ahora, dejamos la configuración básica para que Entity Framework Core mapée la entidad correctamente.
        //    modelBuilder.Entity<Factura>(entity =>
        //    {
        //        entity.HasKey(f => f.Id);
        //        entity.Property(f => f.Id).ValueGeneratedOnAdd();

        //        entity.Property(f => f.NumeroFactura)
        //            .IsRequired()
        //            .HasColumnType("nvarchar(50)");

        //        entity.Property(f => f.DescripcionFactura)
        //            .HasColumnType("nvarchar(500)");

        //        entity.Property(f => f.FechaFactura)
        //            .IsRequired()
        //            .HasColumnType("datetime");

        //        entity.Property(f => f.RequiereSeguimiento)
        //            .IsRequired();

        //        entity.Property(f => f.EstaPagado)
        //            .IsRequired();

        //        entity.Property(f => f.CreatedBy)
        //            .IsRequired()
        //            .HasColumnType("nvarchar(100)");

        //        entity.Property(f => f.CreatedDate)
        //            .IsRequired()
        //            .HasColumnType("datetime");

        //        entity.Property(f => f.UpdatedBy)
        //            .HasColumnType("nvarchar(100)");

        //        entity.Property(f => f.UpdatedDate)
        //            .HasColumnType("datetime");
        //    });

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
