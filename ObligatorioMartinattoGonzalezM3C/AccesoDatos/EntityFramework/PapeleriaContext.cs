using Papeleria.LogicaNegocio;
using LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.GeoJson;
using System.Security.Cryptography;

namespace AccesoDatos.EntityFramework
{
    public class PapeleriaContext : DbContext
    {
        public DbSet<Usuario> Usuarios;
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Administrador> Admins { get; set; }
        //public DbSet<Pedido> Pedidos { get; set; }
        //public DbSet<PedidoComun> Comunes { get; set; }
        //public DbSet<PedidoExpress> PedidosExpress { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        //public DbSet<Linea> Lineas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"SERVER=(localdb)\MsSqlLocalDb;DATABASE=PapeleriaObligatorio;Integrated Security=true;");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Administrador>();
        //}
         
    }
}
