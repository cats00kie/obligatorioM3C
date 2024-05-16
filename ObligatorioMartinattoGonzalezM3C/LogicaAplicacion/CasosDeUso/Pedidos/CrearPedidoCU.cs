using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Pedido;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.Excepciones;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Pedidos
{
    public class CrearPedidoCU : ICrearPedido
    {
        private IRepositorioPedido _repositorioPedido;
        private IRepositorioConfig _repositorioConfig;
        public CrearPedidoCU(IRepositorioPedido repositorioPedido, IRepositorioConfig repositorioConfig)
        {
            _repositorioPedido = repositorioPedido;
            _repositorioConfig = repositorioConfig;
        }

        public void CrearPedido(PedidoDTO pedido, Boolean esExpress)
        {
            if (esExpress)
            {
                try
                {
                    Pedido elPedido = PedidoDTOMapper.FromDtoExpress(pedido);
                    elPedido.Fecha = DateTime.Today;
                    elPedido.IsValid(this._repositorioConfig.FindByNombre("PlazoEstipulado").Valor);
                    this._repositorioPedido.Add(elPedido);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                try
                {
                    Pedido elPedido = PedidoDTOMapper.FromDtoComun(pedido);
                    elPedido.Fecha = DateTime.Today;
                    elPedido.IsValid(this._repositorioConfig.FindByNombre("PlazoEstipuladoCom").Valor);
                    this._repositorioPedido.Add(elPedido);
                }
                catch (Exception ex) 
                {
                    throw ex;
                }
            }
        }
    }
}
