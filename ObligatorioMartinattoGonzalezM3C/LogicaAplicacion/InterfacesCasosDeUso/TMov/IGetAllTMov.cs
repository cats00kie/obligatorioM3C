using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.InterfacesCasosDeUso.TMov
{
    public interface IGetAllTMov
    {
        public IEnumerable<TipoMovimientoDTO> GetAllTMov();
    }
}
