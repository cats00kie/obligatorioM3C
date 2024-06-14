using LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.Excepciones;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    public class Movimiento : IValid
    {
        public int Id { get; set; }
        public DateTime FechaMovimiento { get; set; }  
        [ForeignKey(nameof(Articulo))] public int ArticuloId { get; set; }
        public Articulo Articulo { get; set; }
        [ForeignKey(nameof(TipoMovimiento))] public int TipoMovimientoId { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }
        public string EmailUsuario {  get; set; }
        public int CantUnidades { get; set; }

        public void IsValid()
        {
            if (CantUnidades < 1) throw new MovimientoException("Cantidad invalida");
            //TODO : AGREGAR CONFIG DEL TOPE PARA LOS MOVIMIENTOS
        }
    }
}
