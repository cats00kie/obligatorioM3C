using Papeleria.LogicaAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLogic.InterfacesUseCase
{
    public interface IGetUserByUsername
    {
        public UsuarioDTO FindUserByUsername(string email);
    }
}
