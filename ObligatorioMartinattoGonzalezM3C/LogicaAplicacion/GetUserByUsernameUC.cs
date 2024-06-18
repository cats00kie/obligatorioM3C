using ApplicationLogic.InterfacesUseCase;
using LogicaNegocio.InterfacesRepositorio;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogic.UseCases
{
    public class GetUserByUsernameUC : IGetUserByUsername
    {
        private IRepositorioUsuario _repositorioUsuario;
        public GetUserByUsernameUC(IRepositorioUsuario repositorioUsuario)
        {
            this._repositorioUsuario = repositorioUsuario;
        }

        public UsuarioDTO FindUserByUsername(string email)
        {
            return UsuarioDTOMapper.FromEncargado((Encargado)this._repositorioUsuario.FindByEmail(email));
        }
    }
}
