using System.ComponentModel.DataAnnotations;

namespace RestoStock.Models
{
    public class Platos
    {
        [Key]
        public int IdPlato { get; set; }
        public int Nombre { get; set; }
        public int PrecioVenta { get; set; }
        public int Descripcion { get; set; }

        public ICollection<DetallesPlatos> DetallesPlatos { set; get; }
    }
}
