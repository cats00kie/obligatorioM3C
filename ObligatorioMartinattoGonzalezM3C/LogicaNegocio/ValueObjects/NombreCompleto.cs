using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Excepciones;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    [Owned]
    public class NombreCompleto : IValid
    {
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public NombreCompleto() 
        {
            Nombre = "Sin Nombre";
            Apellido = "Sin Apellido";
        }
        public NombreCompleto(string nombre, string apellido) {
            this.Nombre = nombre;
            this.Apellido = apellido;
        }

        public void IsValid()
        {
            if (!Regex.IsMatch(Nombre, @"^[a-zA-Z][-a-zA-Z ']*(?<![ '-])$")) throw new NombreCompletoNoValidoException("Nombre no es valido");
            if (!Regex.IsMatch(Apellido, @"^[a-zA-Z][-a-zA-Z ']*(?<![ '-])$")) throw new NombreCompletoNoValidoException("Apellido no es valido");
        }
    }
}
