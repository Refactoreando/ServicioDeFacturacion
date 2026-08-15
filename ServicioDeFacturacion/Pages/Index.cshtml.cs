using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServicioDeFacturacion.Pages
{
    // Esta clase es el PageModel asociado a la página index.
    // Mientras que Index.cshtml define la estructura HTML, esta clase contiene la lógica:
    // preparar datos, manejar peticiones HTTP, validar entradas y decidir qué mostrar.
    public class IndexModel : PageModel
    {
        public string Mensaje { get; set; } = string.Empty;

        // Se usa para recoger el valor del formulario.
        [BindProperty]
        public string NombreCliente { get; set; } = string.Empty;

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
            Mensaje = "Bienvenido a la página de inicio de ServicioDeFacturacion.";
        }

        // `OnPost` se ejecuta cuando el usuario envía el formulario con método POST.
        public void OnPost()
        {
            // Aquí se puede validar, procesar o guardar datos.
            // En este ejemplo, simplemente cambiamos el mensaje para demostrar que la petición POST se está ejecutando.
            Mensaje = $"Gracias {NombreCliente}, el formulario fue enviado correctamente.";
        }
    }
}
