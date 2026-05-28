using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KindLink.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<KindLink.Models.Organization> Category { get; set; } = default!;
    public DbSet<KindLink.Models.VolunteerPosition> Product { get; set; } = default!;
 
}