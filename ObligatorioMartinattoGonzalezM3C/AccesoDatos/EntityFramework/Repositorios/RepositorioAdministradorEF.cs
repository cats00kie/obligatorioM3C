using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.EntityFramework
{
    public class RepositorioAdministradorEF : IRepositorioAdministrador
    {
        private PapeleriaContext _context;
        public RepositorioAdministradorEF()
        {
            this._context = new PapeleriaContext();
        }
        public bool Add(Administrador aAgregar)
        {
            try
            {
                this._context.Admins.Add(aAgregar);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Administrador> FindAll()
        {
            return this._context.Admins;
        }

        public Administrador FindByEmail(string email)
        {
            try
            {
                return this._context.Admins.Where(admin => admin.Email == email).FirstOrDefault();
            }
            catch (Exception ex) { throw ex; }
        }

        public Administrador FindByID(int id)
        {
            return this._context.Admins.Where(admin => admin.Id == id).FirstOrDefault();
        }

        public bool Remove(int id)
        {
            try
            {
                Administrador aBorrar = FindByID(id);
                this._context.Admins.Remove(aBorrar);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Administrador aModificar)
        {
            try
            {
                this._context.Admins.Update(aModificar);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
