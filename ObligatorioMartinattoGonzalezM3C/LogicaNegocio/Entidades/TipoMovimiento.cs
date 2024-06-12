using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.Entidades
{
    [Index(nameof(Nombre),IsUnique = true)]
    public class TipoMovimiento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public TipoMovStock TipoMovStock { get; set; }
    }
}
