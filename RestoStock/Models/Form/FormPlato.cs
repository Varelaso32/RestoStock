using System.ComponentModel.DataAnnotations;

namespace RestoStock.Models.Form
{
    public class FormPlato
    {
        [Key]
        public int IdPlato { get; set; }
        public string Nombre { get; set; }
        public int PrecioVenta { get; set; }
        public string Descripcion { get; set; }
    }
}
