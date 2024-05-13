using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Pedido;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
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
        private IRepositorioCliente _repositorioCliente;
        public EncontrarPrecioPedidoCU(IRepositorioPedido repositorioPedido, IRepositorioCliente repositorioCliente)
        {
            this._repositorioPedido = repositorioPedido;
            this._repositorioCliente = repositorioCliente;
        }
        public double EncontrarPrecioPedido(PedidoDTO pedido, Boolean esExpress)
        {
            if (pedido == null) return 0;
            if (esExpress)
            {
                PedidoExpress elPedido = PedidoDTOMapper.FromDtoExpress(pedido); 
                elPedido.ClienteObj = _repositorioCliente.FindByID(elPedido.ClienteId);
                return _repositorioPedido.CalcularPrecio(elPedido);
            }
            else
            {
                PedidoComun elPedido = PedidoDTOMapper.FromDtoComun(pedido);
                elPedido.ClienteObj = _repositorioCliente.FindByID(elPedido.ClienteId);
                return _repositorioPedido.CalcularPrecio(elPedido);
            }
        }
    }
}
