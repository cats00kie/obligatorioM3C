namespace WebDeposito.Models
{
    public class MovimientoModel
    {
        public int Id { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public ArticuloModel Articulo { get; set; }
        public TipoMovimientoModel TipoMovimiento { get; set; }
        public string EmailUsuario { get; set; }
        public int CantUnidades { get; set; }
    }
}
