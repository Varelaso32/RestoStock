using System.ComponentModel.DataAnnotations;

namespace RestoStock.Models
{
    public class Proveedores
    {
        [Key]
        public int IdProveedor { get; set; }
        public string NombreEmpresa { get; set; }
        public string Contacto { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public ICollection<Pedidos> Pedidos { get; set; }
    }
}
