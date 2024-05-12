using LogicaNegocio.Entidades;
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
    public class EncontrarPrecioPedidoCU : IEncontrarPrecioPedido
    {
        private IRepositorioPedido _repositorioPedido;
        public EncontrarPrecioPedidoCU(IRepositorioPedido repositorioPedido)
        {
            this._repositorioPedido = repositorioPedido;
        }
        public double EncontrarPrecioPedido(PedidoDTO pedido, Boolean esExpress)
        {
            if (pedido == null) return 0;
            if (esExpress)
            {
                PedidoExpress elPedido = PedidoDTOMapper.FromDtoExpress(pedido); 
                return _repositorioPedido.CalcularPrecio(elPedido);
            }
            else
            {
                PedidoComun elPedido = PedidoDTOMapper.FromDtoComun(pedido);
                return _repositorioPedido.CalcularPrecio(elPedido);
            }
        }
    }
}
