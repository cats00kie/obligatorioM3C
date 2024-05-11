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
                ClienteId = pedido.ClienteId,
                FechaPrometida = pedido.FechaPrometida,
                Lineas = pedido.Lineas.Select(linea => LineaDTOMapper.toDTO(linea)).ToList(),
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
                ClienteId = pedido.ClienteId,
                FechaPrometida = pedido.FechaPrometida,
                Lineas = pedido.Lineas.Select(linea => LineaDTOMapper.toDTO(linea)).ToList(),
                Anulado = pedido.Anulado,
                ModificadorRecargo = pedido.ModificadorRecargo,
                ModificadorMismoDia = pedido.ModificadorMismoDia
            };
        }
        public static PedidoComun FromDtoComun(PedidoDTO pedido)
        {
            if (pedido != null)
            {
                return new PedidoComun
                {
                    Id = pedido.Id,
                    ClienteId = pedido.ClienteId,
                    FechaPrometida = pedido.FechaPrometida,
                    Lineas = pedido.Lineas.Select(linea => LineaDTOMapper.FromDTO(linea)).ToList(),
                    Anulado = pedido.Anulado,
                    ModificadorRecargo = pedido.ModificadorRecargo,
                    DistanciaKm = pedido.DistanciaKm

                };
            }
            else throw new NotImplementedException();
        }
        public static PedidoExpress FromDtoExpress(PedidoDTO pedido)
        {
            if (pedido != null)
            {
                return new PedidoExpress
                {
                    Id = pedido.Id,
                    ClienteId = pedido.ClienteId,
                    FechaPrometida = pedido.FechaPrometida,
                    Lineas = pedido.Lineas.Select(linea => LineaDTOMapper.FromDTO(linea)).ToList(),
                    Anulado = pedido.Anulado,
                    ModificadorRecargo = pedido.ModificadorRecargo,
                    ModificadorMismoDia = pedido.ModificadorMismoDia
                };
            }
            else throw new NotImplementedException();
        }
    }
}
