using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.TMov;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.Excepciones;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.TMov
{
    public class UpdateTMovCU : IUpdateTMov
    {
        private IRepositorioTipoMovimiento _repositorioTipoMovimiento;
        public UpdateTMovCU(IRepositorioTipoMovimiento repositorioTipoMovimiento)
        {
            this._repositorioTipoMovimiento = repositorioTipoMovimiento;
        }
        public void UpdateTMov(TipoMovimientoDTO tipoMovimiento)
        {
            try
            {
                this._repositorioTipoMovimiento.Update(TipoMovimientoDTOMapper.FromDto(tipoMovimiento));
            }
            catch (TMovException){ throw; }
            catch (Exception ex) { throw; }
        }
    }
}
