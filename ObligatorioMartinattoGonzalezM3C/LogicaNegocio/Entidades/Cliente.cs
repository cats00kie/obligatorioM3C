using Papeleria.LogicaNegocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Cliente
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; }
        public string RazonSocial {  get; set; }
        public string Rut {  get; set; }
        public NombreCliente NombreCliente { get; set; }

        public Cliente() { }
        public Cliente(int id, string razonSocial, string rut, string nombre, string apellido)
        {
            Id = id;
            RazonSocial = razonSocial;
            Rut = rut;
            NombreCliente = new NombreCliente(nombre, apellido);
        }
        public Cliente(string razonSocial, string rut, string nombre, string apellido)
        {
            RazonSocial = razonSocial;
            Rut = rut;
            NombreCliente = new NombreCliente(nombre, apellido);
        }
    }
}
