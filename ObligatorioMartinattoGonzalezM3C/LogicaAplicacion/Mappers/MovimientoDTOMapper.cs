using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.Mappers
{
    public class MovimientoDTOMapper
    {
        public static Movimiento FromDto(MovimientoDTO movimientoDTO)
        {
            return new Movimiento
            {
                Id = movimientoDTO.Id,
                FechaMovimiento = movimientoDTO.FechaMovimiento,
                ArticuloId = movimientoDTO.ArticuloId,
                TipoMovimientoId = movimientoDTO.TipoMovimientoId,
                EmailUsuario = movimientoDTO.EmailUsuario,
                CantUnidades = movimientoDTO.CantUnidades
            };
        }

        public static MovimientoDTO ToDto(Movimiento m)
        {
            return new MovimientoDTO 
            {
                Id = m.Id,
                FechaMovimiento = m.FechaMovimiento,
                ArticuloId = m.ArticuloId,
                TipoMovimientoId = m.TipoMovimientoId,
                EmailUsuario = m.EmailUsuario,
                CantUnidades = m.CantUnidades
            };
        }
    }
}
