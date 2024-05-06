using AccesoDatos.EntityFramework;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using Papeleria.LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papeleria.AccesoDatos.EntityFramework.Repositorios
{
    public class RepositorioConfiguracionEF : IRepositorioConfig
    {
        PapeleriaContext _context;
        public RepositorioConfiguracionEF()
        {
            this._context = new PapeleriaContext();
        }

        public bool Add(Configuracion aAgregar)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Configuracion> FindAll()
        {
            throw new NotImplementedException();
        }

        public Configuracion FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public Configuracion FindByNombre(string nombre)
        {
            return this._context.Configuraciones.Where(config => config.Nombre == nombre).FirstOrDefault();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Configuracion aModificar)
        {
            throw new NotImplementedException();
        }
    }
}
