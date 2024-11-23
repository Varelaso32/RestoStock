using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStock.BaseDeDatos.Data;
using RestoStock.Models;

namespace RestoStock.Pages.Pedidos
{
    public class DeleteModel : PageModel
    {
        private readonly RestoStockContext _context;

        public DeleteModel(RestoStockContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pedido Pedido { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Pedido = await _context.Pedidos
                .Include(p => p.Proveedor)  
                .FirstOrDefaultAsync(m => m.IdPedido == id);

            if (Pedido == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Pedido = await _context.Pedidos.FindAsync(id);

            if (Pedido != null)
            {
                _context.Pedidos.Remove(Pedido);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
