using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.TMov;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.TMov
{
    public class CrearTMovCU : ICrearTMov
    {
        private IRepositorioTipoMovimiento _repositorioTipoMovimiento;
        public CrearTMovCU(IRepositorioTipoMovimiento repositorioTipoMovimiento)
        {
            this._repositorioTipoMovimiento = repositorioTipoMovimiento;
        }
        public void CrearTMov(TipoMovimientoDTO tMovDTO)
        {
            TipoMovimiento tipo = TipoMovimientoDTOMapper.FromDto(tMovDTO);
            this._repositorioTipoMovimiento.Add(tipo);
        }
    }
}
