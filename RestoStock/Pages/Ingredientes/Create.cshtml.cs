using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestoStock.BaseDeDatos.Data;
using RestoStock.Models;
using RestoStock.Models.Form;

namespace RestoStock.Pages.Ingredientes
{
    public class CreateModel : PageModel
    {
        private readonly RestoStockContext _context;

        public CreateModel(RestoStockContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FormIngrediente Ingrediente { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Ingrediente == null)
            {
                TempData["ErrorMessage"] = "Por favor, corrija los errores en el formulario antes de continuar.";
                return Page();
            }

            try
            {
                var ingrediente = new Ingrediente
                {
                    Nombre = Ingrediente.Nombre,
                    CantidadDisponible = Ingrediente.CantidadDisponible,
                    UnidadMedida = Ingrediente.UnidadMedida,
                    PrecioUnitario = Ingrediente.PrecioUnitario,
                };

                _context.Ingredientes.Add(ingrediente);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Ingrediente creado exitosamente.";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Ocurrió un error al guardar el ingrediente. Inténtelo de nuevo.";
                Console.WriteLine($"Error: {ex.Message}");
                return Page();
            }
        }
    }
}
