using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FUMCFoodPantry.Data;

namespace FUMCFoodPantry.Pages.UserDatabase
{
    public class EditModel : PageModel
    {
        private readonly FUMCFoodPantry.Data.ApplicationDbContext _context;

        public EditModel(FUMCFoodPantry.Data.ApplicationDbContext context)
        {
            _context = context;
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

        [BindProperty]
        public List<string> SelectedRaces { get; set; } = new();

        public List<string> AvailableRaces { get; set; } = new() { "White", "Black or African American", "Asian", "Hispanic, Latino, or Spanish", "Native American of Alaska Native", "Middle Eastern or North Africa", "Marshallese", "Native Hawaiian/Other Pacific", "Other Race or Ethnicity", "Prefer Not To Say"};
        [BindProperty]
        public List<string> SelectedHousehold { get; set; } = new();

        public List<string> AvailableHousehold { get; set; } = new() { "Single Parent", "Adult Living Alone", "Disabled Household", "Milti-Generational Household"};

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userapplications =  await _context.UserApplications.FirstOrDefaultAsync(m => m.Id == id);
            if (userapplications == null)
            {
                return NotFound();
            }
            UserApplications = userapplications;
            if (!string.IsNullOrEmpty(UserApplications.Race))
            {
                SelectedRaces = UserApplications.Race.Split(", ").ToList();
            }
            if (!string.IsNullOrEmpty(UserApplications.Household))
            {
                SelectedHousehold = UserApplications.Household.Split(", ").ToList();
            }

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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            
            UserApplications.Race = string.Join(", ", SelectedRaces);
            UserApplications.Household = string.Join(", ", SelectedHousehold);

            ModelState.Remove("UserApplications.Race");
            ModelState.Remove("UserApplications.Household");

            if (!ModelState.IsValid)
            {
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

            _context.Attach(UserApplications).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserApplicationsExists(UserApplications.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            
            return RedirectToPage("./Index");
        }

        private bool UserApplicationsExists(int id)
        {
            return _context.UserApplications.Any(e => e.Id == id);
        }
    }
}
