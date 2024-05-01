using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTOs
{
    public class PedidoDTO
    {
        public static int UltimoId { get; set; }
        public int Id { get; set; }
        public Cliente ClienteObj { get; set; }
        public DateTime FechaPrometida { get; set; }
        public List<Linea> Lineas { get; set; }
        public Boolean Anulado { get; set; }
        public int ModificadorRecargo { get; set; }
        public double DistanciaKm { get; set; }
        public int ModificadorMismoDia { get; set; }
        public Configuracion ConfiguracionObj { get; set; } 
    }
}
