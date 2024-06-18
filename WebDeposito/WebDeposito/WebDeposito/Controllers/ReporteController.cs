using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public ActionResult Index()
        {
            HttpRequestMessage solicitud =
                new HttpRequestMessage(HttpMethod.Get, new Uri(_baseUrl));
            Task<HttpResponseMessage> respuesta = _client.SendAsync(solicitud);
            respuesta.Wait();
            if (respuesta.Result.IsSuccessStatusCode)
            {
                var objetoComoTexto = respuesta.Result.Content.ReadAsStringAsync().Result;
                var movs = JsonConvert.DeserializeObject<IEnumerable<FechaModel>>(objetoComoTexto);
                return View(movs);
            }
            return View();
        }
    }
}
