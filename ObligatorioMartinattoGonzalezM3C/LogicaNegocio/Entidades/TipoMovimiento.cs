using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Excepciones;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    [Index(nameof(Nombre),IsUnique = true)]
    public class TipoMovimiento : IValid
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public TipoMovStock TipoMovStock { get; set; }

        public void IsValid()
        {
            if (Nombre == null) throw new TMovException("Error en el nombre");
        }
    }
}
