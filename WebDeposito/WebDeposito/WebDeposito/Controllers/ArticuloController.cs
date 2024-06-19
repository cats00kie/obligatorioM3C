using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            if(actualPage < 1) { actualPage = 1; }
            HttpRequestMessage solicitud =
            new HttpRequestMessage(HttpMethod.Get, new Uri(_baseUrl +"GetByFechas/"+ "Page/" + actualPage
            +"/startdate="+startdate.ToString("yyyy-MM-dd")+"/enddate=" + enddate.ToString("yyyy-MM-dd")));
            Task<HttpResponseMessage> respuesta = _client.SendAsync(solicitud);
            respuesta.Wait();
            if (respuesta.Result.IsSuccessStatusCode)
            {
                var objetoComoTexto = respuesta.Result.Content.ReadAsStringAsync().Result;
                var articulos = JsonConvert.DeserializeObject<IEnumerable<ArticuloModel>>(objetoComoTexto);
                return View(articulos);
            }
            return View();
        }
        
        public IActionResult GetFechas(string mensaje)
        {
            ViewBag.Mensaje = mensaje;
            return View();
        }
        [HttpPost]
        public IActionResult GetFechas(DateTime start, DateTime end) 
        {
            if(start > end || start == null || end == null) return RedirectToAction("Index", new {mensaje = "Fechas no validas."});
            return RedirectToAction("Index", new { startdate = start, enddate = end });
        }
    }
}
