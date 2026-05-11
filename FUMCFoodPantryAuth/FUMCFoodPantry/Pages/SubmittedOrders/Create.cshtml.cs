using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FUMCFoodPantry.Data;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Authorization;

namespace FUMCFoodPantry.Pages.SubmittedOrders
{
    public class CreateModel : PageModel
    {
        private readonly FUMCFoodPantry.Data.ApplicationDbContext _context;

        public CreateModel(FUMCFoodPantry.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public List<BoxContent> MainBoxItems { get; set; } = new List<BoxContent>();
        public List<BoxContent> AltBoxItems { get; set; } = new List<BoxContent>();
        [BindProperty]
        public string UserName { get; set; } = string.Empty;

        public async Task OnGetAsync(string name)
        {
            var allItems = await _context.BoxContents.ToListAsync();
            
            MainBoxItems = allItems.Where(i => i.BoxType == "Main").ToList();
            AltBoxItems = allItems.Where(i => i.BoxType == "Alternative").ToList();
            UserName = name;
        }


        [BindProperty]
        public OrderForm OrderForm { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("OrderForm.Id");
            ModelState.Remove("OrderForm.Name");
            if (!ModelState.IsValid)
            {
                var allItems = await _context.BoxContents.ToListAsync();
                MainBoxItems = allItems.Where(i => i.BoxType == "Main").ToList();
                AltBoxItems = allItems.Where(i => i.BoxType == "Alternative").ToList();

                // Optional: Check 'errors' in your debugger to see why it's failing
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return Page();
            }
            Random res = new Random();
            int randomId = res.Next(100000, 1000000);

            // Assign it to your model (assuming your OrderForm has an Id property)
            OrderForm.Id = randomId;
            OrderForm.Name = UserName;

            _context.OrderForm.Add(OrderForm);
            await _context.SaveChangesAsync();

            return RedirectToPage("/InLine", new { id = randomId });
        }
    }
}
