using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FUMCFoodPantry.Data;

namespace FUMCFoodPantry.Pages.SubmittedOrders
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
        public OrderForm OrderForm { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Random res = new Random();
            int randomId = res.Next(100000, 1000000);

            // Assign it to your model (assuming your OrderForm has an Id property)
            OrderForm.Id = randomId;

            _context.OrderForm.Add(OrderForm);
            await _context.SaveChangesAsync();

            return RedirectToPage("/InLine", new { id = randomId });
        }
    }
}
