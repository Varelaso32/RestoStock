using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestoStock.BaseDeDatos.Data;
using RestoStock.Models;
using RestoStock.Models.Form;

namespace RestoStock.Pages.Platos
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
        public FormPlato Plato { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Platos == null || Plato == null)
            {
                return Page();
            }

            var nuevoPlato = new Plato
            {
                Nombre = Plato.Nombre,
                PrecioVenta = Plato.PrecioVenta,
                Descripcion = Plato.Descripcion
            };

            _context.Platos.Add(nuevoPlato);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
