using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.TMov;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.TMov
{
    public class FindTMovByIdCU : IFindTMovById
    {
        private IRepositorioTipoMovimiento _repositorioTipoMovimiento;
        public FindTMovByIdCU(IRepositorioTipoMovimiento repositorioTipoMovimiento)
        {
            this._repositorioTipoMovimiento = repositorioTipoMovimiento;
        }

        public TipoMovimientoDTO FindById(int id)
        {
            return TipoMovimientoDTOMapper.ToDto(_repositorioTipoMovimiento.FindByID(id));
        }
    }
}
