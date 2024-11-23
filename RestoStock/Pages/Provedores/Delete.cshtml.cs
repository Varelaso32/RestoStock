using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStock.BaseDeDatos.Data;
using RestoStock.Models;

namespace RestoStock.Pages.Proveedores
{
    public class DeleteModel : PageModel
    {
        private readonly RestoStockContext _context;

        public DeleteModel(RestoStockContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Proveedor Proveedor { get; set; } = new Proveedor();

        // Método para obtener el proveedor a eliminar
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Proveedor = await _context.Proveedores
                .FirstOrDefaultAsync(m => m.IdProveedor == id);

            if (Proveedor == null)
            {
                return NotFound();
            }

            return Page();
        }

        // Método para eliminar el proveedor
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Proveedor = await _context.Proveedores.FindAsync(id);

            if (Proveedor != null)
            {
                _context.Proveedores.Remove(Proveedor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
