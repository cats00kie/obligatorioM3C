using Microsoft.EntityFrameworkCore;
using Papeleria.LogicaNegocio.Excepciones;
using Papeleria.LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    [Owned]
    public class Direccion : IValid
    {
        public string NombreCalle {  get; private set; }
        public string NumeroPuerta { get; private set; }
        public string Ciudad { get; private set; }
        public double DistanciaKm { get; private set; }
        public Direccion(string nombreCalle, string numeroPuerta, string ciudad, double distanciaKm)
        {
            NombreCalle = nombreCalle;
            NumeroPuerta = numeroPuerta;
            Ciudad = ciudad;
            DistanciaKm = distanciaKm;
        }

        public void IsValid()
        {
            if (DistanciaKm < 0) throw new DireccionNoValidaException("Distancia negativa.");
            if (!int.TryParse(NumeroPuerta, out int x)) throw new DireccionNoValidaException("Numero de puerta invalido");
        }
    }
}
