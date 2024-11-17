using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStock.BaseDeDatos.Data;
using RestoStock.Models;
using RestoStock.Models.Form;

namespace RestoStock.Pages.Ingredientes
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
        public FormIngrediente IngredienteForm { get; set; } = new FormIngrediente();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Buscar el ingrediente en la base de datos
            var ingrediente = await _context.Ingredientes.FirstOrDefaultAsync(m => m.IdIngrediente == id);

            if (ingrediente == null)
            {
                return NotFound();
            }

            // Mapear datos al modelo de formulario
            IngredienteForm = new FormIngrediente
            {
                IdIngrediente = ingrediente.IdIngrediente,
                Nombre = ingrediente.Nombre,
                CantidadDisponible = ingrediente.CantidadDisponible,
                UnidadMedida = ingrediente.UnidadMedida,
                PrecioUnitario = ingrediente.PrecioUnitario
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("Hola");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Buscar el ingrediente a actualizar
            var ingredienteToUpdate = await _context.Ingredientes.FindAsync(IngredienteForm.IdIngrediente);

            if (ingredienteToUpdate == null)
            {
                return NotFound();
            }

            // Actualizar las propiedades
            ingredienteToUpdate.Nombre = IngredienteForm.Nombre;
            ingredienteToUpdate.CantidadDisponible = IngredienteForm.CantidadDisponible;
            ingredienteToUpdate.UnidadMedida = IngredienteForm.UnidadMedida;
            ingredienteToUpdate.PrecioUnitario = IngredienteForm.PrecioUnitario;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredienteExists(IngredienteForm.IdIngrediente))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool IngredienteExists(int id)
        {
            return _context.Ingredientes.Any(e => e.IdIngrediente == id);
        }
    }
}
