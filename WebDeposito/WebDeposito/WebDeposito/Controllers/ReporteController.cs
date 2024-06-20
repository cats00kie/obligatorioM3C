using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using WebDeposito.Models;

namespace WebDeposito.Controllers
{
    public class ReporteController : Controller
    {
        private HttpClient _client;
        private string _baseUrl;
        public ReporteController()
        {
            _client = new HttpClient();
            _baseUrl = "http://localhost:5091/api/Movimientos/GetMovsXFecha";
        }
        // GET: ReporteController
        public ActionResult Index(string mensaje)
        {
            string token = HttpContext.Session.GetString("token");
            if (string.IsNullOrEmpty(token) || HttpContext.Session.GetString("rol") != "Encargado")
            {
                return RedirectToAction("Login", "Login", new { mensaje = "No Autorizado." });
            }
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Bearer",
                token
            );
            ViewBag.mensaje = mensaje;

                HttpRequestMessage solicitud =
                new HttpRequestMessage(HttpMethod.Get, new Uri(_baseUrl));
                Task<HttpResponseMessage> respuesta = _client.SendAsync(solicitud);
                respuesta.Wait();
                if (respuesta.Result.IsSuccessStatusCode)
                {
                    if (respuesta.Result.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        ViewBag.mensaje = "No hay resultados.";
                        return View();
                    }
                    var objetoComoTexto = respuesta.Result.Content.ReadAsStringAsync().Result;
                    var movs = JsonConvert.DeserializeObject<IEnumerable<FechaModel>>(objetoComoTexto);
                    return View(movs);
                }

                return View();
            }
    }
}
