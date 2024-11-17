using RestoStock.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestoStock.BaseDeDatos.Data;
using Microsoft.EntityFrameworkCore;
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
            // Cargar la lista de proveedores para el dropdown
            Proveedores = new SelectList(await _context.Proveedores.ToListAsync(), "IdProveedor", "NombreEmpresa");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var pedido = new Pedido
            {
                FechaPedido = Pedido.FechaPedido,
                Total = Pedido.Total,
                FkProveedor = Pedido.FkProveedor
            };

            // Agregar el pedido a la base de datos
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            // Redirigir después de guardar el pedido
            return RedirectToPage("./Index");
        }
    }
}
