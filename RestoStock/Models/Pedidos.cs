namespace RestoStock.Models
{
    public class Pedidos
    {
        public int IdProveedor { get; set; }
        public string FechaPedido { get; set; }
        public double Total { get; set; }
        public int FkProveedor { get; set; }
        public Proveedores Proveedores { get; set; }
    }
}
