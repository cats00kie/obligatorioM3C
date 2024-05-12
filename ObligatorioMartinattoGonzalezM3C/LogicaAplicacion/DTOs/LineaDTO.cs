using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTOs
{
    public class LineaDTO
    {
        public int Id { get; set; }
        public double Precio { get; set; }
        public int CantUnidades { get; set; }
        public int ArticuloId { get; set; }
    }
}
