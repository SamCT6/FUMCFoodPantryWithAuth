using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FUMCFoodPantry.Data;
using Microsoft.AspNetCore.Authorization;

namespace FUMCFoodPantry.Pages.SubmittedOrders
{
    [Authorize(Roles = "Admin, Volunteer")]
    public class IndexModel : PageModel
    {
        private readonly FUMCFoodPantry.Data.ApplicationDbContext _context;

        public IndexModel(FUMCFoodPantry.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<OrderForm> OrderForm { get;set; } = default!;

        public async Task OnGetAsync()
        {
            OrderForm = await _context.OrderForm.ToListAsync();
        }
    }
}
