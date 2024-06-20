using AccesoDatos.EntityFramework;
using LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Excepciones;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                aAgregar.IsValid(this._context.Configuraciones.Where(c => c.Nombre == "Tope").FirstOrDefault().Valor);
                this._context.Movimientos.Add(aAgregar);
                this._context.SaveChanges();
                return true;
            }
            catch (MovException ex)
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
            return this._context.Movimientos.Include(m =>m.TipoMovimiento).Include(m => m.Articulo);
        }

        public Movimiento FindByID(int id)
        {
            return this._context.Movimientos.Where(t => t.Id == id).FirstOrDefault();
        }

        public IEnumerable<Movimiento> GetMovs(int pag, int size)
        {
            return this._context.Movimientos.Include(m => m.Articulo).Include(m=>m.TipoMovimiento).Skip((pag - 1) * size).Take(size).ToList();
        }

        public IEnumerable<Movimiento> GetByArtyTipo(int articuloId, int tipoMovId, int pag, int size)
        {
            Articulo articulo = this._context.Articulos.Where(a => a.Id == articuloId).FirstOrDefault();
            TipoMovimiento tipo = this._context.TipoMovimientos.Where(t => t.Id == tipoMovId).FirstOrDefault();
            return this._context.Movimientos.Include(tipo => tipo.Articulo).Include(tipo => tipo.TipoMovimiento)
                .Where(mov => mov.TipoMovimiento == tipo && mov.Articulo == articulo)
                .OrderByDescending(mov => mov.FechaMovimiento).ThenBy(mov => mov.CantUnidades).Skip((pag - 1) * size).Take(size).ToList();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Movimiento aModificar)
        {
            throw new NotImplementedException();
        }
    }
}
