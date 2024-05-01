using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Configuracion
    {
        public int Id { get; set; }
        public int Iva { get; set; }
        public int PlazoExpress { get; set; }
        public Configuracion() { }
        public Configuracion(int id,  int iva)
        {
            Id = id;
            Iva = iva;
        }
        public Configuracion(int iva)
        {
            Iva = iva;
        }
    }
}
