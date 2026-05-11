using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FUMCFoodPantry.Data;
using Microsoft.EntityFrameworkCore;

namespace FUMCFoodPantry.Pages;

public class MemberIdModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public MemberIdModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public int DisplayMemberId { get; set; }

    public void OnGet(int id)
    {

        DisplayMemberId = id;
    }
}
