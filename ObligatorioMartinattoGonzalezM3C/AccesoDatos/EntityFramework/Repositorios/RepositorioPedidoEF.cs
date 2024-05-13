using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioPedidoEF : IRepositorioPedido
    {

        PapeleriaContext _context;
        public RepositorioPedidoEF()
        {
            this._context = new PapeleriaContext();
        }
        public bool Add(Pedido aAgregar)
        {
            try
            {
                aAgregar.ConfiguracionObj = this._context.Configuraciones.Where(config => config.Nombre == "IVA").FirstOrDefault();
                this._context.Pedidos.Add(aAgregar);
                this._context.SaveChanges();
                Articulo elArticulo;
                foreach(Linea linea in aAgregar.Lineas)
                {
                    elArticulo = this._context.Articulos.Where(articulo => articulo.Id == linea.ArticuloId).FirstOrDefault();
                    elArticulo.Stock = elArticulo.Stock - linea.CantUnidades;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Pedido> FindAll()
        {
            return this._context.Pedidos;
        }

        public Pedido FindByID(int id)
        {
            return this._context.Pedidos.Where(pedido => pedido.Id == id).FirstOrDefault();
        }

        public bool Remove(int id)
        {
            try
            {
                Pedido aBorrar = FindByID(id);
                this._context.Pedidos.Remove(aBorrar);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Pedido aModificar)
        {
            try
            {
                this._context.Pedidos.Update(aModificar);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public double CalcularPrecio(Pedido pedido)
        {
            return pedido.CalcularPrecio((this._context.Configuraciones.
                Where(config => config.Nombre == "IVA").FirstOrDefault()).Valor);
        }

    }
}
