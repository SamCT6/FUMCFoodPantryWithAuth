using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FUMCFoodPantry.Data;

namespace FUMCFoodPantry.Pages.PublicInventory
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Stock> Stock { get; set; } = new List<Stock>();

        public async Task OnGetAsync()
        {
            Stock = await _context.Stock
                .OrderBy(s => s.Item)
                .ToListAsync();
        }
    }
}