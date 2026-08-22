using Microsoft.EntityFrameworkCore;
using ServicioDeFacturacion.Data;

var builder = WebApplication.CreateBuilder(args);

// Este es el punto de entrada de la aplicación ASP.NET Core.
// Aquí se crean los servicios y se configuran los componentes principales antes de arrancar la app.

// Ejemplo sencillo de configuración: leemos un valor desde appsettings.json y lo usamos más adelante.
var appName = builder.Configuration["AppName"] ?? "Servicio de Facturación";

// Agregamos el soporte para Razor Pages.
// Con esto, ASP.NET Core sabrá cómo resolver páginas como /Index, /Privacy o /Error.
builder.Services.AddRazorPages();

// Registramos el DbContext en el contenedor de dependencias de ASP.NET Core.
// Esto permite que cualquier Razor Page o servicio pueda pedir ServicioDeFacturacionDbContext mediante inyección de dependencias.
builder.Services.AddDbContext<ServicioDeFacturacionDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Construimos la aplicación con toda la configuración registrada en el contenedor de servicios.
var app = builder.Build();

// Antes de arrancar la aplicación, aseguramos que la base de datos exista.
// Esto es útil para una demostración educativa, porque permite que la app pueda crear la base de datos LocalDB automáticamente si no existe.
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ServicioDeFacturacionDbContext>();
    dbContext.Database.EnsureCreated();
}

// Pipeline de HTTP: aquí se añaden middlewares en el orden en que se ejecutan.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Logger.LogInformation("Aplicación iniciada: {AppName}", appName);

app.Run();
