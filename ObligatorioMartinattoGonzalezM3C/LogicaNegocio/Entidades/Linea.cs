using Papeleria.LogicaNegocio.Excepciones;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Linea : IValid
    {
        public int Id { get; set; }
        public double Precio { get; set; }
        public int CantUnidades { get; set; }
        [ForeignKey(nameof(Articulo))] public int ArticuloId { get; set; }
        public Articulo ArticuloObj { get; set; }

        public Linea() { }
        public Linea(int id, int stock, Articulo articuloObj, int cantUnidades)
        {
            Id = id;
            CantUnidades = cantUnidades;
            ArticuloObj = articuloObj;
            Precio = articuloObj.Precio * cantUnidades;
        }
        public Linea(double precio, int stock, Articulo articuloObj, int cantUnidades)
        {
            Precio = precio;
            CantUnidades = cantUnidades;
            ArticuloObj = articuloObj;
        }

        public void IsValid()
        {
            if (CantUnidades > ArticuloObj.Stock) throw new LineaNoValidaException("Cantidad de unidades supera el stock.");
            if (ArticuloObj == null) throw new LineaNoValidaException("Articulo no es valido.");
        }
    }
}
