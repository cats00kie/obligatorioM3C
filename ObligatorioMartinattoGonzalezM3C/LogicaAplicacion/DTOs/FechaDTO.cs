using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTOs
{
    public class FechaDTO
    {
        public int Fecha { get; set; }
        public List<TMovsDTO> Movs { get; set; }
        public int Total { get; set; }  
    }
}
