using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class PedidoExpress : Pedido
    {
        public static int ModificadorRecargo { get; set; }
        public static int ModificadorMismoDia { get; set; }
        public PedidoExpress() { }

        public PedidoExpress(int id, Cliente obj, DateTime fechaPrometida)
        {
            Id = id;
            ClienteObj = obj;
            FechaPrometida = fechaPrometida;
            Lineas = new List<Linea>();
            Anulado = false;
        }
        public PedidoExpress(Cliente obj, DateTime fechaPrometida)
        {
            ClienteObj = obj;
            FechaPrometida = fechaPrometida;
            Lineas = new List<Linea>();
            Anulado = false;

        }
        public override double CalcularPrecio(double impuesto)
        {
            {
                ModificadorRecargo = 10;
                ModificadorMismoDia = 15;
                double suma = 0;
                foreach (Linea linea in Lineas)
                {
                    suma += linea.Precio;
                }
                if (FechaPrometida == DateTime.Today) suma += suma * ModificadorMismoDia / 100;
                else suma += suma * ModificadorRecargo / 100;
                suma += suma * impuesto / 100;
                return suma;
            }
        }

    }
}
