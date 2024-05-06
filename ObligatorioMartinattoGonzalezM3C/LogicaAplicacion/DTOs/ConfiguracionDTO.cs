using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTOs
{
    public class ConfiguracionDTO
    {
        public int Id {  get; set; }
        public string Nombre { get; set; }
        public int Valor { get; set; }
        public ConfiguracionDTO(Configuracion config)
        {
            Id = config.Id;
            Nombre = config.Nombre;
            Valor = config.Valor;
        }
    }
}
