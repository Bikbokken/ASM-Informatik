using ASM.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace ASM.Shared.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Define your DbSets (tables) here
        public DbSet<Asset> Assets => Set<Asset>();
        public DbSet<AssetCategory> AssetCategories => Set<AssetCategory>();
        public DbSet<AssetStatusHistory> AssetStatusHistories => Set<AssetStatusHistory>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<Loan> Loans => Set<Loan>();
        public DbSet<MaintenanceLog> MaintenanceLogs => Set<MaintenanceLog>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetCategory>()
                .HasOne(c => c.Parent)
                .WithMany(c => c.Children)
                .HasForeignKey(c => c.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}


