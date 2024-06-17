using Papeleria.LogicaAplicacion.DTOs;

namespace Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Movimiento
{
    public interface IGetByArtyTipo
    {
        IEnumerable<MovimientoDTO> GetByArtyTipo(int articuloId, int tipoId, int pag);
    }
}