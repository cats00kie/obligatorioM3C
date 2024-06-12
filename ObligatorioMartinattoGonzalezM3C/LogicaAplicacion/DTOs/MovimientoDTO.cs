using LogicaNegocio.Entidades;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTOs
{
    public class MovimientoDTO
    {
        public int Id { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public int ArticuloId { get; set; }
        public int TipoMovimientoId { get; set; }
        public UsuarioDTO Usuario { get; set; }
        public int CantUnidades { get; set; }

        public MovimientoDTO(Movimiento m)
        {
            Id = m.Id;
            FechaMovimiento = m.FechaMovimiento;
            ArticuloId = m.ArticuloId;
            TipoMovimientoId = m.TipoMovimientoId;
            Usuario = UsuarioDTOMapper.FromEncargado((Encargado)m.Usuario);
            CantUnidades = m.CantUnidades;
        }
    }
}
