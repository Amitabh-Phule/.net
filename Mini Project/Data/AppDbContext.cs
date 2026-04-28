using LocalServiceFinder.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalServiceFinder.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Provider> Providers => Set<Provider>();
    public DbSet<Booking> Bookings => Set<Booking>();
    public DbSet<Review> Reviews => Set<Review>();

    public static async Task SeedAsync(AppDbContext context)
    {
        if (await context.Users.AnyAsync())
        {
            return;
        }

        var users = new List<User>
        {
            new User { Name = "Asha Patel", Email = "asha.patel@example.com" },
            new User { Name = "Rahul Singh", Email = "rahul.singh@example.com" }
        };

        var providers = new List<Provider>
        {
            new Provider { Name = "Clean House Service", ServiceType = "Cleaning", IsAvailable = true },
            new Provider { Name = "Quick Fix Plumbing", ServiceType = "Plumbing", IsAvailable = true },
            new Provider { Name = "Happy Home Electricians", ServiceType = "Electrician", IsAvailable = false }
        };

        await context.Users.AddRangeAsync(users);
        await context.Providers.AddRangeAsync(providers);
        await context.SaveChangesAsync();
    }
}
