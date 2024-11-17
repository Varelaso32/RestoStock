using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestoStock.Models
{
    public class Ingrediente
    {
        [Key]
        public int IdIngrediente {set; get;}
        public string Nombre {set; get;}
        public int CantidadDisponible {set; get;}
        public string UnidadMedida {set; get;}
        public int PrecioUnitario {set; get;}

        public ICollection<DetallesPlato> DetallesPlatos {set; get;}


    }
}
