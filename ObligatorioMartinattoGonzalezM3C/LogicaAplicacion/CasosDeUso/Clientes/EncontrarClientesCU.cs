using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Cliente;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Clientes
{
    public class EncontrarClientesCU : IEncontrarClientes
    {
        private IRepositorioCliente _repositorioCliente;
        public EncontrarClientesCU(IRepositorioCliente repositorioCliente)
        {
            this._repositorioCliente = repositorioCliente;
        }
        public IEnumerable<ClienteDTO> FindAllClientes()
        {
            IEnumerable<Cliente> clientes= this._repositorioCliente.FindAll();
            List<ClienteDTO> clientesDTO= new List<ClienteDTO>();
            foreach (Cliente cliente in clientes)
            {
                clientesDTO.Add(ClienteDTOMapper.ToDto(cliente));
            }
            return clientesDTO;
        }
    }
}
