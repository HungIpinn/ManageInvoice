using Microsoft.EntityFrameworkCore;
using ManageInvoice.Domain.Entities;

namespace ManageInvoice.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Invoice>(eb =>
            {
                eb.HasKey(i => i.Id);
                eb.Property(i => i.Number).IsRequired().HasMaxLength(50);
                eb.Property(i => i.Amount).HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<User>(eb =>
            {
                eb.HasKey(u => u.Id);
                eb.Property(u => u.FullName).HasMaxLength(200);
                eb.Property(u => u.Email).HasMaxLength(200);
            });
        }

        //public DbSet<Product> Products { get; set; }
    }
}
