using LogicaNegocio.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Articulo;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Pedido;

namespace Papeleria.Web.Controllers
{
    public class PedidosController : Controller
    {

        private static Configuracion configuracion = new Configuracion(22);
        private ICrearPedido _crearPedido;
        private IEncontrarPedidos _encontrarPedidos;
        private IEncontrarArticulos _encontrarArticulos;
        private static PedidoDTO tempPedido;

        public PedidosController(ICrearPedido crearPedido, IEncontrarArticulos encontrarArticulos, IEncontrarPedidos encontrarPedidos)
        {
            _crearPedido = crearPedido;
            _encontrarArticulos = encontrarArticulos;
            _encontrarPedidos = encontrarPedidos;
        }




        // GET: PedidosController
        public ActionResult Index(string mensaje)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                return RedirectToAction("Login", "Index", new { mensaje = "Necesita hacer login" });
            }
            ViewBag.Message = mensaje;
            IEnumerable<PedidoDTO> aMostrar = new List<PedidoDTO>();
            aMostrar = this._encontrarPedidos.EncontrarPedidos();
            return View();
        }

        // GET: PedidosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PedidosController/Create
        public ActionResult Create(string mensaje)
        {
            if (tempPedido != null)
            {
                ViewBag.Lineas = tempPedido.Lineas;
            }
            return View();
        }

        // POST: PedidosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidoDTO pedido, Boolean esExpress)
        {
            try
            {
                if(tempPedido != null && tempPedido.Lineas.Count > 0)
                {
                    pedido.Lineas = tempPedido.Lineas;
                }
                this._crearPedido.CrearPedido(pedido, esExpress);
                tempPedido = null;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PedidosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PedidosController/Edit/5
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

        // GET: PedidosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PedidosController/Delete/5
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
