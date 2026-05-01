using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FUMCFoodPantry.Data;

namespace FUMCFoodPantry.Pages_Inventory
{
    public class IndexModel : PageModel
    {
        private readonly FUMCFoodPantry.Data.ApplicationDbContext _context;

        public IndexModel(FUMCFoodPantry.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Stock> Stock { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Stock = await _context.Stock.ToListAsync();
        }
    }
}
