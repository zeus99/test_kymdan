using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using test_kymdan.Data.Models;

namespace test_kymdan.Models
{
    public class todo3dbcontext : IdentityDbContext<User>
    {
        public todo3dbcontext(DbContextOptions<todo3dbcontext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(users =>
            {
                users.HasMany(x => x.Claims)
                    .WithOne()
                    .HasForeignKey(x => x.UserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                users.ToTable("Users").Property(p => p.Id).HasColumnName("UserId");
            });

            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");

        }
        
    }
}
