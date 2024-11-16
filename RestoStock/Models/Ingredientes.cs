using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestoStock.Models
{
    public class Ingredientes
    {
        [Key]
        public int IdIngrediente {set; get;}
        public string Nombre {set; get;}
        public int CantidadDisponible {set; get;}
        public int UnidadMedida {set; get;}
        public int PrecioUnitario {set; get;}

        public ICollection<DetallesPlatos> DetallesPlatos {set; get;}


    }
}
