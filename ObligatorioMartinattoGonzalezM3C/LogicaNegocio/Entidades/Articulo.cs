using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Articulo
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; }
        public string Nombre { get; set; } 
        public string Codigo {  get; set; }
        public string Descripcion { get; set;}
        public double Precio { get; set; }
        public int Stock { get; set; }
        public Articulo() { }
        public Articulo(int id, string nombre, string codigo, string descripcion, double precio, int stock)
        {
            Id = id;
            Nombre = nombre;
            Codigo = codigo;
            Descripcion = descripcion;
            Precio = precio;
            Stock = stock;
        }
        public Articulo( string nombre, string codigo, string descripcion, double precio, int stock)
        {
            Nombre = nombre;
            Codigo = codigo;
            Descripcion = descripcion;
            Precio = precio;
            Stock = stock;
        }
    }
}
