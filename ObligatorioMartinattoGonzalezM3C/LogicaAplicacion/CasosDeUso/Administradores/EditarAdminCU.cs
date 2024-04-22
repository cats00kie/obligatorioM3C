using LogicaNegocio.InterfacesRepositorio;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Administrador;
using Papeleria.LogicaAplicacion.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Administradores
{
    public class EditarAdminCU : IEditarAdmin
    {
        private IRepositorioAdministrador _repositorioAdmin;
        public EditarAdminCU(IRepositorioAdministrador repositorioAdmin)
        {
            _repositorioAdmin = repositorioAdmin;
        }
        public bool EditarAdmin(AdministradorDTO aModificar)
        {
            return this._repositorioAdmin.Update(AdministradorDTOMapper.FromDto(aModificar));
        }
    }
}
