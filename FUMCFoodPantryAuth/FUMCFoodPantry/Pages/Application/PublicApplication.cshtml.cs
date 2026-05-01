using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FUMCFoodPantry.Data;

namespace FUMCFoodPantry.Pages.UserDatabase
{
    public class PublicApplicationModel : PageModel
    {
        private readonly FUMCFoodPantry.Data.ApplicationDbContext _context;

        public PublicApplicationModel(FUMCFoodPantry.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {

            UserApplications = new UserApplications
            {
                MemberId = GenerateUniqueMemberId()
            };

            EmploymentOptions = new List<SelectListItem>
        {
            new SelectListItem { Value = "Full Time", Text = "Full Time" },
            new SelectListItem { Value = "Part Time", Text = "Part Time" },
            new SelectListItem { Value = "Unemployed", Text = "Unemployed" },
            new SelectListItem { Value = "Retired", Text = "Retired" },
            new SelectListItem { Value = "Disabled", Text = "Disabled" },
        };
        HousingOptions = new List<SelectListItem>
        {
            new SelectListItem { Value = "Own", Text = "Own" },
            new SelectListItem { Value = "Rent", Text = "Rent" },
            new SelectListItem { Value = "Homeless", Text = "Homeless" },
            new SelectListItem { Value = "Transient", Text = "Transient" },
            new SelectListItem { Value = "At Risk of Being Homeless", Text = "At Risk of Being Homeless" },
        };
        YesOrNoOptions = new List<SelectListItem>
        {
            new SelectListItem { Value = "Yes", Text = "Yes" },
            new SelectListItem { Value = "No", Text = "No" }
        };
        GenderOptions = new List<SelectListItem>
        {
            new SelectListItem { Value = "Female", Text = "Female" },
            new SelectListItem { Value = "Male", Text = "Male" },
            new SelectListItem { Value = "Non-Binary", Text = "Non-Binary" },
            new SelectListItem { Value = "Other", Text = "Other" },
            new SelectListItem { Value = "Prefer not to say", Text = "Prefer not to say" }
        };
            return Page();
        }

        
    private int GenerateUniqueMemberId()
    {
        int id;
        do
        {
            id = Random.Shared.Next(100000, 999999);
        }
        while (_context.UserApplications.Any(u => u.MemberId == id));

        return id;
    }


        [BindProperty]
        public UserApplications UserApplications { get; set; } = default!;
        public List<SelectListItem> EmploymentOptions { get; set; }
        public List<SelectListItem> HousingOptions { get; set; }
        public List<SelectListItem> YesOrNoOptions { get; set; }
        public List<SelectListItem> ContactOptions { get; set; }
        public List<SelectListItem> GenderOptions { get; set; }
        public List<SelectListItem> DisabilityOptions { get; set; }
        public List<SelectListItem> MilOptions { get; set; }

        public List<string> SelectedRace { get; set; } = new();

        public List<string> AvailableRaces { get; set; } = new() { "White", "Black or African American", "Asian", "Hispanic, Latino, or Spanish", "Native American of Alaska Native", "Middle Eastern or North Africa", "Marshallese", "Native Hawaiian/Other Pacific", "Other Race or Ethnicity", "Prefer Not To Say"};

        public List<string> SelectedHousehold { get; set; } = new();

        public List<string> AvailableHousehold { get; set; } = new() { "Single Parent", "Adult Living Alone", "Disabled Household", "Milti-Generational Household"};

        public async Task<IActionResult> OnPostAsync()
{

    UserApplications.Race = string.Join(", ", SelectedRace);
    UserApplications.Household = string.Join(", ", SelectedHousehold);


    ModelState.Remove("UserApplications.Race");
    ModelState.Remove("UserApplications.Household");

    

    if (!ModelState.IsValid)
    {

        return Page();
    }

    _context.UserApplications.Add(UserApplications);
    await _context.SaveChangesAsync();
    return RedirectToPage("/Index");
}
    }
}
