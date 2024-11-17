using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestoStock.BaseDeDatos.Data;
using RestoStock.Models;
using RestoStock.Models.Form;

namespace RestoStock.Pages.DetallesPlatos
{
    public class EditModel : PageModel
    {
        private readonly RestoStockContext _context;

        public EditModel(RestoStockContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FormDetallesPlato DetallePlato { get; set; } = default!;

        public SelectList IngredientesList { get; set; }
        public SelectList PlatosList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallePlato = await _context.DetallesPlatos
                .Include(dp => dp.Ingrediente)
                .Include(dp => dp.Plato)
                .FirstOrDefaultAsync(m => m.IdDetalle == id);

            if (detallePlato == null)
            {
                return NotFound();
            }

            // Mapear datos del detalle de plato a FormDetallesPlato
            DetallePlato = new FormDetallesPlato
            {
                IdDetalle = detallePlato.IdDetalle,
                Cantidad = detallePlato.Cantidad,
                FkIngredientes = detallePlato.FkIngredientes,
                FkPlato = detallePlato.FkPlato
            };

            // Cargar ingredientes y platos
            await LoadIngredienteAndPlatos();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Si el modelo no es válido, recargar ingredientes y platos
                await LoadIngredienteAndPlatos();
                return Page();
            }

            var detallePlatoToUpdate = await _context.DetallesPlatos.FindAsync(DetallePlato.IdDetalle);

            if (detallePlatoToUpdate == null)
            {
                return NotFound();
            }

            // Actualizar el detalle de plato con los nuevos valores
            detallePlatoToUpdate.Cantidad = DetallePlato.Cantidad;
            detallePlatoToUpdate.FkIngredientes = DetallePlato.FkIngredientes;
            detallePlatoToUpdate.FkPlato = DetallePlato.FkPlato;

            try
            {
                // Guardar los cambios en la base de datos
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Detalle de plato editado exitosamente.";
                return RedirectToPage("./Index");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallesPlatoExists(DetallePlato.IdDetalle))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool DetallesPlatoExists(int id)
        {
            return _context.DetallesPlatos.Any(e => e.IdDetalle == id);
        }

        private async Task LoadIngredienteAndPlatos()
        {
            // Cargar ingredientes y platos desde la base de datos
            var ingredientes = await _context.Ingredientes.ToListAsync();
            IngredientesList = new SelectList(ingredientes, "IdIngrediente", "Nombre");

            var platos = await _context.Platos.ToListAsync();
            PlatosList = new SelectList(platos, "IdPlato", "Nombre");

            // Verificar si hay ingredientes o platos disponibles
            if (!ingredientes.Any() || !platos.Any())
            {
                ModelState.AddModelError("", "Debe haber al menos un ingrediente y un plato disponible.");
            }
        }
    }
}
