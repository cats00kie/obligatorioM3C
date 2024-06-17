namespace WebDeposito.Models
{
    public class MovimientoModel
    {
        public int Id { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public int ArticuloId { get; set; }
        public string NombreArticulo { get; set; }
        public int TipoMovimientoId { get; set; }
        public string NombreTMov { get; set; }
        public string EmailUsuario { get; set; }
        public int CantUnidades { get; set; }
    }
}
