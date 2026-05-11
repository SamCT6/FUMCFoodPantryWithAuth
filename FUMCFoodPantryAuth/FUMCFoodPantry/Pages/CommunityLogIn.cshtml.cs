using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FUMCFoodPantry.Pages;

public class CommunityLogInModel : PageModel
{
    [BindProperty]
    public string UserID { get; set; }
    private readonly FUMCFoodPantry.Data.ApplicationDbContext _context;

    public CommunityLogInModel(FUMCFoodPantry.Data.ApplicationDbContext context)
    {
        _context = context;
    }

    public void OnGet() 
    {
    }
    public async Task<IActionResult> OnPostAsync()
{
    if (string.IsNullOrEmpty(UserID))
    {
        return Page();
    }


    if (!int.TryParse(UserID, out int idAsInt))
    {
        ModelState.AddModelError("UserID", "Please enter a valid numeric ID.");
        return Page();
    }

    var item = await _context.UserApplications
        .FirstOrDefaultAsync(u => u.MemberId == idAsInt);

    if (item == null)
    {
        ModelState.AddModelError("UserID", "No ID found. Please check your number and try again.");
        return Page();
    }

    return RedirectToPage("/SubmittedOrders/Create", new { 
        name = $"{item.FirstName} {item.LastName}" });
}

}

