using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects
{
    [Owned]
    public class Direccion
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
    }
}
