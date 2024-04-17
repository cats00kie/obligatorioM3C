using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTOs
{
    public abstract class UsuarioDTO
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; }
        public string Nombre { get; set; }

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
