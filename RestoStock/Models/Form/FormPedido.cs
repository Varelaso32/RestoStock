using System.ComponentModel.DataAnnotations;

public class FormPedido
{
    public String FechaPedido { get; set; }

    [Required(ErrorMessage = "Debe ingresar el total.")]
    public int Total { get; set; }

    [Required(ErrorMessage = "Debe seleccionar un proveedor.")]
    public int FkProveedor { get; set; } 
}
