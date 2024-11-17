using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStock.BaseDeDatos.Data;
using RestoStock.Models;

namespace RestoStock.Pages.Platos
{
    public class DeleteModel : PageModel
    {
        private readonly RestoStockContext _context;

        public DeleteModel(RestoStockContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Plato Plato { get; set; } = new Plato();

        // Método para obtener el plato a eliminar
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Plato = await _context.Platos
                .FirstOrDefaultAsync(m => m.IdPlato == id);

            if (Plato == null)
            {
                return NotFound();
            }

            return Page();
        }

        // Método para eliminar el plato
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Plato = await _context.Platos.FindAsync(id);

            if (Plato != null)
            {
                _context.Platos.Remove(Plato);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
