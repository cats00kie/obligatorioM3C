using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class PedidoComun : Pedido 
    {
        public int ModificadorRecargo { get; set; }
        public double DistanciaKm { get; set; }
        public PedidoComun(){}

        public PedidoComun(int id, Cliente obj, DateTime fechaPrometida, int modificadorRecargo, double distanciaKm, Configuracion configuracion)
        {
            Id = id;
            ClienteObj = obj;
            FechaPrometida = fechaPrometida;
            Lineas = new List<Linea>();
            Anulado = false;
            ConfiguracionObj = configuracion;
            ModificadorRecargo = modificadorRecargo;
            DistanciaKm = distanciaKm;
        }
        public PedidoComun(Cliente obj, DateTime fechaPrometida, int modificadorRecargo, double distanciaKm,Configuracion configuracion)
        {
            ClienteObj = obj;
            FechaPrometida = fechaPrometida;
            Lineas = new List<Linea>();
            Anulado = false;
            ConfiguracionObj = configuracion;
            ModificadorRecargo = modificadorRecargo;
            DistanciaKm = distanciaKm;
        }

    }
}
