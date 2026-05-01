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
    public class SpanishUserApplicationModel : PageModel
    {
        private readonly FUMCFoodPantry.Data.ApplicationDbContext _context;

        public SpanishUserApplicationModel(FUMCFoodPantry.Data.ApplicationDbContext context)
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
            new SelectListItem { Value = "Full Time", Text = "Jornada completa" },
            new SelectListItem { Value = "Part Time", Text = "Tiempo parcial" },
            new SelectListItem { Value = "Unemployed", Text = "Desempleados" },
            new SelectListItem { Value = "Retired", Text = "Jubilado" },
            new SelectListItem { Value = "Disabled", Text = "Desactivado" },
        };
        HousingOptions = new List<SelectListItem>
        {
            new SelectListItem { Value = "Own", Text = "Propio" },
            new SelectListItem { Value = "Rent", Text = "Alquilar" },
            new SelectListItem { Value = "Homeless", Text = "Sin hogar" },
            new SelectListItem { Value = "Transient", Text = "Transitorio" },
            new SelectListItem { Value = "At Risk of Being Homeless", Text = "En riesgo de quedarse sin hogar" },
        };
        YesOrNoOptions = new List<SelectListItem>
        {
            new SelectListItem { Value = "Yes", Text = "Sí" },
            new SelectListItem { Value = "No", Text = "No" }
        };
        GenderOptions = new List<SelectListItem>
        {
            new SelectListItem { Value = "Female", Text = "Femenino" },
            new SelectListItem { Value = "Male", Text = "Masculino" },
            new SelectListItem { Value = "Non-Binary", Text = "No binario" },
            new SelectListItem { Value = "Other", Text = "Otro" },
            new SelectListItem { Value = "Prefer not to say", Text = "Prefiero no decirlo" }
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

        public List<string> AvailableRaces { get; set; } = new() { "Blanco", "Negro o afroamericano", "Asiático", "Hispano, latino o de origen español", "Nativo americano o nativo de Alaska", "De Oriente Medio o del norte de África", "Marshallés", "Nativo hawaiano u otro isleño del Pacífico", "Otra raza o etnia", "Prefiero no decirlo"};

        public List<string> SelectedHousehold { get; set; } = new();

        public List<string> AvailableHousehold { get; set; } = new() { "Padre o madre soltero/a", "Adulto que vive solo", "Hogar discapacitado", "Hogar multigeneracional"};

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
