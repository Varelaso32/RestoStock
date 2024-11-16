using System.ComponentModel.DataAnnotations;

namespace RestoStock.Models
{
    public class DetallesPlato
    {
        [Key]
        public int IdDetalle { get; set; }

        public int Cantidad { get; set; }

        public int FkIngredientes { get; set; }
        public Ingrediente Ingredientes { get; set; }

        public int FkPlato { get; set; }
        public Plato Platos { get; set; }
    }
}
