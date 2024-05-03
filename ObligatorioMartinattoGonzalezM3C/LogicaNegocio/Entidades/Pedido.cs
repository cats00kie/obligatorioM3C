using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public abstract class Pedido
    {
        public static int UltimoId { get; set; }
        public int Id { get; set; }
        public Cliente ClienteObj { get; set; }
        public DateTime FechaPrometida { get; set; }
        public List<Linea> Lineas { get; set; }
        public Boolean Anulado { get; set; }
        public Configuracion ConfiguracionObj { get; set; }
        public Pedido() { }

        public double CalcularPrecio()
        {
            double suma = 0;
            foreach(Linea linea in Lineas)
            {
                suma += linea.Precio;
            }
            suma += suma * ConfiguracionObj.Iva / 100;
            return suma;
        }

    }
}
