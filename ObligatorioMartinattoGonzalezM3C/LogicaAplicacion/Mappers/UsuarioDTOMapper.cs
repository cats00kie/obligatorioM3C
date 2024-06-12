using Papeleria.LogicaAplicacion.DTOs;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Papeleria.LogicaNegocio.Entidades;
using Papeleria.LogicaNegocio.ValueObjects;
using static System.Runtime.InteropServices.JavaScript.JSType;
using LogicaNegocio.ValueObjects;

namespace Papeleria.LogicaAplicacion.Mappers
{
    public class UsuarioDTOMapper
    {
        public static UsuarioDTO FromAdmin(Administrador admin)
        {
            if (admin == null) return null;
            return new UsuarioDTO
            {
                Id = admin.Id,
                Nombre = admin.NombreCompleto.Nombre,
                Apellido = admin.NombreCompleto.Apellido,
                Email = admin.Email,
                Password = admin.Password,
                PasswordSinEncript = admin.PasswordSinEncript
            };
        }
        public static UsuarioDTO FromEncargado(Encargado enc)
        {
            if (enc == null) return null;
            return new UsuarioDTO
            {
                Id = enc.Id,
                Nombre = enc.NombreCompleto.Nombre,
                Apellido = enc.NombreCompleto.Apellido,
                Email = enc.Email,
                Password = enc.Password,
                PasswordSinEncript = enc.PasswordSinEncript
            };
        }

        public static Encargado FromDtoEnc(UsuarioDTO encdto)
        {
            if (encdto == null) return null;
            return new Encargado
            {
                Id = encdto.Id,
                NombreCompleto = new NombreCompleto(encdto.Nombre, encdto.Apellido),
                Email = encdto.Email,
                Password = encdto.Password,
                PasswordSinEncript = encdto.PasswordSinEncript
            };
        }
        public static Administrador FromDtoAdmin(UsuarioDTO admindto)
        {
            if (admindto == null) return null;
            return new Administrador
            {
                Id = admindto.Id,
                NombreCompleto = new NombreCompleto(admindto.Nombre, admindto.Apellido),
                Email = admindto.Email,
                Password = admindto.Password,
                PasswordSinEncript = admindto.PasswordSinEncript
            };
        }
    }
}
