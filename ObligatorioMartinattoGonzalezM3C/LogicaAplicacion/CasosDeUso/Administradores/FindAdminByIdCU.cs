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
    public class FindAdminByIdCU : IFindAdminById
    {
        private IRepositorioAdministrador _repositorioAdmin;
        public FindAdminByIdCU(IRepositorioAdministrador repositorioAdmin)
        {
            _repositorioAdmin = repositorioAdmin;
        }
        public AdministradorDTO FindAdminById(int id)
        {
            return AdministradorDTOMapper.ToDto(this._repositorioAdmin.FindByID(id));
        }
    }
}
