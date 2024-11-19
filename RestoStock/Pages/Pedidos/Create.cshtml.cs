using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestoStock.BaseDeDatos.Data;
using RestoStock.Models.Form;

namespace RestoStock.Pages.Pedidos
{
    public class CreateModel : PageModel
    {
        private readonly RestoStockContext _context;

        public CreateModel(RestoStockContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FormPedido Pedido { get; set; } = default!;

        public SelectList Proveedores { get; set; }

        public async Task OnGetAsync()
        {

            Proveedores = new SelectList(await _context.Proveedores.ToListAsync(), "IdProveedor", "NombreEmpresa");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Proveedores = new SelectList(await _context.Proveedores.ToListAsync(), "IdProveedor", "NombreEmpresa");
                return Page();
            }

            if (Pedido.FkProveedor == 0)
            {
                ModelState.AddModelError("Pedido.FkProveedor", "Debe seleccionar un proveedor.");
                Proveedores = new SelectList(await _context.Proveedores.ToListAsync(), "IdProveedor", "NombreEmpresa");
                return Page();
            }

            // Log para verificar el valor
            Console.WriteLine("FkProveedor: " + Pedido.FkProveedor);

            var pedido = new Pedido
            {
                FechaPedido = Pedido.FechaPedido,
                Total = Pedido.Total,
                FkProveedor = Pedido.FkProveedor
            };

            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();


            return RedirectToPage("./Index");
        }


    }
}
