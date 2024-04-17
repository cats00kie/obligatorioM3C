using LogicaNegocio.InterfacesRepositorio;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Administrador;
using LogicaNegocio.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Papeleria.Web.Controllers
{
    public class LoginController : Controller
    {
        private IRepositorioUsuario _repositorioUsuarios;
        private ILogin _loginCU;
        public LoginController(IRepositorioUsuario repositorioUsuarios,
            ILogin login)
        {
            this._repositorioUsuarios = repositorioUsuarios;
            this._loginCU = login;
        }
        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string email, string password)
        {
            //manda esto para el CULogin, que primero encripta la contraseña, la desencripta en la capa de datos,
            //la verifica con los usuarios de la BD, y devuelve (si es valido) un UsuarioDTO que se usará como Session en el programa.
            return View(); //TODO: Hay que cambiar esto por un Home Index. Chequear Obligatorio anterior. 
        }
    }
}
