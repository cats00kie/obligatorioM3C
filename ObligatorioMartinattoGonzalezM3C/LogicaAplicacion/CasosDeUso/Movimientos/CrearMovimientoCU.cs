using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Movimiento;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Movimientos
{
    public class CrearMovimientoCU : ICrearMovimiento
    {
        private IRepositorioMovimiento _repositorioMovimiento;
        public CrearMovimientoCU(IRepositorioMovimiento repositorioMovimiento)
        {
            this._repositorioMovimiento = repositorioMovimiento;
        }
        public void CrearMovimiento(MovimientoDTO MovDTO)
        {
            Movimiento mov = MovimientoDTOMapper.FromDto(MovDTO);
            this._repositorioMovimiento.Add(mov);
        }
    }
}
