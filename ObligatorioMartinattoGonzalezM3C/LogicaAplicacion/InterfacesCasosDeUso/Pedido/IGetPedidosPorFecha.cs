using Papeleria.LogicaAplicacion.DTOs;

namespace Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Pedido
{
    public interface IGetPedidosPorFecha
    {
        IEnumerable<PedidoDTO> GetPedidosPorFecha(DateTime fecha);
    }
}