using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServicioDeFacturacion.Data
{
    // Esta clase representa la entidad Facturas en SQL Server.
    // Entity Framework Core usa esta clase para mapear la tabla y sus columnas.
    [Table("Facturas")]
    public class Factura
    {
        // Id es la clave primaria y se genera automáticamente con identity en SQL Server.
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // NumeroFactura se mapeara como NVARCHAR(50) en la base de datos.
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string NumeroFactura { get; set; } = string.Empty;

        // DescripcionFactura es opcional y puede ser nulo en SQL Server.
        [Column(TypeName = "nvarchar(500)")]
        public string? DescripcionFactura { get; set; }

        // FechaFactura se guarda como DATETIME.
        [Required]
        public DateTime FechaFactura { get; set; }

        // RequiereSeguimiento y EstaPagado se corresponden con BIT en SQL Server.
        [Required]
        public bool RequiereSeguimiento { get; set; }

        [Required]
        public bool EstaPagado { get; set; }

        // CreatedBy y CreatedDate son obligatorios.
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string CreatedBy { get; set; } = string.Empty;

        [Required]
        public DateTime CreatedDate { get; set; }

        // UpdatedBy y UpdatedDate son opcionales porque pueden ser nulos.
        [Column(TypeName = "nvarchar(100)")]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
