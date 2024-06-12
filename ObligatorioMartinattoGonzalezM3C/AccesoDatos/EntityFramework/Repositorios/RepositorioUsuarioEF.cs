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
    public class RepositorioUsuarioEF : IRepositorioUsuario
    {
        private PapeleriaContext _context;
        public RepositorioUsuarioEF()
        {
            this._context = new PapeleriaContext();
        }
        public bool Add(Usuario aAgregar)
        {
            try
            {
                this._context.Usuarios.Add(aAgregar);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Usuario> FindAll()
        {
            return this._context.Usuarios;
        }

        public Usuario FindByEmail(string email)
        {
            try
            {
                return this._context.Usuarios.Where(admin => admin.Email == email).FirstOrDefault();
            }
            catch (Exception ex) { throw ex; }
        }

        public Usuario FindByID(int id)
        {
            return this._context.Usuarios.Where(admin => admin.Id == id).FirstOrDefault();
        }

        public bool Remove(int id)
        {
            try
            {
                Usuario aBorrar = FindByID(id);
                this._context.Usuarios.Remove(aBorrar);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Usuario aModificar)
        {
            try
            {
                this._context.Usuarios.Update(aModificar);
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
