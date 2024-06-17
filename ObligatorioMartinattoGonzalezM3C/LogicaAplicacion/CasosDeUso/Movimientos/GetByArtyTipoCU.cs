using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Movimiento;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.InterfacesRepositorio;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Movimientos
{
    public class GetByArtyTipoCU : IGetByArtyTipo
    {
        private IRepositorioMovimiento _repositorioMovimiento;
        private IRepositorioConfig _repositorioConfig;
        public GetByArtyTipoCU(IRepositorioMovimiento repositorioMovimiento, IRepositorioConfig repositorioConfig)
        {
            this._repositorioMovimiento = repositorioMovimiento;
            this._repositorioConfig = repositorioConfig;
        }
        public IEnumerable<MovimientoDTO> GetByArtyTipo(int articuloId, int tipoId, int pag)
        {
            int size = this._repositorioConfig.FindByNombre("PageSize").Valor;
            return this._repositorioMovimiento.GetByArtyTipo(articuloId, tipoId, pag, size).Select(m => MovimientoDTOMapper.ToDto(m));
        }
    }
}
