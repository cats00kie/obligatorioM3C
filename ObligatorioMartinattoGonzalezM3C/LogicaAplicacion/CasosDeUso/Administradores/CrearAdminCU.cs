using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Administrador;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Administradores
{
    public class CrearAdminCU : ICrearAdmin
    {
        private IRepositorioAdministrador _repositorioAdmin;
        public CrearAdminCU(IRepositorioAdministrador repositorioAdmin) 
        {
            _repositorioAdmin = repositorioAdmin;
        }
        public void CrearAdmin(AdministradorDTO adminDto)
        {
            Administrador admin = AdministradorDTOMapper.FromDto(adminDto);
            Hash hash = new Hash();
            try
            {
                admin.IsValid();
                admin.PasswordSinEncript = admin.Password;
                admin.Password = hash.GetHashSha256(adminDto.Password);
                this._repositorioAdmin.Add(admin);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
