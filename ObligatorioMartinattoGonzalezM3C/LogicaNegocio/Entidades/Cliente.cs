using LogicaNegocio.ValueObjects;
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
        public Direccion Direccion { get; set; }

        public Cliente() { }
        public Cliente(int id, string razonSocial, string rut, string nombre, string apellido, string nombreCalle, string numeroPuerta, string ciudad, double distanciaKm)
        {
            Id = id;
            RazonSocial = razonSocial;
            Rut = rut;
            NombreCliente = new NombreCliente(nombre, apellido);
            Direccion = new Direccion(nombreCalle, numeroPuerta, ciudad, distanciaKm);
        }
        public Cliente(string razonSocial, string rut, string nombre, string apellido, string nombreCalle, string numeroPuerta, string ciudad, double distanciaKm)
        {
            RazonSocial = razonSocial;
            Rut = rut;
            NombreCliente = new NombreCliente(nombre, apellido);
            Direccion = new Direccion(nombreCalle, numeroPuerta, ciudad, distanciaKm);
        }
    }
}
