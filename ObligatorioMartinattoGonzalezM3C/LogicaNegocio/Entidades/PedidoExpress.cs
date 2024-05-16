using Papeleria.LogicaNegocio.Excepciones;
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
        public override double CalcularPrecio(double impuesto, int modificadorRecargo, int modificadorRecargoExp, int modificadorMismoDia)
        {
            {
                double suma = 0;
                foreach (Linea linea in Lineas)
                {
                    suma += linea.Precio;
                }
                if (FechaPrometida.Day == DateTime.Today.Day) suma += suma * modificadorMismoDia / 100;
                else suma += suma * modificadorRecargoExp / 100;
                suma += suma * impuesto / 100;
                return suma;
            }
        }
        public override void IsValid(int fechaPrometida)
        {
            if (this.FechaPrometida.Day - DateTime.Today.Day > fechaPrometida) throw new PedidoNoValidoException("Fecha no valida.");
            if (this.FechaPrometida < DateTime.Today) throw new PedidoNoValidoException("Fecha no valida.");
            if (Lineas.Count == 0) throw new PedidoNoValidoException("Debe tener al menos una linea.");
        }
    }
}
