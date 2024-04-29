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
            return View(this._encontrarArticulos.EncontrarArticulos());
        }

        // GET: ArticulosController/Create
        public ActionResult Create()
        {
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

        // GET: ArticulosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArticulosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticulosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArticulosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
