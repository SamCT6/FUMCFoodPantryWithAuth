using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FUMCFoodPantry.Data;

namespace FUMCFoodPantry.Pages.UserDatabase
{
    public class DeleteModel : PageModel
    {
        private readonly FUMCFoodPantry.Data.ApplicationDbContext _context;

        public DeleteModel(FUMCFoodPantry.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserApplications UserApplications { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userapplications = await _context.UserApplications.FirstOrDefaultAsync(m => m.Id == id);

            if (userapplications is not null)
            {
                UserApplications = userapplications;

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

            var userapplications = await _context.UserApplications.FindAsync(id);
            if (userapplications != null)
            {
                UserApplications = userapplications;
                _context.UserApplications.Remove(UserApplications);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
