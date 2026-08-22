using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServicioDeFacturacion.Data;

namespace ServicioDeFacturacion.Pages
{
    // Esta clase es el PageModel asociado a la página CrearFactura.
    // La vista se encarga de la parte visual, y esta clase captura los datos enviados desde el formulario.
    public class CrearFacturaModel : PageModel
    {
        // Este campo guarda la referencia al DbContext que ASP.NET Core inyecta automáticamente.
        private readonly ServicioDeFacturacionDbContext _context;

        // BindProperty permite que los valores enviados desde el frontend se conecten automáticamente a estas propiedades.
        [BindProperty]
        public string NumeroFactura { get; set; } = string.Empty;

        [BindProperty]
        public string? DescripcionFactura { get; set; }

        [BindProperty]
        public DateTime FechaFactura { get; set; } = DateTime.Today;

        [BindProperty]
        public bool RequiereSeguimiento { get; set; }

        [BindProperty]
        public bool EstaPagada { get; set; }

        // Este texto se muestra después de enviar el formulario para demostrar el flujo de POST.
        public string MensajeExito { get; private set; } = string.Empty;

        private readonly ILogger<CrearFacturaModel> _logger;

        // ASP.NET Core resuelve este constructor y pasa automáticamente el DbContext y el logger.
        public CrearFacturaModel(ServicioDeFacturacionDbContext context, ILogger<CrearFacturaModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        // OnGet se ejecuta cuando el usuario abre la página con una solicitud GET.
        public void OnGet()
        {
            FechaFactura = DateTime.Today;
            RequiereSeguimiento = false;
            EstaPagada = false;
            NumeroFactura = $"FAC-{DateTime.Today:yyyyMMdd}-{DateTime.Now:HHmmss}";
            MensajeExito = string.Empty;
        }

        // OnPost se ejecuta cuando el usuario envía el formulario mediante el método POST.
        // Aquí se demuestra el flujo básico de Razor Pages: formulario -> POST -> model binding -> PageModel -> DbContext -> SQL Server.
        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(NumeroFactura))
            {
                ModelState.AddModelError(nameof(NumeroFactura), "Debe ingresar un número de factura.");
                return Page();
            }

            if (string.IsNullOrWhiteSpace(DescripcionFactura))
            {
                ModelState.AddModelError(nameof(DescripcionFactura), "Debe ingresar una descripción para la factura.");
                return Page();
            }

            if (FechaFactura > DateTime.Today)
            {
                ModelState.AddModelError(nameof(FechaFactura), "La fecha de la factura no puede ser futura.");
                return Page();
            }

            // Se crea la entidad de dominio con los datos recibidos desde el formulario.
            var factura = new Factura
            {
                NumeroFactura = NumeroFactura,
                DescripcionFactura = DescripcionFactura,
                FechaFactura = FechaFactura,
                RequiereSeguimiento = RequiereSeguimiento,
                EstaPagado = EstaPagada,
                CreatedBy = "Sistema",
                CreatedDate = DateTime.Now,
                UpdatedBy = null,
                UpdatedDate = null
            };

            // Se agrega la entidad al DbSet y se guarda en SQL Server LocalDB.
            _context.Facturas.Add(factura);
            _context.SaveChanges();

            MensajeExito = $"La factura '{factura.NumeroFactura}' se guardó correctamente con Id {factura.Id}.";

            _logger.LogInformation(
                "Factura creada con Id {FacturaId}, numero {NumeroFactura}, requiere seguimiento: {RequiereSeguimiento}, pagada: {EstaPagada}",
                factura.Id,
                factura.NumeroFactura,
                factura.RequiereSeguimiento,
                factura.EstaPagado);

            return Page();
        }
    }
}
