using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServicioDeFacturacion.Pages
{
    // Esta clase representa la página principal del servicio de facturación.
    // La vista decides cómo se presenta la información, y este modelo prepara los textos y datos iniciales.
    public class IndexModel : PageModel
    {
        public string Mensaje { get; set; } = string.Empty;

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        // OnGet se ejecuta al cargar la página con una petición GET.
        public void OnGet()
        {
            Mensaje = "La aplicación está lista para crecer con nuevas funciones de facturación en futuras etapas del tutorial.";
            _logger.LogInformation("Se ha cargado la página principal del servicio de facturación.");
        }
    }
}
