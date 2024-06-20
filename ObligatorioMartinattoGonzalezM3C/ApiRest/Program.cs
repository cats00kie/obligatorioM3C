using AccesoDatos.EntityFramework;
using AccesoDatos.EntityFramework.Repositorios;
using ApplicationLogic.UseCases.TeamsUCs;
using LogicaNegocio.InterfacesRepositorio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Papeleria.AccesoDatos;
using Papeleria.AccesoDatos.EntityFramework.Repositorios;
using Papeleria.LogicaAplicacion.CasosDeUso.Administradores;
using Papeleria.LogicaAplicacion.CasosDeUso.Articulos;
using Papeleria.LogicaAplicacion.CasosDeUso.Movimientos;
using Papeleria.LogicaAplicacion.CasosDeUso.Pedidos;
using Papeleria.LogicaAplicacion.CasosDeUso.TMov;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Articulo;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Cliente;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Movimiento;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Pedido;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.TMov;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepositorioArticulo, RepositorioArticuloEF>();
builder.Services.AddScoped<IRepositorioPedido, RepositorioPedidoEF>();
builder.Services.AddScoped<IRepositorioTipoMovimiento, RepositorioTipoMovimientoEF>();
builder.Services.AddScoped<IRepositorioConfig, RepositorioConfiguracionEF>();
builder.Services.AddScoped<IRepositorioMovimiento, RepositorioMovimientoEF>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();

builder.Services.AddScoped<IEncontrarArticulosOrd, EncontrarArticulosOrdCU>();
builder.Services.AddScoped<IGetPedidosDesc, GetPedidosDescCU>();
builder.Services.AddScoped<IGetAllTMov, GetAllTMovCU>();
builder.Services.AddScoped<ICrearTMov, CrearTMovCU>();
builder.Services.AddScoped<IFindTMovById, FindTMovByIdCU>();
builder.Services.AddScoped<IDeleteTMov, DeleteTMovCU>();
builder.Services.AddScoped<IUpdateTMov, UpdateTMovCU>();
builder.Services.AddScoped<ICrearMovimiento, CrearMovimientoCU>();
builder.Services.AddScoped<IGetAllMovs, GetAllMovsCU>();
builder.Services.AddScoped<IGetByArtyTipo, GetByArtyTipoCU>();
builder.Services.AddScoped<IGetArticulosByFecha, GetArticulosByFechaCU>();
builder.Services.AddScoped<IGetMovsXFecha, GetMovsXFechaCU>();
builder.Services.AddScoped<IFindUserByEmail, FindUserByEmailCU>();
builder.Services.AddControllers();

var Clave = "ZWRpw6fDo28gZW0gY29tcHV0YWRvcmE=";

builder.Services.AddAuthentication(aut =>
{
    aut.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

    aut.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(aut =>
    {
        aut.RequireHttpsMetadata = false;
        aut.SaveToken = true;
        aut.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Clave)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
var ruta = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Papeleria.ApiRest.xml");
builder.Services.AddSwaggerGen(
        opciones =>
        {
            opciones.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
            {
                Description = "Autorización estándar mediante esquema Bearer",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });
            opciones.OperationFilter<SecurityRequirementsOperationFilter>();
            opciones.IncludeXmlComments(ruta);
            opciones.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "Papeleria Obligatorio",
                Description = "Aplicacion para administrar el deposito de la papeleria.",
                Contact = new Microsoft.OpenApi.Models.OpenApiContact
                {
                    Email = "mm.mateomartinatto@gmail.com"
                },
                Version = "v1"
            });
        }
    );


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
