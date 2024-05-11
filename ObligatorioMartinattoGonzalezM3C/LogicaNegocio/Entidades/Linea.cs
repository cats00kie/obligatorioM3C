using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Linea
    {
        public int Id { get; set; }
        public double Precio { get; set; }
        public int CantUnidades { get; set; }
        [ForeignKey(nameof(Articulo))] public int ArticuloId { get; set; }
        public Articulo ArticuloObj { get; set; }

        public Linea() { }
        public Linea(int id, double precio, int stock, Articulo articuloObj, int cantUnidades)
        {
            Id = id;
            Precio = precio;
            CantUnidades = cantUnidades;
            ArticuloObj = articuloObj;
        }
        public Linea(double precio, int stock, Articulo articuloObj, int cantUnidades)
        {
            Precio = precio;
            CantUnidades = cantUnidades;
            ArticuloObj = articuloObj;
        }
    }
}
