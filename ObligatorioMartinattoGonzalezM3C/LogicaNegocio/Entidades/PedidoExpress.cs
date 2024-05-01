using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class PedidoExpress : Pedido
    {
        public int ModificadorRecargo { get; set; }
        public int ModificadorMismoDia { get; set; }
        public PedidoExpress() { }

        public PedidoExpress(int id, Cliente obj, DateTime fechaPrometida, int modificadorRecargo, int modificadorMismoDia)
        {
            Id = id;
            ClienteObj = obj;
            FechaPrometida = fechaPrometida;
            Lineas = new List<Linea>();
            Anulado = false;
            ModificadorRecargo = modificadorRecargo;
            ModificadorMismoDia = modificadorMismoDia;
            
        }
        public PedidoExpress(Cliente obj, DateTime fechaPrometida, int modificadorRecargo, int modificadorMismoDia)
        {
            ClienteObj = obj;
            FechaPrometida = fechaPrometida;
            Lineas = new List<Linea>();
            Anulado = false;
            ModificadorRecargo = modificadorRecargo;
            ModificadorMismoDia = modificadorMismoDia;
        }
    }
}
