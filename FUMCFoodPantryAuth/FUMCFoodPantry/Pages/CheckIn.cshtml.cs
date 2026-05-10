using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FUMCFoodPantry.Pages;

public class CheckInModel : PageModel
{
    private readonly FUMCFoodPantry.Data.ApplicationDbContext _context;

    public CheckInModel(FUMCFoodPantry.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public List<BoxContent> MainBoxItems { get; set; }
    public List<BoxContent> AltBoxItems { get; set; }

    public async Task OnGetAsync()
    {
        var allItems = await _context.BoxContents.ToListAsync();
        MainBoxItems = allItems.Where(i => i.BoxType == "Main").ToList();
        AltBoxItems = allItems.Where(i => i.BoxType == "Alternative").ToList();
    }
}