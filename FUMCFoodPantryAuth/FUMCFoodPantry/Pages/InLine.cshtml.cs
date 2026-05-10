using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FUMCFoodPantry.Data;
using Microsoft.EntityFrameworkCore;

namespace FUMCFoodPantry.Pages
{
    public class InLineModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public InLineModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Properties to hold data for the HTML
        public OrderForm Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            // Find the order in the database
            Order = await _context.OrderForm.FirstOrDefaultAsync(m => m.Id == id);

            if (Order == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}