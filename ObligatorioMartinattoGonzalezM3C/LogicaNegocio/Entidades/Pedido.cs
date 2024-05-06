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

        //TO-DO: Cambiar el tema de configuracion para que en vez de ser un objeto sea
        //un dbset con su propio nombre y valor. acá lo que va a cambiar es:
        //se borra el objeto y se trae el impuesto

        public double CalcularPrecio(double impuesto)
        {
            double suma = 0;
            foreach(Linea linea in Lineas)
            {
                suma += linea.Precio;
            }
            suma += suma * impuesto / 100;
            return suma;
        }

    }
}
