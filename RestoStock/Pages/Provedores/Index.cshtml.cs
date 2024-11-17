using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RestoStock.Pages.Provedores
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }

    }
}
