using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestoStock.BaseDeDatos.Data;
using RestoStock.Models;
using RestoStock.Models.Form;

namespace RestoStock.Pages.DetallesPlatos
{
    public class CreateModel : PageModel
    {
        private readonly RestoStockContext _context;

        public CreateModel(RestoStockContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FormDetallesPlato DetallePlato { get; set; } = default!;

        public SelectList IngredientesList { get; set; }
        public SelectList PlatosList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
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


            var detallePlato = new DetallesPlato
            {
                Cantidad = DetallePlato.Cantidad,
                FkIngredientes = DetallePlato.FkIngredientes,
                FkPlato = DetallePlato.FkPlato
            };

            // Guardar el nuevo detalle en la base de datos
            _context.DetallesPlatos.Add(detallePlato);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Detalle de plato creado exitosamente.";
            return RedirectToPage("./Index");
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
