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
        //TODO: Pedirle al EF que traiga el usuario por Email, se des-hashea la password y se verifica, devuelve el usuario de ser true o un UsuarioNoValidoException
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
                if(/*hash.GetHashSha256*/(password) == admin.Password) return true;
                else return false;
            }
            else return false;
        }
    }
}
