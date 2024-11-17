using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStock.BaseDeDatos.Data;
using RestoStock.Models;

namespace RestoStock.Pages.Proveedores
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
        public Proveedor Proveedor { get; set; } = new Proveedor();

        // Obtener el proveedor a editar
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Buscar el proveedor en la base de datos
            Proveedor = await _context.Proveedores.FirstOrDefaultAsync(m => m.IdProveedor == id);

            if (Proveedor == null)
            {
                return NotFound();
            }

            return Page();
        }

        // Guardar los cambios del proveedor
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Buscar el proveedor a actualizar
            var proveedorToUpdate = await _context.Proveedores.FindAsync(Proveedor.IdProveedor);

            if (proveedorToUpdate == null)
            {
                return NotFound();
            }

            // Actualizar las propiedades
            proveedorToUpdate.NombreEmpresa = Proveedor.NombreEmpresa;
            proveedorToUpdate.Contacto = Proveedor.Contacto;
            proveedorToUpdate.Telefono = Proveedor.Telefono;
            proveedorToUpdate.Email = Proveedor.Email;
            proveedorToUpdate.Direccion = Proveedor.Direccion;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProveedorExists(Proveedor.IdProveedor))
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

        private bool ProveedorExists(int id)
        {
            return _context.Proveedores.Any(e => e.IdProveedor == id);
        }
    }
}
