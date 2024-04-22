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
        private IRepositorioAdministrador _repositorioAdministrador;
        public EncontrarAdminsCU(IRepositorioAdministrador repositorioAdministrador)
        {
            this._repositorioAdministrador = repositorioAdministrador;
        }
        public IEnumerable<AdministradorDTO> FindAllAdmins()
        {
            IEnumerable<Administrador> administradores = this._repositorioAdministrador.FindAll();
            List<AdministradorDTO> administradoresDTO = new List<AdministradorDTO>();
            foreach(Administrador admin in administradores)
            {
                administradoresDTO.Add(AdministradorDTOMapper.ToDto(admin));
            }
            return administradoresDTO;
        }
    }
}
