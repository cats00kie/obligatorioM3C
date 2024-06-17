using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Movimiento;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Movimientos
{
    public class GetMovsXFechaCU : IGetMovsXFecha
    {
        private IRepositorioMovimiento _repositorioMovimiento;
        public GetMovsXFechaCU(IRepositorioMovimiento repositorioMovimiento)
        {
            this._repositorioMovimiento = repositorioMovimiento;
        }

        public IEnumerable<FechaDTO> GetMovsXFecha()
        {
            IEnumerable<MovimientoDTO> movs = this._repositorioMovimiento.FindAll().Select(m => MovimientoDTOMapper.ToDto(m));
            return movs.GroupBy(m => m.FechaMovimiento).Select(movsPorFecha => new FechaDTO
            {
                Fecha = movsPorFecha.Key,
                Total = movsPorFecha.Sum(m => m.CantUnidades),
                Movs = movsPorFecha.GroupBy(tmov => tmov.TipoMov.Nombre)
                .Select(tm => new TMovsDTO
                {
                    Nombre = tm.Key,
                    Total = tm.Sum(m => m.CantUnidades)
                }).ToList()
            });
        }
    }
}
