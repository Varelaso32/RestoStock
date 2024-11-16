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

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FormIngrediente Ingrediente { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Ingredientes == null || Ingrediente == null)
            {
                return Page();
            }

            var ingrediente = new Ingrediente
            {
                Nombre = Ingrediente.Nombre,
                CantidadDisponible = Ingrediente.CantidadDisponible,
                UnidadMedida = Ingrediente.UnidadMedida,
                PrecioUnitario = Ingrediente.PrecioUnitario,
            };

            _context.Ingredientes.Add(ingrediente);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
