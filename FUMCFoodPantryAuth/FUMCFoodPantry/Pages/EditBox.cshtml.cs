using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FUMCFoodPantry.Models; 

namespace FUMCFoodPantry.Pages;

public class EditBoxModel : PageModel
{
    private readonly FUMCFoodPantry.Data.ApplicationDbContext _context;

    public EditBoxModel(FUMCFoodPantry.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Stock> Stock { get; set; } = default!;

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

   
        var oldContents = await _context.BoxContents.ToListAsync();
        _context.BoxContents.RemoveRange(oldContents);

        
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

        return RedirectToPage("./AdminHome");
    }
}