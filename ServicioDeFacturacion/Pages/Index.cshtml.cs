using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServicioDeFacturacion.Pages
{
    // Esta clase es el PageModel asociado a la página index.
    // Mientras que Index.cshtml define la estructura HTML, esta clase contiene la lógica:
    // preparar datos, manejar peticiones HTTP, validar entradas y decidir qué mostrar.
    public class IndexModel : PageModel
    {
        // El logger se inyecta automáticamente por Dependency Injection.
        // Esto permite registrar información sin crear manualmente la dependencia.
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        // `OnGet` se ejecuta cuando se solicita la página con una petición GET.
        // Aquí es el lugar ideal para cargar datos o preparar valores antes del renderizado.
        public void OnGet()
        {
            // En esta plantilla inicial no hay lógica adicional, pero este método es el punto de entrada principal.
        }
    }
}
