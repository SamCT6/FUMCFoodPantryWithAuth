using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FUMCFoodPantry.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
{

public DbSet<UserApplications> UserApplications { get; set; } = default!;

public DbSet<Stock> Stock { get; set; } = default!;

public DbSet<User> User { get; set; } = default!;
}
