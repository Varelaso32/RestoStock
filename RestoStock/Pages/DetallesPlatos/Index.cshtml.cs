using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStock.BaseDeDatos.Data;
using RestoStock.Models;

namespace RestoStock.Pages.DetallesPlatos
{
    public class IndexModel : PageModel
    {
        private readonly RestoStockContext _context;

        public IndexModel(RestoStockContext context)
        {
            _context = context;
        }

        public IList<DetallesPlato> DetallesPlatos { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.DetallesPlatos != null)
            {
                DetallesPlatos = await _context.DetallesPlatos
                    .Include(dp => dp.Ingredientes) 
                    .Include(dp => dp.Platos)      
                    .ToListAsync();
            }
        }
    }
}
