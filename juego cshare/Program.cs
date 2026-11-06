using Canchas.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registrar el cliente de Supabase
builder.Services.AddSingleton<SupabaseCliente>();

// Configurar sesiones para el juego de adivinar el número
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // Obligatorio para que funcione el juego

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Juego}/{action=Index}/{id?}");

app.Run();