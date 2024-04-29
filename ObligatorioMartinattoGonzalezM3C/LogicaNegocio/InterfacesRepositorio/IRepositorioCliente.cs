using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.LogicaNegocio.InterfacesRepositorio
{
    public interface IRepositorioCliente : IRepositorio<Cliente>
    {
        public IEnumerable<Cliente> ClientesXnombreYapellido(string especifica);
        public IEnumerable<Cliente> ClientesXmonto(double monto);
    }
}
