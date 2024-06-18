using Microsoft.AspNetCore.Mvc;

namespace WebDeposito.Models
{
    public class FechaModel 
    {
        public int Fecha {  get; set; }
        public List<TMovsModel> Movs { get; set; }
        public int Total { get; set; }
    }
}
