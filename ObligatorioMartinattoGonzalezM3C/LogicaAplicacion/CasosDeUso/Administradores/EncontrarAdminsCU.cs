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
    public class EncontrarAdminsCU : IEncontrarAdmins
    {
        private IRepositorioUsuario _repositorioAdministrador;
        public EncontrarAdminsCU(IRepositorioUsuario repositorioAdministrador)
        {
            this._repositorioAdministrador = repositorioAdministrador;
        }
        public IEnumerable<UsuarioDTO> FindAllAdmins()
        {
            IEnumerable<Usuario> administradores = this._repositorioAdministrador.FindAll();
            List<UsuarioDTO> administradoresDTO = new List<UsuarioDTO>();
            foreach(Administrador admin in administradores)
            {
                administradoresDTO.Add(UsuarioDTOMapper.FromAdmin(admin));
            }
            return administradoresDTO;
        }
    }
}
