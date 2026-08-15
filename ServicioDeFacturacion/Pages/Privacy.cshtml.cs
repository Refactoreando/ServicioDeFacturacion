using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServicioDeFacturacion.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogInformation("Se accedió a la página de política de privacidad.");
        }
    }
}
