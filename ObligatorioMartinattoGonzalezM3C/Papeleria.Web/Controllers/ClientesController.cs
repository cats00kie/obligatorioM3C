using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso.Cliente;

namespace Papeleria.Web.Controllers
{
    public class ClientesController : Controller
    {

        private IEncontrarClientes _encontrarClientes;
        private IGetClientesXnombreYapellido _xnombreYapellido;
        private IGetClientesXmonto _xMonto;

        public ClientesController(IEncontrarClientes encontrarClientes, IGetClientesXnombreYapellido xnombreYapellido, IGetClientesXmonto xMonto)
        {
            _encontrarClientes = encontrarClientes;
            _xnombreYapellido = xnombreYapellido;
            _xMonto = xMonto;
        }



        // GET: ClientesController
        public ActionResult Index(string mensaje, string filtro)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("usuario")))
            {
                return RedirectToAction("Index", "Login", new { mensaje = "Por favor inicie sesion" });
            }
            IEnumerable<ClienteDTO> toShow = new List<ClienteDTO>();
            ViewBag.Mensaje = mensaje;
            ViewBag.Clientes = this._encontrarClientes.FindAllClientes();

            if (string.IsNullOrEmpty(filtro))
            {
                toShow = _encontrarClientes.FindAllClientes();
            }
            if (filtro == "PorRazonSocial")
            {
                string razon = (string)TempData["Razon"];
                toShow = this._xnombreYapellido.GetClientesXnombreYapellido(razon);
            }
            if(filtro == "PorMonto")
            {
                double monto = (double)TempData["Monto"];
                toShow = this._xMonto.GetClientesXmonto(monto);
            }
            return View(toShow);
        }

        [HttpPost]
        public ActionResult FiltrarPorRazonSocial(string razon)
        {
            if (razon == null)
            {
                return RedirectToAction("Index");
            }
            TempData["Razon"] = razon;
            return RedirectToAction("Index", new { filtro = "PorRazonSocial" });
        }

        [HttpPost]
        public ActionResult FiltrarPorMonto (double monto)
        {
            if (monto <= 0)
            {
                return RedirectToAction("Index", new { mensaje = "Monto invalido." });
            }
            TempData["Monto"] = monto;
            return RedirectToAction("Index", new { filtro = "PorMonto" });
        }

    }
}
