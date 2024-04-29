using LogicaNegocio.Entidades;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso;
using Papeleria.LogicaAplicacion.Mappers;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.CasosDeUso
{
    public class GetClientesXnombreYapellidoCU : IGetClientesXnombreYapellido
    {
        private IRepositorioCliente _repositorioCliente;
        public GetClientesXnombreYapellidoCU(IRepositorioCliente repositorioCliente)
        {
            this._repositorioCliente = repositorioCliente;
        }
        public IEnumerable<ClienteDTO> GetClientesXnombreYapellido(string especifica)
        {
            IEnumerable<Cliente> clientes = this._repositorioCliente.ClientesXnombreYapellido(especifica);
            List<ClienteDTO> clientesDTO = new List<ClienteDTO>();
            foreach (Cliente cliente in clientes)
            {
                clientesDTO.Add(ClienteDTOMapper.ToDto(cliente));
            }
            return clientesDTO;
        }
    }
}
