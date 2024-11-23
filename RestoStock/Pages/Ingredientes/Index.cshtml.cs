using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStock.BaseDeDatos.Data;
using RestoStock.Models;

namespace RestoStock.Pages.Ingredientes
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly RestoStockContext _context;

        public IndexModel(RestoStockContext context)
        {
            _context = context;
        }

        public IList<Ingrediente> Ingredientes { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Ingredientes != null)
            {
                Ingredientes = await _context.Ingredientes.ToListAsync();
            }
        }
    }
}
