using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FUMCFoodPantry.Pages;

[Authorize(Roles = "Admin")]

public class AdminHomeModel : PageModel
{
    
    public void OnGet()
    {

    }
}
