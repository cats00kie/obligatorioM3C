using LogicaNegocio.InterfacesRepositorio;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Pedido;
using Papeleria.LogicaAplicacion.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Pedidos
{
    public class CrearPedidoCU : ICrearPedido
    {
        private IRepositorioPedido _repositorioPedido;
        public CrearPedidoCU(IRepositorioPedido repositorioPedido)
        {
            _repositorioPedido = repositorioPedido;
        }

        public void CrearPedido(PedidoDTO pedido, Boolean esExpress)
        {
            if (esExpress) this._repositorioPedido.Add(PedidoDTOMapper.FromDtoExpress(pedido));
            else this._repositorioPedido.Add(PedidoDTOMapper.FromDtoComun(pedido));
        }
    }
}
