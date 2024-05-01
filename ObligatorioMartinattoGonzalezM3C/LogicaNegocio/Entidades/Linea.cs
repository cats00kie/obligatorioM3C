using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Linea
    {
        public int Id { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
        public Articulo ArticuloObj { get; set; }

        public Linea() { }
        public Linea(int id, double precio, int stock, Articulo articuloObj)
        {
            Id = id;
            Precio = precio;
            Stock = stock;
            ArticuloObj = articuloObj;
        }
        public Linea(double precio, int stock, Articulo articuloObj)
        {
            Precio = precio;
            Stock = stock;
            ArticuloObj = articuloObj;
        }
    }
}
