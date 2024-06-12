using LogicaNegocio.InterfacesRepositorio;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Administrador;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Administradores
{
    public class BorrarAdminCU : IBorrarAdmin
    {
        private IRepositorioUsuario _repositorioAdministrador;
        public BorrarAdminCU(IRepositorioUsuario repositorioAdministrador)
        {
            this._repositorioAdministrador = repositorioAdministrador;
        }

        public void BorrarAdmin(int id)
        {
            this._repositorioAdministrador.Remove(id);
        }            
    }
}
