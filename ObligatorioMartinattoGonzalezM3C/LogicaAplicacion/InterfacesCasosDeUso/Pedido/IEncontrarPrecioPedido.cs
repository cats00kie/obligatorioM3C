using Papeleria.LogicaAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Pedido
{
    public interface IEncontrarPrecioPedido
    {
        public double EncontrarPrecioPedido(PedidoDTO pedido, Boolean esExpress);
    }
}
