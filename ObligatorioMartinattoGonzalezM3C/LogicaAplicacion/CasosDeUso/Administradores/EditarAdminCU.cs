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
        private IRepositorioAdministrador _repositorioAdmin;
        public EditarAdminCU(IRepositorioAdministrador repositorioAdmin)
        {
            _repositorioAdmin = repositorioAdmin;
        }
        public bool EditarAdmin(AdministradorDTO aModificar)
        {
            Administrador admin = AdministradorDTOMapper.FromDto(aModificar);
            Hash hash = new Hash();
            try
            {
                admin.IsValid();
                admin.Password = hash.GetHashSha256(aModificar.Password);
                return this._repositorioAdmin.Update(admin);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
