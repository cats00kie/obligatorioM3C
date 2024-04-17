using LogicaNegocio.InterfacesRepositorio;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Administrador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Administrador
{
    public class LoginCU : ILogin
    {
        //TODO: Pedirle al EF que traiga el usuario por Email, se des-hashea la password y se verifica, devuelve el usuario de ser true o un UsuarioNoValidoException
        private IRepositorioUsuario _repositorioUsuario;
        public LoginCU(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }
        public static string GetHashSha256(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text); // Convert the string to bytes
            using (SHA256 hashAlgorithm = SHA256.Create()) // Use SHA256.Create() instead
            {
                byte[] hash = hashAlgorithm.ComputeHash(bytes); // Compute the hash
                string hashString = string.Empty;
                foreach (byte x in hash)
                {
                    hashString += String.Format("{0:x2}", x); // Convert each byte to hexadecimal
                }
                return hashString;
            }
        }
        public void Login(string email, string password)
        {

            bool login = this._repositorioUsuario.Login(email, GetHashSha256(password));
        }
    }
}
