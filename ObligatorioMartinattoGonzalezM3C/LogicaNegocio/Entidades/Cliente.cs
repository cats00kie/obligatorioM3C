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
    }
}
