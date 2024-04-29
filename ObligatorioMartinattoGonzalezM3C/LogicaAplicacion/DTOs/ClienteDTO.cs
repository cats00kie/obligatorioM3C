using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaAplicacion.DTOs
{
    public class ClienteDTO
    {
        public int Id;
        public string Rut;
        public string RazonSocial;
        public string Nombre;
        public string Apellido;
        public ClienteDTO() { }
        public ClienteDTO(Cliente cliente)
        {
            if (cliente != null)
            {
                this.Id = cliente.Id;
                this.RazonSocial = cliente.RazonSocial;
                this.Rut = cliente.Rut;
                this.Nombre = cliente.NombreCliente.Nombre;
                this.Apellido = cliente.NombreCliente.Apellido;
            }
        }
    }
}
