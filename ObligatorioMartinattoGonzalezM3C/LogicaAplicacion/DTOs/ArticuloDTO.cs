using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTOs
{
    public class ArticuloDTO
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Stock {  get; set; }
        public ArticuloDTO() { }
        public ArticuloDTO(Articulo articulo)
        {
            if(articulo != null)
            {
                Id = articulo.Id;
                Descripcion = articulo.Descripcion;
                Precio = articulo.Precio;
                Codigo = articulo.Codigo;
                Nombre = articulo.Nombre;
            }
        }
    }
}
