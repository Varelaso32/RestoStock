using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestoStock.BaseDeDatos.Data;

namespace RestoStock.Pages.Pedidos
{
    public class IndexModel : PageModel
    {
        private readonly RestoStockContext _context;

        public IndexModel(RestoStockContext context)
        {
            _context = context;
        }

        public IList<Pedido> Pedidos { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Pedidos != null)
            {
                Pedidos = await _context.Pedidos.Include(p => p.Proveedor).ToListAsync();
            }
        }
    }
}
