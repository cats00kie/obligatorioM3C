using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Movimiento;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.TMov;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Movimientos
{
    public class GetAllMovsCU : IGetAllMovs
    {
        private IRepositorioMovimiento _repositorioMovimiento;
        private IRepositorioConfig _repositorioConfig;
        public GetAllMovsCU(IRepositorioMovimiento repositorioMovimiento, IRepositorioConfig repositorioConfig)
        {
            this._repositorioMovimiento = repositorioMovimiento;
            this._repositorioConfig = repositorioConfig;
        }

        public IEnumerable<MovimientoDTO> GetAllMovs(int pag)
        {
            int size = this._repositorioConfig.FindByNombre("PageSize").Valor;
            return this._repositorioMovimiento.GetMovs(pag, size).Select(m => MovimientoDTOMapper.ToDto(m));
        }
    }
}
