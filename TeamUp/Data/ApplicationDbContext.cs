using Microsoft.AspNetCore.Identity;
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

            const string adminId = "4af8fe0a-c109-41a3-a9aa-82cf40c65d89";
            const string visitorId = "4225e79b-688c-4f38-ae2c-b1b6d4dce7ab";

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = visitorId,
                    ConcurrencyStamp = visitorId,
                    Name = "Visitor",
                    NormalizedName = "VISITOR"
                },
                new IdentityRole
                {
                    Id = adminId,
                    ConcurrencyStamp = adminId,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            );

            const string baseUserId = "78759c27-9e8c-43d7-8375-6e930734b592";

            var baseUser = new IdentityUser
            {
                Id = baseUserId,
                Email = "nathjcollins@gmail.com",
                NormalizedEmail = "NATHJCOLLINS@GMAIL.COM",
                EmailConfirmed = true,
                UserName = "CentyPoo",
                NormalizedUserName = "CENTYPOO"
            };

            var passwordHasher = new PasswordHasher<IdentityUser>();
            baseUser.PasswordHash = passwordHasher.HashPassword(baseUser, "Test1234!");

            builder.Entity<IdentityUser>().HasData(baseUser);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>()
            {
                RoleId = adminId,
                UserId = baseUserId
            });
        }
    }
}