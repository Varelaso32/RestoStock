using System.ComponentModel.DataAnnotations;

namespace RestoStock.Models.Form
{
    public class FormDetallesPlato
    {

        [Key]
        public int IdDetalle { get; set; }

        public int Cantidad { get; set; }

        public int FkIngredientes { get; set; }

        public int FkPlato { get; set; }

    }
}
