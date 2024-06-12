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
                Usuario = UsuarioDTOMapper.FromDtoEnc(movimientoDTO.Usuario),
                CantUnidades = movimientoDTO.CantUnidades
            };
        }

        public static MovimientoDTO ToDto(Movimiento movimiento)
        {
            return new MovimientoDTO(movimiento);
        }
    }
}
