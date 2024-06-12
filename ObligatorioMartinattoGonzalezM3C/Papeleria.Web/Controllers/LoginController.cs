using LogicaNegocio.InterfacesRepositorio;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Administrador;
using Microsoft.AspNetCore.Mvc;

namespace Papeleria.Web.Controllers
{
    public class LoginController : Controller
    {
        private IRepositorioUsuario _repositorioAdmins;
        private ILogin _loginCU;
        public LoginController(IRepositorioUsuario repositorioAdmins,
            ILogin login)
        {
            this._repositorioAdmins = repositorioAdmins;
            this._loginCU = login;
        }
        // GET: LoginController
        public ActionResult Index(string mensaje)
        {
            ViewBag.mensaje = mensaje;
            return View();
        }

        public ActionResult Login(string email, string password)
        {
            if (this._loginCU.Login(email, password))
            {
                HttpContext.Session.SetString("usuario", email);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", new { mensaje = "Nombre de usuario o contraseña incorrecta." });
            //manda esto para el CULogin, que primero encripta la contraseña, la desencripta en la capa de datos,
            //la verifica con los usuarios de la BD, y devuelve true o false.
        }
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("usuario", "");
            return RedirectToAction("Index");
        }
    }
}
