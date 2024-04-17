using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        public Usuario FindByEmail(string email)
        {
            return this._context.Usuarios.Where(usuario => (usuario as Administrador).Email == email).FirstOrDefault(); 
        }

        public bool Remove(int id)
        {
            try
            {
                Usuario aBorrar = new Administrador { Id = id };
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

        //public bool Login(string email, string encrypted)
        //{
        //    Usuario usuario = return this._context.Usuarios.Where(usuario => usuario);
        //}
    }
}
