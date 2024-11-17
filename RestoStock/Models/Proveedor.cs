using System.ComponentModel.DataAnnotations;

namespace RestoStock.Models
{
    public class Proveedor
    {
        [Key]
        public int IdProveedor { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreEmpresa { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Contacto { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string Telefono { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Direccion { get; set; } = string.Empty;

        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
