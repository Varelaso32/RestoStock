namespace RestoStock.Models.Form
{
    public class FormPedido
    {
        public int IdPedido { get; set; }

        public string FechaPedido { get; set; }
        public int Total { get; set; }

        public int FkProveedor { get; set; }


    }
}
