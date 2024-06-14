using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebDeposito.Models;

namespace WebDeposito.Controllers
{
    public class MovimientoController : Controller
    {
        private HttpClient _client;
        private string _baseUrl;
        public MovimientoController()
        {
            _client = new HttpClient();
            _baseUrl = "http://localhost:5261/api/Movimientos/";
        }
        // GET: TeamController/Create
        public ActionResult Create(string mensaje)
        {

            ViewBag.message = mensaje;
            return View();
        }

        // POST: TeamController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovimientoModel mov)
        {
            try
            {
                HttpRequestMessage solicitud = new HttpRequestMessage(HttpMethod.Post, new Uri(_baseUrl));
                string json = JsonConvert.SerializeObject(mov);
                HttpContent contenido = new StringContent(json, Encoding.UTF8, "application/json");
                solicitud.Content = contenido;
                Task<HttpResponseMessage> respuesta = _client.SendAsync(solicitud);
                respuesta.Wait();

                if (respuesta.Result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                return View();
            }
            catch (Exception e)
            {
                return RedirectToAction("Create", new { message = "Hubo un error." });
            }
        }
    }
}
