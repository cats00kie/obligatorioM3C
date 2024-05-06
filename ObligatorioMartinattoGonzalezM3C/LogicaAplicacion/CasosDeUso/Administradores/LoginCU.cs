using LogicaNegocio.InterfacesRepositorio;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Administrador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Reflection.Metadata;
using Papeleria.LogicaNegocio.Excepciones;
using LogicaNegocio.Entidades;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Administradores
{
    public class LoginCU : ILogin
    {
        private IRepositorioAdministrador _repositorioAdmin;
        public LoginCU(IRepositorioAdministrador repositorioAdmin)
        {
            _repositorioAdmin = repositorioAdmin;
        }
        public bool Login(string email, string password)
        {
           
            Administrador admin = this._repositorioAdmin.FindByEmail(email);
            
            if (admin != null)
            {
                Hash hash = new Hash(); 
                if(hash.GetHashSha256(password) == admin.Password) return true; 
                //Hashea la contraseña.
                //Verifica si es la misma que ya está en la BD
                //Si es así, devuelve true.
                else return false;
            }
            else return false;
        }
    }
}
