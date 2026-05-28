using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KindLink.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<KindLink.Models.Organization> Organization { get; set; } = default!;
    public DbSet<KindLink.Models.VolunteerPosition> VolunteerPosition { get; set; } = default!;
 
}