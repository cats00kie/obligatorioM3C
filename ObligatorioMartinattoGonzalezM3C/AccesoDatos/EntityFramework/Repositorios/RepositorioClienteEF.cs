using AccesoDatos.EntityFramework;
using Microsoft.EntityFrameworkCore;
using LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using Papeleria.LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioClienteEF : IRepositorioCliente
    {
        private PapeleriaContext _context;
        public RepositorioClienteEF()
        {
            this._context = new PapeleriaContext();
        }
        public bool Add(Cliente aAgregar)
        {
            try
            {
                this._context.Clientes.Add(aAgregar);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Cliente> ClientesXmonto(double monto)
        {
            List<Cliente> clientes = new List<Cliente>();
            int iva = this._context.Configuraciones
                                .Where(config => config.Nombre == "IVA")
                                .FirstOrDefault().Valor;

            IEnumerable<Pedido> pedidos = _context.Pedidos
                                 .Include(pedido => pedido.Lineas)
                                 .AsEnumerable()
                                 .Where(pedido => pedido.CalcularPrecio(iva) >= monto)
                                 .ToList();

            foreach (Pedido pedido in pedidos)
            {
                if (!clientes.Contains(pedido.ClienteObj)) clientes.Add(pedido.ClienteObj);
            }
            return clientes;
        }

        public IEnumerable<Cliente> ClientesXnombreYapellido(string especifica)
        {
            return this._context.Clientes.Where(cliente => cliente.NombreCliente.Nombre.Contains(especifica) 
            || cliente.NombreCliente.Apellido.Contains(especifica)).ToList();
        }

        public IEnumerable<Cliente> FindAll()
        {
            return this._context.Clientes;
        }

        public Cliente FindByID(int id)
        {
            return this._context.Clientes.Where(cliente => cliente.Id == id).FirstOrDefault();
        }

        public bool Remove(int id)
        {
            try
            {
                Cliente aBorrar = FindByID(id);
                this._context.Clientes.Remove(aBorrar);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Cliente aModificar)
        {
            try
            {
                this._context.Clientes.Update(aModificar);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
