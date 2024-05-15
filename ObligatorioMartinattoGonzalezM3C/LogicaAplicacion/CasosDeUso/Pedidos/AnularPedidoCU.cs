using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Pedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Pedidos
{
    public class AnularPedidoCU : IAnularPedido
    {
        private IRepositorioPedido _repositorioPedido;
        public AnularPedidoCU(IRepositorioPedido repositorioPedido)
        {
            _repositorioPedido = repositorioPedido;
        }
        public void AnularPedido(int id)
        {
            try
            {
                Pedido elPedido = _repositorioPedido.FindByID(id);
                elPedido.Anulado = true;
                _repositorioPedido.Update(elPedido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
