using LogicaNegocio.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Articulo;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Cliente;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Pedido;

namespace Papeleria.Web.Controllers
{
    public class PedidosController : Controller
    {
        private ICrearPedido _crearPedido;
        private IEncontrarPedidos _encontrarPedidos;
        private IEncontrarClientes _encontrarClientes;
        private IEncontrarArticulos _encontrarArticulos;
        private IEncontrarPrecioPedido _encontrarPrecioPedido;
        private IEncontrarXIdArticulo _encontrarXIdArticulo;
        private static PedidoDTO tempPedido;
        private static List<ArticuloDTO> tempArticulos;

        public PedidosController(ICrearPedido crearPedido, IEncontrarArticulos encontrarArticulos, IEncontrarPedidos encontrarPedidos, 
            IEncontrarClientes encontrarClientes, IEncontrarPrecioPedido encontrarPrecioPedido, IEncontrarXIdArticulo encontrarXIdArticulo)
        {
            _crearPedido = crearPedido;
            _encontrarArticulos = encontrarArticulos;
            _encontrarPedidos = encontrarPedidos;
            _encontrarClientes = encontrarClientes;
            _encontrarPrecioPedido = encontrarPrecioPedido;
            _encontrarXIdArticulo = encontrarXIdArticulo;
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
        public ActionResult Create(string mensaje, Boolean esExpress)
        {
            if (tempPedido != null)
            {
                ViewBag.Lineas = tempPedido.Lineas;
            }
            ViewBag.Clientes = this._encontrarClientes.FindAllClientes();
            ViewBag.Articulos = this._encontrarArticulos.EncontrarArticulos();
            ViewBag.PrecioPedido = this._encontrarPrecioPedido.EncontrarPrecioPedido(tempPedido, esExpress);
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
                tempArticulos = null;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return this.RedirectToAction(nameof(Create));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddLinea(int articuloId, int cantUnidades, int idCliente)
        {
            ArticuloDTO articulo = _encontrarXIdArticulo.FindById(articuloId);
            if (tempArticulos == null)
            {
                tempArticulos = new List<ArticuloDTO>();
                if (articulo.Stock >= cantUnidades && cantUnidades > 0)
                {
                    articulo.Stock -= cantUnidades;
                    tempArticulos.Add(articulo);
                    LineaDTO linea = new LineaDTO { ArticuloId = articuloId, CantUnidades = cantUnidades, Precio = articulo.Precio * cantUnidades };
                    if (tempPedido == null)
                    {
                        tempPedido = new PedidoDTO { Lineas = new List<LineaDTO>() };
                    }
                    tempPedido.ClienteId = idCliente;
                    tempPedido.Lineas.Add(linea);
                    return this.RedirectToAction(nameof(Create));
                }
                else return this.RedirectToAction(nameof(Create));
            }
            else {
                foreach (ArticuloDTO unArticulo in tempArticulos)
                {
                    if (unArticulo.Id == articuloId)
                    {
                        if (unArticulo.Stock >= cantUnidades && cantUnidades > 0)
                        {
                            unArticulo.Stock = unArticulo.Stock - cantUnidades;
                            LineaDTO linea = new LineaDTO { ArticuloId = articuloId, CantUnidades = cantUnidades, Precio = articulo.Precio * cantUnidades };
                            if (tempPedido == null)
                            {
                                tempPedido = new PedidoDTO { Lineas = new List<LineaDTO>() };
                            }
                            tempPedido.Lineas.Add(linea);
                            return this.RedirectToAction(nameof(Create));
                        }
                        else return this.RedirectToAction(nameof(Create));
                    }
                }
                if (articulo.Stock >= cantUnidades && cantUnidades > 0)
                {
                    tempArticulos.Add(articulo);
                    LineaDTO linea = new LineaDTO { ArticuloId = articuloId, CantUnidades = cantUnidades, Precio = articulo.Precio * cantUnidades };
                    if (tempPedido == null)
                    {
                        tempPedido = new PedidoDTO { Lineas = new List<LineaDTO>() };
                    }
                    tempPedido.Lineas.Add(linea);
                    return this.RedirectToAction(nameof(Create));
                }
                else return this.RedirectToAction(nameof(Create));
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
