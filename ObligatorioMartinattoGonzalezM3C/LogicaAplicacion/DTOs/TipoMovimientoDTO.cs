using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTOs
{
    public class TipoMovimientoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public TipoMovStock Tipo { get; set; }

    }
}
