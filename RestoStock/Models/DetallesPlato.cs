using System.ComponentModel.DataAnnotations;

namespace RestoStock.Models
{
    public class DetallesPlato
    {
        [Key]
        public int IdDetalle { get; set; }

        public int Cantidad { get; set; }

        public int FkIngredientes { get; set; }
        public Ingrediente Ingrediente { get; set; }

        public int FkPlato { get; set; }
        public Plato Plato { get; set; }
    }
}
