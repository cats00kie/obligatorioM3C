
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.TMov;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogic.UseCases.TeamsUCs
{
    public class GetAllTMovCU : IGetAllTMov
    {
        private IRepositorioTipoMovimiento _repositorioTipoMovimiento;
        public GetAllTMovCU(IRepositorioTipoMovimiento repositorioTipoMovimiento)
        {
            this._repositorioTipoMovimiento = repositorioTipoMovimiento;
        }
        public IEnumerable<TipoMovimientoDTO> GetAllTMov()
        {
            return this._repositorioTipoMovimiento.FindAll().Select(tipo => TipoMovimientoDTOMapper.ToDto(tipo));
        }
    }
}
