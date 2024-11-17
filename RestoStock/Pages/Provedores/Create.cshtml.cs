using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestoStock.Models;

namespace RestoStock.Pages.Proveedores
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Proveedor Proveedor { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Lógica para guardar el Proveedor en la base de datos
            return RedirectToPage("Index");
        }
    }
}
