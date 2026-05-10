using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FUMCFoodPantry.Data;

namespace FUMCFoodPantry.Pages.SubmittedOrders
{
    public class DeleteModel : PageModel
    {
        private readonly FUMCFoodPantry.Data.ApplicationDbContext _context;

        public DeleteModel(FUMCFoodPantry.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public OrderForm OrderForm { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderform = await _context.OrderForm.FirstOrDefaultAsync(m => m.Id == id);

            if (orderform is not null)
            {
                OrderForm = orderform;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderform = await _context.OrderForm.FindAsync(id);
            if (orderform != null)
            {
                OrderForm = orderform;
                _context.OrderForm.Remove(OrderForm);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
