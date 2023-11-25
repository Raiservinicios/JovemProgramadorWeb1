using JovemProgramadorWeb1.Data.Repositorio.Interfaces;
using JovemProgramadorWeb1.Data.Repositorio;
using JovemProgramadorWeb1.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();

var connectionstring = builder.Configuration.GetConnectionString("StringConexao");
builder.Services.AddDbContext<BancoContexto>(options => options.UseSqlServer(connectionstring));


builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
