using Papeleria.LogicaAplicacion.DTOs;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.Mappers
{
    public class AdministradorDTOMapper
    {
        public static AdministradorDTO ToDto(Administrador admin)
        {
            return new AdministradorDTO(admin);
        }

        public static Administrador FromDto(AdministradorDTO admindto)
        {
            if(admindto == null)
            {
                throw new NotImplementedException();
            }
            return new Administrador(admindto.Nombre, admindto.Apellido, admindto.Email, admindto.Password);
        }
    }
}
