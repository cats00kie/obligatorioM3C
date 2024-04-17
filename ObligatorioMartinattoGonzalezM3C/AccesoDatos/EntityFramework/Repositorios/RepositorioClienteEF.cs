using AccesoDatos.EntityFramework;
using LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
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

        //public Cliente FindByNombreCompleto(string email)
        //{
        //    return this._context.Clientes.Where(cliente => cliente.== email).FirstOrDefault();
        //}

        public bool Remove(int id)
        {
            try
            {
                Cliente aBorrar = new Cliente { Id = id };
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
