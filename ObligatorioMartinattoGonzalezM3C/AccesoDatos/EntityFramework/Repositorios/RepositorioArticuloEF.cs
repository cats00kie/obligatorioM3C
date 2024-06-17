using Azure;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioArticuloEF : IRepositorioArticulo
    {
        private PapeleriaContext _context;
        public RepositorioArticuloEF()
        {
            this._context = new PapeleriaContext();
        }
        public bool Add(Articulo aAgregar)
        {
            try
            {
                this._context.Articulos.Add(aAgregar);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Articulo> FindAll()
        {
            return this._context.Articulos;
        }

        public Articulo FindByID(int id)
        {
            return this._context.Articulos.Where(articulo => articulo.Id == id).FirstOrDefault();
        }

        public IEnumerable<Articulo> GetMovidosByFecha(DateTime startdate, DateTime enddate, int pag, int size)
        {
            return this._context.Movimientos.Where(m => m.FechaMovimiento >= startdate && m.FechaMovimiento <= enddate).Select(m => m.Articulo)
                .Skip((pag - 1) * size).Take(size).ToList();
        }

        public bool Remove(int id)
        {
            try
            {
                Articulo aBorrar = FindByID(id);
                this._context.Articulos.Remove(aBorrar);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Articulo aModificar)
        {
            try
            {
                this._context.Articulos.Update(aModificar);
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
