using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Papeleria.LogicaAplicacion;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.CasosDeUso.Administradores;


namespace Papeleria.ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IFindUserByEmail _getUser;
        public LoginController(IFindUserByEmail getUser) { _getUser = getUser; }

        /// <summary>
        /// Metodo para permitir inicio de sesion y obtener un jwt para uso de la api
        /// </summary>
        /// <param name="usuario">nombre de usuario y contraseña</param>
        /// <returns>Token y datos del usuario</returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public ActionResult<UsuarioDTO> Login([FromBody] LoginDTO usuario)
        {
            try
            {
                ManejadorJwt handler = new ManejadorJwt(_getUser);
                var usr = handler.ObtenerUsuario(usuario.Email);
                if (usr == null || usr.PasswordSinEncript != usuario.Password)
                    return Unauthorized("Credenciales inválidas. Reintente");

                //Le pedimos al manejador de tokens que nos genere un token jwt con
                //la información del usuario para usar como claims (el email y el nombre de rol)
                //En caso de que se autentique, retorna el token y el usuario
                var token = ManejadorJwt.GenerarToken(usr);
                string rol = "Admin";
                if (usr.IsEncargado) rol = "Encargado";
                return Ok(new
                {
                    Token = token,
                    Email = usr.Email,
                    Rol = rol

                });
            }
            catch (Exception ex)
            {
                return Unauthorized(new
                {
                    Message = "Se produjo un error.Intente nuevamente" });
                }
            }

        }
    }
