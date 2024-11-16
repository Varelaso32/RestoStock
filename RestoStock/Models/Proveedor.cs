using System.ComponentModel.DataAnnotations;

namespace RestoStock.Models
{
    public class Proveedor
    {
        [Key]
        public int IdProveedor { get; set; }
        public string NombreEmpresa { get; set; }
        public string Contacto { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }
    }
}
