using LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Administrador : Usuario
    { 
        public Administrador() { }
        public Administrador(int id, string nombre, string apellido, string email, string password)
        {
            Id = id;
            NombreCompleto = new NombreCompleto(nombre, apellido);
            this.Email = email;
            this.Password = password;
        }
        public Administrador(string nombre, string apellido, string email, string password) {
            NombreCompleto = new NombreCompleto(nombre, apellido);
            this.Email = email; 
            this.Password = password;
        }
    }
}
