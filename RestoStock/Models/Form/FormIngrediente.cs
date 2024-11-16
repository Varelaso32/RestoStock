using System.ComponentModel.DataAnnotations;

namespace RestoStock.Models.Form
{
    public class FormIngrediente
    {
        [Key]
        public int IdIngrediente { set; get; }
        public string Nombre { set; get; }
        public int CantidadDisponible { set; get; }
        public int UnidadMedida { set; get; }
        public int PrecioUnitario { set; get; }
    }
}
