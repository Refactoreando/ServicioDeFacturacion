var builder = WebApplication.CreateBuilder(args);

// Este es el punto de entrada de la aplicación ASP.NET Core.
// Aquí se crean los servicios y la configuración inicial antes de arrancar la app.

// Agregamos el soporte para Razor Pages, que es el modelo de programación de esta aplicación.
// Con esto, ASP.NET Core sabrá cómo resolver páginas como /Index, /Privacy, etc.
builder.Services.AddRazorPages();

// Construimos la aplicación con toda la configuración registrada en 'builder'.
var app = builder.Build();

// Pipeline de HTTP: aquí se configuran los middlewares en el orden en que se ejecutan.
// Es decir, cada petición pasa por estas capas antes de llegar a la página correcta.
if (!app.Environment.IsDevelopment())
{
    // En producción, se redirigen las excepciones a la página /Error para un manejo centralizado.
    app.UseExceptionHandler("/Error");
    // HSTS obliga a que el navegador use HTTPS durante un tiempo determinado.
    app.UseHsts();
}

// Redirige automáticamente peticiones HTTP a HTTPS para mayor seguridad.
app.UseHttpsRedirection();

// Permite servir archivos estáticos como CSS, JS e imágenes desde wwwroot.
app.UseStaticFiles();

// Detecta la ruta correcta de la petición y la conecta con el endpoint correspondiente.
app.UseRouting();

// Aquí se configura la autorización/autenticación, aunque en esta plantilla aún no hay roles ni usuarios.
app.UseAuthorization();

// Mapea las páginas Razor, de modo que cada .cshtml con su PageModel sea accesible por URL.
app.MapRazorPages();

// Arranca la aplicación y queda escuchando peticiones.
app.Run();
