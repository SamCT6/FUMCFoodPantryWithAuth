using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FUMCFoodPantry.Models; // Ensure this matches your namespace for the BoxContent model

namespace FUMCFoodPantry.Pages;

public class EditBoxModel : PageModel
{
    private readonly FUMCFoodPantry.Data.ApplicationDbContext _context;

    public EditBoxModel(FUMCFoodPantry.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Stock> Stock { get; set; } = default!;

    // This property will catch the array of selected items from the form
    [BindProperty]
    public List<string> SelectedItem { get; set; }

    public async Task OnGetAsync()
    {
        Stock = await _context.Stock.ToListAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (SelectedItem == null || !SelectedItem.Any())
        {
            return Page();
        }

        // 1. Clear out the previous box configuration to "reset" the boxes
        var oldContents = await _context.BoxContents.ToListAsync();
        _context.BoxContents.RemoveRange(oldContents);

        // 2. Map the incoming SelectedItem list to your BoxContent table
        // Based on your HTML structure: 
        // Indices 0-3 are likely Main Box (1x Tier 1, 2x Tier 2, 1x Tier 3)
        // Indices 4-7 are likely Alternative Box (1x Tier 1, 2x Tier 2, 1x Tier 3)
        
        for (int i = 0; i < SelectedItem.Count; i++)
        {
            var newEntry = new BoxContent
            {
                ItemName = SelectedItem[i],
                BoxType = i < 4 ? "Main" : "Alternative" 
            };
            _context.BoxContents.Add(newEntry);
        }

        await _context.SaveChangesAsync();

        return RedirectToPage("./CheckIn");
    }
}