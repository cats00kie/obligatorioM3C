using AccesoDatos.EntityFramework;
using LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Excepciones;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioMovimientoEF : IRepositorioMovimiento
    {
        PapeleriaContext _context;
        public RepositorioMovimientoEF()
        {
            this._context = new PapeleriaContext();
        }
        public bool Add(Movimiento aAgregar)
        {
            try
            {
                Articulo elArticulo = this._context.Articulos.Where(a => a.Id == aAgregar.ArticuloId).FirstOrDefault();
                TipoMovimiento elTipo = this._context.TipoMovimientos.Where(t => t.Id == aAgregar.TipoMovimientoId).FirstOrDefault();
                Usuario elUsuario = this._context.Usuarios.Where(u => u.Email == aAgregar.EmailUsuario).FirstOrDefault();
                aAgregar.IsValid();
                this._context.Movimientos.Add(aAgregar);
                this._context.SaveChanges();
                return true;
            }
            catch (TMovException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Movimiento> FindAll()
        {
            return this._context.Movimientos;
        }

        public Movimiento FindByID(int id)
        {
            return this._context.Movimientos.Where(t => t.Id == id).FirstOrDefault();
        }

        public bool Remove(int id)
        {
            try
            {

                Movimiento aBorrar = FindByID(id);

                    this._context.Movimientos.Remove(aBorrar);
                    this._context.SaveChanges();
                    return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Movimiento aModificar)
        {
            try
            {
                
                    this._context.Movimientos.Update(aModificar);
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
