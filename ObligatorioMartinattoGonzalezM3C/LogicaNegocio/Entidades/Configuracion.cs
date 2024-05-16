using Papeleria.LogicaNegocio.InterfacesEntidades;
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
        public string Nombre { get; set; }
        public int Valor { get; set; }
        public Configuracion() { }
        public Configuracion(int id,  string nombre, int valor)
        {
            Id = id;
            Nombre = nombre;
            Valor = valor;
        }
        public Configuracion(string nombre, int valor)
        {
            Nombre = nombre;
            Valor = valor;
        }
    }
}
