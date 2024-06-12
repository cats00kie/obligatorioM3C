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
        public Articulo() { }
        public Articulo(int id, string nombre, string codigo, string descripcion, double precio)
        {
            Id = id;
            Nombre = nombre;
            Codigo = codigo;
            Descripcion = descripcion;
            Precio = precio;
        }
        public Articulo( string nombre, string codigo, string descripcion, double precio)
        {
            Nombre = nombre;
            Codigo = codigo;
            Descripcion = descripcion;
            Precio = precio;
        }
        public void IsValid()
        {
            if (Nombre == "" && Nombre.Length < 10 || Nombre.Length > 200) throw new ArticuloNoValidoException("Nombre del articulo invalido.");
            if (Codigo == "") throw new ArticuloNoValidoException("Codigo invalido.");
            if (Descripcion == "" && Descripcion.Length < 5) throw new ArticuloNoValidoException("Descripcion no valida");
            if (Precio <= 0) throw new ArticuloNoValidoException("Precio no valido");
        }
    }
}
