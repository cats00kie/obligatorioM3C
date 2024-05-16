using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Papeleria.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index(string mensaje)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                return RedirectToAction("Index", "Login", new { mensaje = "No tienes acceso" });
            }
            else
            {
                ViewBag.Mensaje = mensaje;
                if (HttpContext.Session.GetString("rol") == "Miembro")
                {
                    ViewBag.usuario = (HttpContext.Session.GetString("usuario"));
                }
                return View();
            }
        }
    }
}
