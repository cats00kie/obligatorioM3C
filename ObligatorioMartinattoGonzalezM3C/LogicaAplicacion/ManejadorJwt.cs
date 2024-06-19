using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Papeleria.LogicaAplicacion.InterfacesCasosDeUso;
using Papeleria.LogicaAplicacion.DTOs;
using Papeleria.LogicaAplicacion.CasosDeUso.Administradores;

namespace Papeleria.LogicaAplicacion
{
    public class ManejadorJwt
    {
        private IFindUserByEmail _getUser;
        public ManejadorJwt(IFindUserByEmail getUser) { _getUser = getUser; }

        public static string GenerarToken(UsuarioDTO usuarioDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            //clave secreta, generalmente se incluye en el archivo de configuración
            //Debe ser un vector de bytes 

            var clave = Encoding.ASCII.GetBytes("ZWRpw6fDo28gZW0gY29tcHV0YWRvcmE=");

            //Se incluye un claim para el rol

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, usuarioDto.Email)
                }),
                Expires = DateTime.UtcNow.AddMonths(1),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(clave),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public UsuarioDTO ObtenerUsuario(string username)
        {
            {
                var usuario = this._getUser.FindUserByEmail(username);
                return usuario;

            }
        }
    }
}
