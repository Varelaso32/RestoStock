using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStock.BaseDeDatos.Data;
using RestoStock.Models.Form;

namespace RestoStock.Pages.Platos
{
    public class EditModel : PageModel
    {
        private readonly RestoStockContext _context;
        private readonly ILogger<EditModel> _logger;

        public EditModel(RestoStockContext context, ILogger<EditModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public FormPlato PlatoForm { get; set; } = new FormPlato();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Buscar el plato en la base de datos
            var plato = await _context.Platos.FirstOrDefaultAsync(m => m.IdPlato == id);

            if (plato == null)
            {
                return NotFound();
            }

            PlatoForm = new FormPlato
            {
                IdPlato = plato.IdPlato,
                Nombre = plato.Nombre,
                PrecioVenta = plato.PrecioVenta,
                Descripcion = plato.Descripcion,
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Buscar el plato a actualizar
            var platoToUpdate = await _context.Platos.FindAsync(PlatoForm.IdPlato);

            if (platoToUpdate == null)
            {
                return NotFound();
            }

            // Actualizar las propiedades
            platoToUpdate.Nombre = PlatoForm.Nombre;
            platoToUpdate.PrecioVenta = PlatoForm.PrecioVenta;
            platoToUpdate.Descripcion = PlatoForm.Descripcion;

            try
            {
                // Guardar los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlatoExists(PlatoForm.IdPlato))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // Redirigir al listado después de la edición
            return RedirectToPage("./Index");
        }

        private bool PlatoExists(int id)
        {
            return _context.Platos.Any(e => e.IdPlato == id);
        }
    }
}
