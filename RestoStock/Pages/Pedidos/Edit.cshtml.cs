using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestoStock.BaseDeDatos.Data;
using RestoStock.Models;

namespace RestoStock.Pages.Pedidos
{
    public class EditModel : PageModel
    {
        private readonly RestoStockContext _context;

        public EditModel(RestoStockContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FormPedido FormPedido { get; set; } = default!;

        public SelectList ProveedoresList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.Proveedor)
                .FirstOrDefaultAsync(m => m.IdPedido == id);

            if (pedido == null)
            {
                return NotFound();
            }

            // Mapear datos del pedido a FormPedido
            FormPedido = new FormPedido
            {
                IdPedido = pedido.IdPedido,
                FechaPedido = pedido.FechaPedido,
                Total = pedido.Total,
                FkProveedor = pedido.FkProveedor
            };

            // Cargar lista de proveedores
            await LoadProveedores();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Recargar lista de proveedores si el modelo no es válido
                await LoadProveedores();
                return Page();
            }

            var pedidoToUpdate = await _context.Pedidos.FirstOrDefaultAsync(p => p.IdPedido == FormPedido.IdPedido);

            if (pedidoToUpdate == null)
            {
                return NotFound();
            }

            // Actualizar el pedido con los valores del formulario
            pedidoToUpdate.FechaPedido = FormPedido.FechaPedido;
            pedidoToUpdate.Total = FormPedido.Total;
            pedidoToUpdate.FkProveedor = FormPedido.FkProveedor;

            try
            {
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Pedido editado exitosamente.";
                return RedirectToPage("./Index");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(FormPedido.IdPedido))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.IdPedido == id);
        }

        private async Task LoadProveedores()
        {
            // Cargar lista de proveedores desde la base de datos
            var proveedores = await _context.Proveedores.ToListAsync();
            ProveedoresList = new SelectList(proveedores, "IdProveedor", "NombreEmpresa");

            // Validar si no hay proveedores disponibles
            if (!proveedores.Any())
            {
                ModelState.AddModelError("", "Debe haber al menos un proveedor disponible.");
            }
        }
    }
}
