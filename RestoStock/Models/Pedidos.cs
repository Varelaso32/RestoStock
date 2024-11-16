using System.ComponentModel.DataAnnotations;

namespace RestoStock.Models
{
    public class Pedidos
    {
        [Key]
        public int IdProveedor { get; set; }
        public string FechaPedido { get; set; }
        public int Total { get; set; }
        public int FkProveedor { get; set; }
        public Proveedores Proveedores { get; set; }
    }
}
