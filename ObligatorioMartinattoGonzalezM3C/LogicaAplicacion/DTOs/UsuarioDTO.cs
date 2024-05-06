using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTOs
{
    public abstract class UsuarioDTO
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; }
        [Required(ErrorMessage = "Requerido.")]
        [RegularExpression(@"^[a-zA-Z][-a-zA-Z ']*(?<![ '-])$", ErrorMessage = "El nombre o apellido es inválido.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Requerido.")]
        [RegularExpression(@"^[a-zA-Z][-a-zA-Z ']*(?<![ '-])$", ErrorMessage = "El nombre o apellido es inválido.")]

        public string Apellido { get; set; }
        public UsuarioDTO(){}
        public UsuarioDTO(Usuario usuario)
        {
            if (usuario != null)
            {
                this.Id = usuario.Id;
                this.Nombre = usuario.NombreCompleto.Nombre;
                this.Apellido = usuario.NombreCompleto.Apellido;
            }
        }
    }
}
