using System.ComponentModel.DataAnnotations;

namespace RestoStock.Models.Form
{
    public class FormDetallesPlato
    {
        [Key]
        public int IdDetalle { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un ingrediente.")]
        public int FkIngredientes { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un plato.")]
        public int FkPlato { get; set; }
    }

}
