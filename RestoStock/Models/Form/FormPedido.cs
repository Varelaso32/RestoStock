using System.ComponentModel.DataAnnotations;

public class FormPedido
{
    [Key]
    public int IdPedido { get; set; }
    public string FechaPedido { get; set; }

    [Required(ErrorMessage = "Debe ingresar el total.")]
    public int Total { get; set; }

    [Required(ErrorMessage = "Debe seleccionar un proveedor.")]
    public int FkProveedor { get; set; } 
}
