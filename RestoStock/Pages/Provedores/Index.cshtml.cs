using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStock.BaseDeDatos.Data;
using RestoStock.Models;

namespace RestoStock.Pages.Proveedores
{
    public class IndexModel : PageModel
    {
        private readonly RestoStockContext _context;

        public IndexModel(RestoStockContext context)
        {
            _context = context;
        }

        public IList<Proveedor> Proveedores { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Proveedores != null)
            {

                Proveedores = await _context.Proveedores.ToListAsync();
            }
        }
    }
}
