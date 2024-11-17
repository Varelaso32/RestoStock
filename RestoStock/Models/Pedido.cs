using RestoStock.Models;
using System.ComponentModel.DataAnnotations;

public class Pedido
{
    [Key]
    public int IdPedido { get; set; }

    public string FechaPedido { get; set; }
    public int Total { get; set; }

    public int FkProveedor { get; set; }

    public Proveedor Proveedores { get; set; }


}
