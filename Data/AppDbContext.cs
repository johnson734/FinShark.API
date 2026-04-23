using FinShark.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinShark.API.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<IncomeTransaction> IncomeTransactions { get; set; }
        public DbSet<ExpenseTransaction> ExpenseTransactions { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<AuditTransaction> AuditTransactions { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Budget>()
                .HasIndex(x => new
                {
                    x.ApplicationUserId,
                    x.CategoryId,
                    x.Month,
                    x.Year
                }).IsUnique();

            builder.Entity<Budget>()
                .HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<ExpenseTransaction>()
             .HasOne(x => x.Category)
             .WithMany()
             .HasForeignKey(x => x.CategoryId)
             .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<IncomeTransaction>()
             .HasOne(x => x.Category)
             .WithMany()
             .HasForeignKey(x => x.CategoryId)
             .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
