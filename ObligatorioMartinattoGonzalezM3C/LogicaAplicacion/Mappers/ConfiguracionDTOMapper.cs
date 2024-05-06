using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Entidades;
using Papeleria.LogicaAplicacion.DTOs;

namespace Papeleria.LogicaAplicacion.Mappers
{
    public class ConfiguracionDTOMapper
    {
        public ConfiguracionDTO ToDto(Configuracion config)
        {
            return new ConfiguracionDTO(config);
        }
    }
}
