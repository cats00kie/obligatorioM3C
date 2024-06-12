using AccesoDatos.EntityFramework.Repositorios;
using ApplicationLogic.UseCases.TeamsUCs;
using LogicaNegocio.InterfacesRepositorio;
using Papeleria.AccesoDatos;
using Papeleria.AccesoDatos.EntityFramework.Repositorios;
using Papeleria.LogicaAplicacion.CasosDeUso.Articulos;
using Papeleria.LogicaAplicacion.CasosDeUso.Pedidos;
using Papeleria.LogicaAplicacion.CasosDeUso.TMov;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Articulo;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Cliente;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Pedido;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.TMov;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepositorioArticulo, RepositorioArticuloEF>();
builder.Services.AddScoped<IRepositorioPedido, RepositorioPedidoEF>();
builder.Services.AddScoped<IRepositorioTipoMovimiento, RepositorioTipoMovimientoEF>();


builder.Services.AddScoped<IEncontrarArticulosOrd, EncontrarArticulosOrdCU>();
builder.Services.AddScoped<IGetPedidosDesc, GetPedidosDescCU>();
builder.Services.AddScoped<IGetAllTMov, GetAllTMovCU>();
builder.Services.AddScoped<ICrearTMov, CrearTMovCU>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
