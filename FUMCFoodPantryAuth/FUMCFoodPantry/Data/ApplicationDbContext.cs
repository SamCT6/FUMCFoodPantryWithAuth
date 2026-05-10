using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Identity.Models; // Ensure this matches the namespace in AppUser.cs

namespace FUMCFoodPantry.Data;

// Change IdentityDbContext to IdentityDbContext<AppUser>
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
    : IdentityDbContext<AppUser>(options) 
{
    public DbSet<UserApplications> UserApplications { get; set; } = default!;
    public DbSet<Stock> Stock { get; set; } = default!;

    public DbSet<OrderForm> OrderForm { get; set; } = default!;

}