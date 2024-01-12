using Microsoft.EntityFrameworkCore;
using ManageInformation.Domain.Model;

namespace ManageInformation.Infrastructure.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Person> person { get; set; }
        public DbSet<MVD> mvd { get; set; }
        public DbSet<GIBDD> gibdd { get; set; }
        public DbSet<Nalogovaya> nalogi { get; set; }
        public DbSet<PFR> pfr { get; set; }
        public DbSet<Cars> cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasKey(pk => pk.Id);

            /*modelBuilder.Entity<Person>()
                .HasOne(p => p.MVD)
                .WithMany()
                .HasForeignKey(p => p.MVDId);

            modelBuilder.Entity<Person>()
                .HasOne(p => p.Nalogovaya)
                .WithMany()
                .HasForeignKey(p => p.NalogovayaId);

            modelBuilder.Entity<Person>()
                .HasOne(p => p.GIBDD)
                .WithMany()
                .HasForeignKey(p => p.GIBDDId);

            modelBuilder.Entity<Person>()
                .HasOne(p => p.PFR)
                .WithMany()
                .HasForeignKey(p => p.PFRId);*/

           /* modelBuilder.Entity<Cars>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Cars>()
                .HasOne(c => c.OwnerLicense)
                .WithMany(g => g.Cars)
                .HasForeignKey(c => c.OwnerLicenseId);*/

            modelBuilder.Entity<MVD>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Nalogovaya>()
                .HasKey(n => n.Id);

            modelBuilder.Entity<PFR>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<GIBDD>()
                .HasKey(g => g.Id);

            /*modelBuilder.Entity<GIBDD>()
                .HasMany(g => g.Cars)
                .WithOne(c => c.OwnerLicense)
                .HasForeignKey(c => c.OwnerLicenseId);*/
        }
    }
}
