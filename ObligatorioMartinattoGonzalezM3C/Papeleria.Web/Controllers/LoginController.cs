using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Papeleria.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string email, string password)
        {
            //manda esto para un dto, que primero encripta la contraseña, la desencripta en la capa de datos,
            //la verifica con los usuarios de la BD, y devuelve (si es valido) un UsuarioDTO que se usará como Session en el programa.
            return View(); //TODO: Hay que cambiar esto por un Home Index. Chequear Obligatorio anterior. 
        }
    }
}
