using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FUMCFoodPantry.Data;
using Microsoft.EntityFrameworkCore;

namespace FUMCFoodPantry.Pages_Inventory
{
    public class CreateModel : PageModel
    {
        private readonly FUMCFoodPantry.Data.ApplicationDbContext _context;

        public CreateModel(FUMCFoodPantry.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Stock Stock { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool exists = await _context.Stock.AnyAsync(s => s.Item == Stock.Item);

            if (exists)
            {
            ModelState.AddModelError(
                "Stock.Item",
                "This item already exists in inventory."
            );
            return Page();
            }

            _context.Stock.Add(Stock);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
