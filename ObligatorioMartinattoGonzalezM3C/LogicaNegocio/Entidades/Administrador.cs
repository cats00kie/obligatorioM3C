using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Administrador : Usuario
    {   
        public string Email { get; set; }
        public string Password { get; set; }
        public Administrador() { }
    }
}
