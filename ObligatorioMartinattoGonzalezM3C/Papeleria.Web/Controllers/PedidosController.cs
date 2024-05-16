using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
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
        private IAnularPedido _anularPedido;
        private IGetPedidosPorFecha _getPedidosPorFecha;
        private static PedidoDTO tempPedido;
        private static List<ArticuloDTO> tempArticulos;

        public PedidosController(ICrearPedido crearPedido, 
            IEncontrarArticulos encontrarArticulos, IEncontrarPedidos encontrarPedidos,
            IEncontrarClientes encontrarClientes, IEncontrarPrecioPedido encontrarPrecioPedido,
            IEncontrarXIdArticulo encontrarXIdArticulo, IAnularPedido anularPedido, IGetPedidosPorFecha getPedidosPorFecha)
        {
            _crearPedido = crearPedido;
            _encontrarArticulos = encontrarArticulos;
            _encontrarPedidos = encontrarPedidos;
            _encontrarClientes = encontrarClientes;
            _encontrarPrecioPedido = encontrarPrecioPedido;
            _encontrarXIdArticulo = encontrarXIdArticulo;
            _anularPedido = anularPedido;
            _getPedidosPorFecha = getPedidosPorFecha;
        }

        // GET: PedidosController
        public ActionResult Index(string filtro, string mensaje)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                return RedirectToAction("Index", "Login", new { mensaje = "Necesita hacer login" });
            }
            IEnumerable<PedidoDTO> aMostrar = new List<PedidoDTO>();
            if (string.IsNullOrEmpty(filtro))
            {
                aMostrar = this._encontrarPedidos.EncontrarPedidos();
                ViewBag.Filtro = "Ninguno";
            }
            if (filtro == "PorFecha")
            {
                DateTime FechaPrometida = DateTime.Parse(TempData["FechaPrometida"].ToString());
                aMostrar = this._getPedidosPorFecha.GetPedidosPorFecha(FechaPrometida);
                if(aMostrar.Count() == 0)
                {
                    return RedirectToAction("Index", new { filtro = "",  mensaje = "No hay pedidos sin entregar con esa fecha." });
                }
                ViewBag.Filtro = "Fecha";
            }
            ViewBag.Mensaje = mensaje;
            ViewBag.Clientes = this._encontrarClientes.FindAllClientes();
            ViewBag.Articulos = this._encontrarArticulos.EncontrarArticulos();
            return View(aMostrar);
        }

        // GET: PedidosController/Create
        public ActionResult Create(Boolean esExpress)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                return RedirectToAction("Index", "Login", new { mensaje = "Por favor inicie sesion" });
            }
            ViewBag.Clientes = this._encontrarClientes.FindAllClientes();
            ViewBag.Articulos = this._encontrarArticulos.EncontrarArticulos();
            ViewBag.PrecioPedido = 0;
            if (tempPedido != null)
            {
                ViewBag.Lineas = tempPedido.Lineas;
                ViewBag.PrecioPedido = this._encontrarPrecioPedido.EncontrarPrecioPedido(tempPedido, esExpress);
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
                tempArticulos = null;
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Pedidos", new {mensaje = ex.Message});
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AnularPedido(int idPedido)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                return RedirectToAction("Index", "Login", new { mensaje = "Por favor inicie sesion" });
            }
            try
            {
                this._anularPedido.AnularPedido(idPedido);
                return this.RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return this.RedirectToAction("Index", "Pedidos", new {mensaje = "Error al anular" });
            }
        }
        [HttpPost]
        public ActionResult FiltrarPorFecha(DateTime FechaPrometida)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                return RedirectToAction("Index", "Login", new { mensaje = "Por favor inicie sesion" });
            }
            if (FechaPrometida < DateTime.Today)
            {
                return RedirectToAction("Index", new { mensaje = "Fecha invalida." });
            }
            TempData["FechaPrometida"] = FechaPrometida.ToString();
            return RedirectToAction("Index", new { filtro = "PorFecha" });
        }
    }
}
