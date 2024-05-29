// Esta instrucción permite que la aplicación use el nuevo servicio.
using BlazingPizza.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//  La instrucción AddHttpClient permite que la aplicación acceda a comandos HTTP. La aplicación usa HttpClient para obtener el JSON
//  de los especiales de pizza. La segunda instrucción registra el nuevo elemento PizzaStoreContext y proporciona el nombre de archivo de la base de datos SQLite.
builder.Services.AddHttpClient();
builder.Services.AddSqlite<PizzaStoreContext>("Data Source=pizza.db");

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
// Mapea una ruta predeterminada para los controladores
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

// Este cambio crea un ámbito de base de datos con PizzaStoreContext. Si no hay una base de datos ya creada,
// llama a la clase estática SeedData para crear una.
// Initialize the database
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PizzaStoreContext>();
    if (db.Database.EnsureCreated())
    {
        SeedData.Initialize(db);
    }
}

app.Run();