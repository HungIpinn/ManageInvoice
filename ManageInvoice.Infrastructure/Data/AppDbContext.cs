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
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Invoice>(eb =>
            {
                eb.HasKey(i => i.Id);
                eb.Property(i => i.Number).IsRequired().HasMaxLength(50);
                eb.Property(i => i.Amount).HasColumnType("decimal(18,2)");
                eb.Property(i => i.AddressId)
                    .HasDefaultValueSql("NEWID()");
                // one-to-many: User -> Invoice
                eb.HasOne(i => i.User)
                    .WithMany(u => u.Invoices)
                    .HasForeignKey(u => u.UserId)
                    .OnDelete(DeleteBehavior.NoAction);
                // one to one: Invoice -> Address
                eb.HasOne(i=>i.Address)
                    .WithOne(a=>a.Invoice)
                    .HasForeignKey<Invoice>(a=>a.AddressId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<User>(eb =>
            {
                eb.HasKey(u => u.Id);
                eb.Property(u => u.FullName).HasMaxLength(200);
                eb.Property(u => u.Email).HasMaxLength(200);
            });

            modelBuilder.Entity<Address>(eb =>
            {
                eb.HasKey(u => u.Id);
                eb.Property(u=>u.ProvinceName).HasMaxLength(200);
                eb.Property(u=>u.AddressName).HasMaxLength(200);

                // one to many: User -> Adress
                eb.HasOne(a=>a.User)
                    .WithMany(x=>x.Addresses)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
