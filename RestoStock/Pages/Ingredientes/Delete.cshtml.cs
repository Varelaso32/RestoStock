using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStock.BaseDeDatos.Data;
using RestoStock.Models;

namespace RestoStock.Pages.Ingredientes
{
    public class DeleteModel : PageModel
    {
        private readonly RestoStockContext _context;

        public DeleteModel(RestoStockContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ingrediente Ingrediente { get; set; } = new Ingrediente();

        // Método para obtener el ingrediente a eliminar
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ingrediente = await _context.Ingredientes
                .FirstOrDefaultAsync(m => m.IdIngrediente == id);

            if (Ingrediente == null)
            {
                return NotFound();
            }

            return Page();
        }

        // Método para eliminar el ingrediente
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ingrediente = await _context.Ingredientes.FindAsync(id);

            if (Ingrediente != null)
            {
                _context.Ingredientes.Remove(Ingrediente);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
