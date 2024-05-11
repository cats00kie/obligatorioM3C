using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTOs
{
    public class PedidoDTO
    {
        public static int UltimoId { get; set; }
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaPrometida { get; set; }
        public List<LineaDTO> Lineas { get; set; }
        public Boolean Anulado { get; set; }
        public int ModificadorRecargo { get; set; }
        public double DistanciaKm { get; set; }
        public int ModificadorMismoDia { get; set; }
        public Configuracion ConfiguracionObj { get; set; } 
    }
}
