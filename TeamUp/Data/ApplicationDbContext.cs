using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeamUp.Data.Models;

namespace TeamUp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Platform> Platforms { get; set; } = null!;
        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<GamePlatform> GamePlatforms { get; set; } = null!;
        public DbSet<Position> Positions { get; set; } = null!;
        public DbSet<Rank> Ranks { get; set; } = null!;
        public DbSet<UserGameProfile> UserGameProfiles { get; set; } = null!;
        public DbSet<UserGameProfilePosition> UserGameProfilePositions { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}