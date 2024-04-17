using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTOs
{
    public class AdministradorDTO : UsuarioDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public AdministradorDTO() { }
        public AdministradorDTO(Administrador admin)
        {
            if (admin != null)
            {
                this.Id = admin.Id;
                this.Email = admin.Email;
                this.Password = admin.Password;
                this.Nombre = admin.NombreCompleto.Nombre;
                this.Apellido = admin.NombreCompleto.Apellido;
            }
        }
    }
}
