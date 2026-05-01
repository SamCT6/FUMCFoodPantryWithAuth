using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FUMCFoodPantry.Pages;

public class EditBoxModel : PageModel
{
    
        private readonly FUMCFoodPantry.Data.ApplicationDbContext _context;

        public EditBoxModel(FUMCFoodPantry.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Stock> Stock { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Stock = await _context.Stock.ToListAsync();
        }
    
}
