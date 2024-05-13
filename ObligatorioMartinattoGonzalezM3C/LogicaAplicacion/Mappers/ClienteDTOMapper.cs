using LogicaNegocio.Entidades;
using Papeleria.LogicaAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.Mappers
{
    public class ClienteDTOMapper
    {
        public static ClienteDTO ToDto(Cliente cliente)
        {
            return new ClienteDTO(cliente);
        }

        public static Cliente FromDto(ClienteDTO clienteDTO)
        {
            if (clienteDTO == null)
            {
                throw new NotImplementedException();
            }
            return new Cliente(clienteDTO.Id, clienteDTO.RazonSocial, clienteDTO.Rut, clienteDTO.Nombre, clienteDTO.Apellido, 
                clienteDTO.nombreCalle, clienteDTO.numeroPuerta, clienteDTO.ciudad, clienteDTO.distanciaKm);
        }
    }
}
