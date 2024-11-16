using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStock.BaseDeDatos.Data;
using RestoStock.Models;

namespace RestoStock.Pages.Platos
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly RestoStockContext _context;

        public IndexModel(RestoStockContext context)
        {
            _context = context;
        }

        public IList<Plato> Platos { get; set; } = default!;

        public async Task OnGetAsync()
        {
            // Cargar los platos desde la base de datos
            if (_context.Platos != null)
            {
                Platos = await _context.Platos.ToListAsync();
            }
        }
    }
}
