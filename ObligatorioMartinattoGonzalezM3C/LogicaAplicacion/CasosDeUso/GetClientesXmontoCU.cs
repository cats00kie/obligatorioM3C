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
    public class GetClientesXmontoCU : IGetClientesXmonto
    {
        private IRepositorioCliente _repositorioCliente;
        public GetClientesXmontoCU(IRepositorioCliente repositorioCliente)
        {
            this._repositorioCliente = repositorioCliente;
        }

        public IEnumerable<ClienteDTO> GetClientesXmonto(double monto)
        {
            IEnumerable<Cliente> clientes = this._repositorioCliente.ClientesXmonto(monto);
            List<ClienteDTO> clientesDTO = new List<ClienteDTO>();
            foreach (Cliente cliente in clientes)
            {
                clientesDTO.Add(ClienteDTOMapper.ToDto(cliente));
            }
            return clientesDTO;
        }
    }
}
