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

    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public string PasswordSinEncript {  get; set; }
        public bool? IsEncargado { get; set; }
    }
}
