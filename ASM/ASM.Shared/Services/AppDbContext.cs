using ASM.Shared.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASM.Shared.Services
{
    public class AppDbContext : IdentityDbContext<User, Role, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Define your DbSets (tables) here
        public DbSet<Asset> Assets => Set<Asset>();
        public DbSet<AssetCategory> AssetCategories => Set<AssetCategory>();
        public DbSet<AssetStatusHistory> AssetStatusHistories => Set<AssetStatusHistory>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<Loan> Loans => Set<Loan>();
        public DbSet<MaintenanceLog> MaintenanceLogs => Set<MaintenanceLog>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);  

            modelBuilder.Entity<AssetCategory>()
                .HasOne(c => c.Parent)
                .WithMany(c => c.Children)
                .HasForeignKey(c => c.ParentId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<UserRole>()
                           .HasOne(ur => ur.User)
                           .WithMany(u => u.UserRoles)
                           .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);
        }
    }
}


