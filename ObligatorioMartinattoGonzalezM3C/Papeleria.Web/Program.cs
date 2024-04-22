using Papeleria.AccesoDatos.EntityFramework.Repositorios;
using Papeleria.LogicaAplicacion.CasosDeUso;
using Papeleria.LogicaAplicacion.CasosDeUso.Administradores;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Administrador;
using LogicaNegocio.InterfacesRepositorio;
using AccesoDatos.EntityFramework;
using Papeleria.LogicaNegocio.InterfacesRepositorio;

namespace Papeleria.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddScoped<IRepositorioAdministrador, RepositorioAdministradorEF>();
            builder.Services.AddScoped<IRepositorioCliente, RepositorioClienteEF>();

            builder.Services.AddScoped<ILogin, LoginCU>();
            builder.Services.AddScoped<IGetArticulosAsc, GetArticulosAscCU>();
            builder.Services.AddScoped<IGetPedidosDesc, GetPedidosDescCU>();
            builder.Services.AddScoped<ICrearAdmin, CrearAdminCU>();
            builder.Services.AddScoped<IEditarAdmin, EditarAdminCU>();

            builder.Services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromSeconds(5000);
                option.Cookie.HttpOnly = true;
                option.Cookie.IsEssential = true;
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");

            app.Run();
        }
    }
}