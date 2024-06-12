using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.Mappers
{
    public class TipoMovimientoDTOMapper
    {
        public static TipoMovimiento FromDto(TipoMovimientoDTO tipoMovimientoDTO)
        {
            return new TipoMovimiento
            {
                Id = tipoMovimientoDTO.Id,
                Nombre = tipoMovimientoDTO.Nombre,
                TipoMovStock = tipoMovimientoDTO.Tipo
            };
        }

        public static TipoMovimientoDTO ToDto(TipoMovimiento tipoMovimiento)
        {
            if (tipoMovimiento == null) return null;
            return new TipoMovimientoDTO
            {
                Id = tipoMovimiento.Id,
                Nombre = tipoMovimiento.Nombre,
                Tipo = tipoMovimiento.TipoMovStock
            };
        }
    }
}
