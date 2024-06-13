using Papeleria.LogicaAplicacion.DTOs;

namespace Papeleria.LogicaAplicacion.InterfacesCasosDeUso.TMov
{
    public interface IFindTMovById
    {
        TipoMovimientoDTO FindById(int id);
    }
}