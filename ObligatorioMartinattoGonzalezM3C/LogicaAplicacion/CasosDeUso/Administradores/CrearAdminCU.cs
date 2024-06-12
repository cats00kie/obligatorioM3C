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
        private IRepositorioUsuario _repositorioAdmin;
        public CrearAdminCU(IRepositorioUsuario repositorioAdmin) 
        {
            _repositorioAdmin = repositorioAdmin;
        }
        public void CrearAdmin(UsuarioDTO adminDto)
        {
            Administrador admin = UsuarioDTOMapper.FromDtoAdmin(adminDto);
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
