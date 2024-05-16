using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Excepciones;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    [Index(nameof(Nombre), IsUnique = true)]
    public class Articulo : IValid
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
        public void IsValid()
        {
            if (Nombre == "" && Nombre.Length < 10 || Nombre.Length > 200) throw new ArticuloNoValidoException("Nombre del articulo invalido.");
            if (Codigo == "") throw new ArticuloNoValidoException("Codigo invalido.");
            if (Descripcion == "" && Descripcion.Length < 5) throw new ArticuloNoValidoException("Descripcion no valida");
            if (Precio <= 0) throw new ArticuloNoValidoException("Precio no valido");
            if (Stock <= 0) throw new ArticuloNoValidoException("Stock no valido.");
        }
    }
}
