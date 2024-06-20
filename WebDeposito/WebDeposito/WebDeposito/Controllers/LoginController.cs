using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Common;
using System.Text;
using WebDeposito.Models;

namespace WebDeposito.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login(string mensaje)
        {
            ViewBag.mensaje = mensaje;
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            HttpClient cliente = new HttpClient();
            HttpRequestMessage solicitud =
            new HttpRequestMessage(HttpMethod.Post, new Uri("http://localhost:5091/api/Login/login"));
            UserModel model = new UserModel();
            model.Email = email;
            model.PasswordSinEncript = password;
            var json = JsonConvert.SerializeObject(model);
            HttpContent contenido = new StringContent(json, Encoding.UTF8, "application/json");
            solicitud.Content = contenido;
            Task<HttpResponseMessage> respuesta = cliente.SendAsync(solicitud);
            respuesta.Wait();

            if (respuesta.Result.IsSuccessStatusCode)
            {
                var objetoComoTexto = respuesta.Result.Content.ReadAsStringAsync().Result;
                var user = JsonConvert.DeserializeObject<TokenModel>(objetoComoTexto);
                HttpContext.Session.SetString("email", user.Usuario.Email);
                HttpContext.Session.SetString("token", user.Token);
                HttpContext.Session.SetString("rol", user.Rol);
                return RedirectToAction("Index", "Movimiento");
            }
            return RedirectToAction("Login", new { mensaje = "Username or password incorrect" });
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetString("token", "");
            HttpContext.Session.SetString("user", "");
            return RedirectToAction("Login", "Login", new {mensaje = "Bye bye" });
        }
    }
}
