using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using WebDeposito.Models;

namespace WebDeposito.Controllers
{
    public class ArticuloController : Controller
    {
        private HttpClient _client;
        private string _baseUrl;
        private static int actualPage;
        public ArticuloController()
        {
            _client = new HttpClient();
            _baseUrl = "http://localhost:5091/api/Articulos/";
        }
        public IActionResult Index(DateTime startdate, DateTime enddate)
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
            if (actualPage < 1) { actualPage = 1; }
            HttpRequestMessage solicitud =
            new HttpRequestMessage(HttpMethod.Get, new Uri(_baseUrl + "GetByFechas/" + "Page/" + actualPage
            + "/startdate=" + startdate.ToString("yyyy-MM-dd") + "/enddate=" + enddate.ToString("yyyy-MM-dd")));
            Task<HttpResponseMessage> respuesta = _client.SendAsync(solicitud);
            respuesta.Wait();
            if (respuesta.Result.IsSuccessStatusCode)
            {
                if (respuesta.Result.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    ViewBag.mensaje = "No hay resultados.";
                    actualPage = 1;
                    return View();
                }
                var objetoComoTexto = respuesta.Result.Content.ReadAsStringAsync().Result;
                var articulos = JsonConvert.DeserializeObject<IEnumerable<ArticuloModel>>(objetoComoTexto);
                return View(articulos);
            }
            
            return View();
        }
        
        public IActionResult GetFechas(string mensaje)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("token")) && HttpContext.Session.GetString("rol") == "Encargado")
            {
                ViewBag.mensaje = mensaje;
                return View();
            }
            return RedirectToAction("Login", "Login", new { mensaje = "No autorizado" });
        }
        [HttpPost]
        public IActionResult GetFechas(DateTime start, DateTime end) 
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("token")) && HttpContext.Session.GetString("rol") == "Encargado")
            {
                if (start > end || start == null || end == null) return RedirectToAction("Index", new { mensaje = "Fechas no validas." });
                return RedirectToAction("Index", new { startdate = start, enddate = end });
            }
            return RedirectToAction("Login", "Login", new { mensaje = "No autorizado" });
        }
        [HttpPost]
        public ActionResult Next()
        {

            try
            {
                string mensaje = "";
                actualPage++;
                if (actualPage < 1)
                {
                    actualPage = 1;
                    mensaje = "Solo números positivos.";
                }

                return RedirectToAction("Index", new { message = mensaje });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Movimiento", new { mensaje = "Hubo un error" });
            }

        }

        [HttpPost]
        public ActionResult Previous()
        {


            try
            {
                string message = "";
                actualPage--;
                if (actualPage < 1)
                {
                    actualPage = 1;
                    message = "Only postive numbers allowed";
                }

                return RedirectToAction("Index", new { message = message });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Movimiento", new { mensaje = "Hubo un error" });
            }
        }
    }
}
