using LogicaNegocio.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Excepciones;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    [Index(nameof(Email), IsUnique = true)]

    public abstract class Usuario : IValid
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Requerido.")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Requerido.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[.;,!])[a-zA-Z\d.;,!]{6,}$",
        ErrorMessage = "La contraseña debe tener al menos una letra en minuscula, mayuscula, un numero, y uno de estos simbolos: . ; , ! ")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "La Contraseña debe ser de al menos 6 caracteres")]
        public string Password { get; set; }
        public static int UltimoId { get; set; }
        [Required(ErrorMessage = "Requerido.")]
        [RegularExpression(@"^[a-zA-Z][-a-zA-Z ']*(?<![ '-])$", ErrorMessage = "El nombre o apellido es inválido.")]
        public NombreCompleto NombreCompleto { get; set; }

        public void IsValid()
        {
            if (this != null)
            {
                if (Email == null) throw new AdministradorNoValidoException("Email requerido.");
                if (Password == null) throw new AdministradorNoValidoException("Password requerido.");
                if (NombreCompleto.Nombre == null) throw new AdministradorNoValidoException("Nombre requerido.");
                if (NombreCompleto.Apellido == null) throw new AdministradorNoValidoException("Apellido requerido.");
                if (!Regex.IsMatch(Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[.;,!])[a-zA-Z\d.;,!]{6,}$"))
                {
                    throw new AdministradorNoValidoException("La contraseña debe tener al menos una letra en minuscula, mayuscula, un numero, y uno de estos simbolos: . ; , ! ");
                }
                if (!Regex.IsMatch(NombreCompleto.Nombre, @"^[a-zA-Z][-a-zA-Z ']*(?<![ '-])$")) throw new AdministradorNoValidoException("Nombre no es valido");
                if (!Regex.IsMatch(NombreCompleto.Apellido, @"^[a-zA-Z][-a-zA-Z ']*(?<![ '-])$")) throw new AdministradorNoValidoException("Apellido no es valido");
            }
            else throw new AdministradorNoValidoException("Admin no valido");
        }
    }
}
