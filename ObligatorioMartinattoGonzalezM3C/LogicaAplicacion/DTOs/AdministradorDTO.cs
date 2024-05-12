using LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTOs
{
    [Index(nameof(Email), IsUnique = true)]

    public class AdministradorDTO : UsuarioDTO
    {
        [Required(ErrorMessage = "Requerido.")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Requerido.")]
         [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[.;,!])[a-zA-Z\d.;,!]{6,}$",
         ErrorMessage = "La contraseña debe tener al menos una letra en minuscula, mayuscula, un numero, y uno de estos simbolos: . ; , ! ")]
         [StringLength(200, MinimumLength = 6, ErrorMessage = "La Contraseña debe ser de al menos 6 caracteres")]
        public string Password { get; set; }
        public string PasswordSinEncript {  get; set; }
        public AdministradorDTO() { }
        public AdministradorDTO(Administrador admin)
        {
            if (admin != null)
            {
                this.Id = admin.Id;
                this.Email = admin.Email;
                this.Password = admin.Password;
                this.PasswordSinEncript = admin.PasswordSinEncript;
                this.Nombre = admin.NombreCompleto.Nombre;
                this.Apellido = admin.NombreCompleto.Apellido;
            }
        }
    }
}
