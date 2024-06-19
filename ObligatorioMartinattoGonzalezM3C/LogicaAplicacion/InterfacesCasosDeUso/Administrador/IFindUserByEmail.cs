using Papeleria.LogicaAplicacion.DTOs;

namespace Papeleria.LogicaAplicacion.CasosDeUso.Administradores
{
    public interface IFindUserByEmail
    {
        UsuarioDTO FindUserByEmail(string email);
    }
}