using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityPlayground;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>().Property(x => x.Nickname).HasMaxLength(30);

        builder.HasDefaultSchema("identity");
    }
}
