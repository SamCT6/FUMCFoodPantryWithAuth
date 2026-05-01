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
    public class DetailsModel : PageModel
    {
        private readonly FUMCFoodPantry.Data.ApplicationDbContext _context;

        public DetailsModel(FUMCFoodPantry.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Stock Stock { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock.FirstOrDefaultAsync(m => m.Id == id);

            if (stock is not null)
            {
                Stock = stock;

                return Page();
            }

            return NotFound();
        }
    }
}
