using LogicaNegocio.Entidades;
using Papeleria.LogicaAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.Mappers
{
    public class LineaDTOMapper
    {
        public static LineaDTO toDTO(Linea linea)
        {
            return new LineaDTO(linea);
        }

        public static Linea FromDTO(LineaDTO linea)
        {
            return new Linea
            {
                Id = linea.Id,
                Precio = linea.Precio,
                CantUnidades = linea.CantUnidades,
                ArticuloId = linea.ArticuloId,
            };
        }
    }
}
