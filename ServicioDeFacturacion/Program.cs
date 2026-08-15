var builder = WebApplication.CreateBuilder(args);

// Este es el punto de entrada de la aplicación ASP.NET Core.
// Aquí se crean los servicios y se configuran los componentes principales antes de arrancar la app.

// Ejemplo sencillo de configuración: leemos un valor desde appsettings.json y lo usamos más adelante.
// Esto demuestra que la aplicación puede tomar datos de configuración sin escribir valores fijos en el código.
var appName = builder.Configuration["AppName"] ?? "Servicio de Facturación";

// Agregamos el soporte para Razor Pages.
// Con esto, ASP.NET Core sabrá cómo resolver páginas como /Index, /Privacy o /Error.
builder.Services.AddRazorPages();

// Construimos la aplicación con toda la configuración registrada en el contenedor de servicios.
var app = builder.Build();

// Pipeline de HTTP: aquí se añaden middlewares en el orden en que se ejecutan.
// Cada petición pasa por estas capas antes de llegar a la página correcta.
if (!app.Environment.IsDevelopment())
{
    // En entorno de producción, las excepciones se redirigen a la página /Error para un manejo centralizado.
    app.UseExceptionHandler("/Error");

    // HSTS obliga a que el navegador solo use HTTPS durante un tiempo determinado.
    app.UseHsts();
}

// Redirige automáticamente las peticiones HTTP a HTTPS para mejorar la seguridad.
app.UseHttpsRedirection();

// Permite servir archivos estáticos como CSS, JS e imágenes desde wwwroot.
app.UseStaticFiles();

// Detecta la ruta correcta de la petición y la conecta con el endpoint correspondiente.
app.UseRouting();

// Aquí se configuran políticas de autorización/autenticación.
// En esta demo inicial no hay usuarios ni roles, pero el sitio ya está preparado para añadirlos después.
app.UseAuthorization();

// Mapea las páginas Razor para que cada .cshtml y su PageModel puedan responder por URL.
app.MapRazorPages();

// Un pequeño ejemplo de uso de configuración en la aplicación en ejecución.
app.Logger.LogInformation("Aplicación iniciada: {AppName}", appName);

// Arranca la aplicación y queda escuchando peticiones en el puerto configurado.
app.Run();
