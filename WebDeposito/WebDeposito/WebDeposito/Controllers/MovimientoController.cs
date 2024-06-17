using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WebDeposito.Models;

namespace WebDeposito.Controllers
{
    public class MovimientoController : Controller
    {
        private HttpClient _client;
        private string _baseUrl;
        private static int actualPage;
        public MovimientoController()
        {
            _client = new HttpClient();
            _baseUrl = "http://localhost:5091/api/Movimientos/";
        }
           

        public ActionResult Index(string message)
        {
            try
            {
                if (actualPage < 1) { actualPage = 1; }
                HttpRequestMessage solicitud =
                new HttpRequestMessage(HttpMethod.Get, new Uri(_baseUrl + "page/" + actualPage));
                Task<HttpResponseMessage> respuesta = _client.SendAsync(solicitud);
                respuesta.Wait();

                if (respuesta.Result.IsSuccessStatusCode)
                {
                    var objetoComoTexto = respuesta.Result.Content.ReadAsStringAsync().Result;
                    var movs = JsonConvert.DeserializeObject<IEnumerable<MovimientoModel>>(objetoComoTexto);
                    return View(movs);
                }
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Search", "Home", new { searchValue = "404notFound" });
            }
        }

    [HttpPost]
    public ActionResult Next()
    {
        try
        {
            string message = "";
            actualPage++;
            if (actualPage < 1)
            {
                actualPage = 1;
                message = "Only postive numbers allowed";
            }

            return RedirectToAction("Index", new { message = message });
        }
        catch (Exception ex)
        {
            return RedirectToAction("Search", "Home", new { searchValue = "404notFound" });
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
            return RedirectToAction("Search", "Home", new { searchValue = "404notFound" });
        }
    }

    // GET: TeamController/Create
        public ActionResult Create(string mensaje)
        {
            HttpRequestMessage solicitud =
                new HttpRequestMessage(HttpMethod.Get, new Uri("http://localhost:5091/api/Articulos"));
            Task<HttpResponseMessage> respuesta = _client.SendAsync(solicitud);
            respuesta.Wait();

            if (respuesta.Result.IsSuccessStatusCode)
            {
                var objetoComoTexto = respuesta.Result.Content.ReadAsStringAsync().Result;
                IEnumerable<ArticuloModel> articulos = JsonConvert.DeserializeObject<IEnumerable<ArticuloModel>>(objetoComoTexto);
                ViewBag.Articulos = articulos;
            }

            HttpRequestMessage solicitudM =
                new HttpRequestMessage(HttpMethod.Get, new Uri("http://localhost:5091/api/TipoMovimientos"));
            Task<HttpResponseMessage> respuestaM = _client.SendAsync(solicitudM);
            respuestaM.Wait();

            if (respuestaM.Result.IsSuccessStatusCode)
            {
                var objetoComoTexto = respuestaM.Result.Content.ReadAsStringAsync().Result;
                IEnumerable<TipoMovimientoModel> tipos = JsonConvert.DeserializeObject<IEnumerable<TipoMovimientoModel>>(objetoComoTexto);
                ViewBag.TipoMovs = tipos;
            }
            //TODO: HACER AUTH CON EL EMAIL
            ViewBag.Email = "eltuki@email.com";
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
                    return View();
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

