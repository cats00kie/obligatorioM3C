using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class PedidoComun : Pedido 
    {
        public static int ModificadorRecargo { get; set; }
        public PedidoComun(){}
        public PedidoComun(int id, Cliente obj, DateTime fechaPrometida)
        {
            Id = id;
            ClienteObj = obj;
            FechaPrometida = fechaPrometida;
            Lineas = new List<Linea>();
            Anulado = false;

        }
        public PedidoComun(Cliente obj, DateTime fechaPrometida)
        {
            ClienteObj = obj;
            FechaPrometida = fechaPrometida;
            Lineas = new List<Linea>();
            Anulado = false;

        }
        public override double CalcularPrecio(double impuesto)
        {
            {
                ModificadorRecargo = 5;
                double suma = 0;
                foreach (Linea linea in Lineas)
                {
                    suma += linea.Precio;
                }
                if (ClienteObj.Direccion.DistanciaKm > 100) suma += suma * ModificadorRecargo / 100;
                suma += suma * impuesto / 100;
                return suma;
            }
        }

    }
}
