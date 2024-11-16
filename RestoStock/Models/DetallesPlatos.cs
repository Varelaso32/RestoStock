using System.ComponentModel.DataAnnotations;

namespace RestoStock.Models
{
    public class DetallesPlatos
    {
        [Key]
        public int IdDetalle { get; set; }

        public int Cantidad { get; set; }

        public int FkIngredientes { get; set; }
        public Ingredientes Ingredientes { get; set; }

        public int FkPlato { get; set; }
        public Platos Platos { get; set; }
    }
}
