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
        public ActionResult<UsuarioDTO> Login([FromBody] UsuarioDTO usuario)
        {
            try
            {
                ManejadorJwt handler = new ManejadorJwt(_getUser);
                var usr = handler.ObtenerUsuario(usuario.Email);
                if (usr == null || usr.PasswordSinEncript != usuario.PasswordSinEncript)
                    return Unauthorized("Credenciales inválidas. Reintente");
                var token = ManejadorJwt.GenerarToken(usr);
                string rol = "Admin";
                if (usr.IsEncargado == true) rol = "Encargado";
                return Ok(new
                {
                    Token = token,
                    Usuario = usr,
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
