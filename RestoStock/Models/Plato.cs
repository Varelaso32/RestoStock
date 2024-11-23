using System.ComponentModel.DataAnnotations;

namespace RestoStock.Models
{
    public class Plato
    {
        [Key]
        public int IdPlato { get; set; }
        public string Nombre { get; set; }
        public int PrecioVenta { get; set; }
        public string Descripcion { get; set; }

        public ICollection<DetallesPlato> DetallesPlatos { set; get; }
    }
}
