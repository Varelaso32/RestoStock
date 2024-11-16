using System.ComponentModel.DataAnnotations;

namespace RestoStock.Models
{
    public class Plato
    {
        [Key]
        public int IdPlato { get; set; }
        public int Nombre { get; set; }
        public int PrecioVenta { get; set; }
        public int Descripcion { get; set; }

        public ICollection<DetallesPlato> DetallesPlatos { set; get; }
    }
}
