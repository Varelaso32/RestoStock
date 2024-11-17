using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStock.BaseDeDatos.Data;
using RestoStock.Models;

namespace RestoStock.Pages.DetallesPlatos
{
    public class DeleteModel : PageModel
    {
        private readonly RestoStockContext _context;

        public DeleteModel(RestoStockContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DetallesPlato DetallePlato { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DetallesPlatos == null)
            {
                return NotFound();
            }

            var detallePlato = await _context.DetallesPlatos
                .Include(d => d.Plato)  // Asume que hay una relación con la tabla Plato
                .Include(d => d.Ingrediente)  // Asume que hay una relación con la tabla Ingrediente
                .FirstOrDefaultAsync(m => m.IdDetalle == id);

            if (detallePlato == null)
            {
                return NotFound();
            }

            DetallePlato = detallePlato;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.DetallesPlatos == null)
            {
                return NotFound();
            }

            var detallePlato = await _context.DetallesPlatos.FindAsync(id);

            if (detallePlato == null)
            {
                return NotFound();
            }

            DetallePlato = detallePlato;

            try
            {
                _context.DetallesPlatos.Remove(DetallePlato);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Detalle de plato eliminado exitosamente.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error al eliminar el detalle de plato: " + ex.Message;
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
