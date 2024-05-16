using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public abstract class Pedido
    {
        public static int UltimoId { get; set; }
        public int Id { get; set; }
        [ForeignKey(nameof(Cliente))] public int ClienteId { get; set; }
        public Cliente ClienteObj { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaPrometida { get; set; }
        public List<Linea> Lineas { get; set; }
        public Boolean Anulado { get; set; }
        public Pedido() { }

        public abstract double CalcularPrecio(double impuesto, int modificadorRecargo, int modificadorRecargoExp, int modificadorMismoDia);
        public abstract void IsValid(int fechaPrometida);
    }
}
