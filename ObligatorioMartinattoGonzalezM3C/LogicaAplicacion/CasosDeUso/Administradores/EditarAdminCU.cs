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
    public class EditarAdminCU : IEditarAdmin
    {
        private IRepositorioUsuario _repositorioAdmin;
        public EditarAdminCU(IRepositorioUsuario repositorioAdmin)
        {
            _repositorioAdmin = repositorioAdmin;
        }
        public bool EditarAdmin(UsuarioDTO aModificar)
        {
            Administrador admin = UsuarioDTOMapper.FromDtoAdmin(aModificar);
            Hash hash = new Hash();
            try
            {
                admin.Password = aModificar.PasswordSinEncript;
                admin.PasswordSinEncript = aModificar.PasswordSinEncript;
                admin.IsValid();
                admin.Password = hash.GetHashSha256(aModificar.PasswordSinEncript);
                return this._repositorioAdmin.Update(admin);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
