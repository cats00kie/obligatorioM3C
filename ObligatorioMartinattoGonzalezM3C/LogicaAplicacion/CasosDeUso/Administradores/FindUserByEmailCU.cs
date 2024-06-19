using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Administradores
{
    public class FindUserByEmailCU : IFindUserByEmail
    {
        private IRepositorioUsuario _repositorioAdministrador;
        public FindUserByEmailCU(IRepositorioUsuario repositorioAdministrador)
        {
            this._repositorioAdministrador = repositorioAdministrador;
        }
        public UsuarioDTO FindUserByEmail(string email)
        {
            Usuario elUsuario = this._repositorioAdministrador.FindByEmail(email);
            if (elUsuario is Encargado)
            {
                UsuarioDTO usuario = UsuarioDTOMapper.FromEncargado(elUsuario as Encargado);
                usuario.IsEncargado = true;
                return usuario;
            }
            if (elUsuario is Administrador) return UsuarioDTOMapper.FromAdmin(elUsuario as Administrador);
            return null;
        }
    }
}
