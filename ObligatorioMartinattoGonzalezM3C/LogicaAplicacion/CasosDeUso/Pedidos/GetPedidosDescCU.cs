using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Articulo;
using Papeleria.LogicaAplicacion.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Pedidos
{
    public class GetPedidosDescCU : IGetPedidosDesc
    {
        private IRepositorioPedido _repositorioPedido;
        public GetPedidosDescCU(IRepositorioPedido repositorioPedido)
        {
            _repositorioPedido = repositorioPedido;
        }

        public IEnumerable<PedidoDTO> GetPedidosDesc()
        {
            IEnumerable<Pedido> pedidos = _repositorioPedido.FindAll().Where(pedido => pedido.Anulado).OrderByDescending(pedido => pedido.Fecha);
            List<PedidoDTO> pedidosDto = new List<PedidoDTO>();
            foreach (Pedido pedido in pedidos)
            {
                if (pedido is PedidoComun) pedidosDto.Add(PedidoDTOMapper.FromComun(pedido as PedidoComun));
                else pedidosDto.Add(PedidoDTOMapper.FromExpress(pedido as PedidoExpress));
            }
            return pedidosDto;
        }
    }
}
