using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Excepciones;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.ValueObjects
{
    [Owned]
    public class NombreCliente : IValid
    {
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public NombreCliente() { }
        public NombreCliente(string nombre, string apellido)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
        }
        public void IsValid()
        {
            if (!Regex.IsMatch(Nombre, @"^[a-zA-Z][-a-zA-Z ']*(?<![ '-])$")) throw new NombreClienteNoValidoException("Nombre no es valido");
            if (!Regex.IsMatch(Apellido, @"^[a-zA-Z][-a-zA-Z ']*(?<![ '-])$")) throw new NombreClienteNoValidoException("Apellido no es valido");
        }
    }
}
