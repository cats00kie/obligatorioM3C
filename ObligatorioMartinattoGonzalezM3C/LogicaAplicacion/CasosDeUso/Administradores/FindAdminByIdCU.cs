using LogicaNegocio.Entidades;
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
        private IRepositorioUsuario _repositorioAdmin;
        public FindAdminByIdCU(IRepositorioUsuario repositorioAdmin)
        {
            _repositorioAdmin = repositorioAdmin;
        }
        public UsuarioDTO FindAdminById(int id)
        {
            return UsuarioDTOMapper.FromAdmin((Administrador)this._repositorioAdmin.FindByID(id));
        }
    }
}
