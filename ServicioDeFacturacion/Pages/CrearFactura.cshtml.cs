using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServicioDeFacturacion.Pages
{
    // Esta clase es el PageModel asociado a la página CrearFactura.
    // La vista se encarga de la parte visual, y esta clase captura los datos enviados desde el formulario.
    public class CrearFacturaModel : PageModel
    {
        // BindProperty permite que los valores enviados desde el frontend se conecten automáticamente a estas propiedades.
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

        public CrearFacturaModel(ILogger<CrearFacturaModel> logger)
        {
            _logger = logger;
        }

        // OnGet se ejecuta cuando el usuario abre la página con una solicitud GET.
        public void OnGet()
        {
            FechaFactura = DateTime.Today;
            RequiereSeguimiento = false;
            EstaPagada = false;
            MensajeExito = string.Empty;
        }

        // OnPost se ejecuta cuando el usuario envía el formulario mediante el método POST.
        // Aquí se demuestra el flujo básico de Razor Pages: formulario -> POST -> model binding -> PageModel.
        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(DescripcionFactura))
            {
                ModelState.AddModelError(nameof(DescripcionFactura), "Debe ingresar una descripción para la factura.");
                return Page();
            }

            if(FechaFactura > DateTime.Today)
            {
                ModelState.AddModelError(nameof(FechaFactura), "La fecha de la factura no puede ser futura.");
                return Page();
            }

            //API
            //HTTP POST Amazon API (factura)

            // En este punto se podría guardar en base de datos o realizar más validaciones.
            // Por ahora, solo se muestra un mensaje para explicar la idea del proceso.
            MensajeExito = $"La factura '{DescripcionFactura}' fue recibida correctamente y queda registrada para revisión.";

            _logger.LogInformation(
                $"Factura creada con fecha {FechaFactura}, requiere seguimiento: {RequiereSeguimiento}, pagada: {EstaPagada}",
                FechaFactura,
                RequiereSeguimiento,
                EstaPagada);

            return Page();
        }
    }
}
