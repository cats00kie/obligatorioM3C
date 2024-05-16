using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Articulo;

namespace Papeleria.Web.Controllers
{
    public class ArticulosController : Controller
    {

        private IEncontrarArticulos _encontrarArticulos;
        private ICrearArticulo _crearArticulo;
        public ArticulosController(IEncontrarArticulos encontrarArticulos, ICrearArticulo crearArticulo)
        {
            _encontrarArticulos = encontrarArticulos;
            _crearArticulo = crearArticulo;
        }

        // GET: ArticulosController
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                return RedirectToAction("Index", "Login", new { mensaje = "Por favor inicie sesion" });
            }
            return View(this._encontrarArticulos.EncontrarArticulos());
        }

        // GET: ArticulosController/Create
        public ActionResult Create()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                return RedirectToAction("Index", "Login", new { mensaje = "Por favor inicie sesion" });
            }
            return View();
        }

        // POST: ArticulosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticuloDTO articulo)
        {
            try
            {
                this._crearArticulo.CrearArticulo(articulo);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
