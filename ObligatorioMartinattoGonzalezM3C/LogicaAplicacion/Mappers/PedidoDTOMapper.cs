using LogicaNegocio.Entidades;
using Papeleria.LogicaAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.Mappers
{
    public class PedidoDTOMapper
    {
        public static PedidoDTO FromComun(PedidoComun pedido)
        {
            if (pedido == null) return null;
            return new PedidoDTO
            {
                Id = pedido.Id,
                ClienteObj = pedido.ClienteObj,
                FechaPrometida = pedido.FechaPrometida,
                Lineas = pedido.Lineas,
                Anulado = pedido.Anulado,
                ModificadorRecargo = pedido.ModificadorRecargo,
                DistanciaKm = pedido.DistanciaKm
            };
        }
        public static PedidoDTO FromExpress(PedidoExpress pedido)
        {
            if (pedido == null) return null;
            return new PedidoDTO
            {
                Id = pedido.Id,
                ClienteObj = pedido.ClienteObj,
                FechaPrometida = pedido.FechaPrometida,
                Lineas = pedido.Lineas,
                Anulado = pedido.Anulado,
                ModificadorRecargo = pedido.ModificadorRecargo,
                DistanciaKm = pedido.ModificadorMismoDia
            };
        }
        public static PedidoComun FromDtoComun(PedidoDTO pedido)
        {
            if (pedido != null)
            {
                return new PedidoComun(pedido.Id, pedido.ClienteObj, pedido.FechaPrometida,
                    pedido.ModificadorRecargo, pedido.DistanciaKm, pedido.ConfiguracionObj);
            }
            else throw new NotImplementedException();
        }
        public static PedidoExpress FromDtoExpress(PedidoDTO pedido)
        {
            if (pedido != null)
            {
                return new PedidoExpress(pedido.Id, pedido.ClienteObj, pedido.FechaPrometida,
                    pedido.ModificadorRecargo, pedido.ModificadorMismoDia);
            }
            else throw new NotImplementedException();
        }
    }
}
