using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

// namespace for the context
namespace DreamTrip.DreamTrip.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
    
		public DbSet<Traveler> Travelers { get; set; }
    	public DbSet<Agency> Agencies { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Traveler>().ToTable("travelers");
            builder.Entity<Traveler>().HasKey(p => p.Id);
            builder.Entity<Traveler>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Traveler>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Traveler>().Property(p => p.Lastname).IsRequired().HasMaxLength(50);
            builder.Entity<Traveler>().Property(p => p.Email).IsRequired().HasMaxLength(50);
            builder.Entity<Traveler>().Property(p => p.Password).IsRequired().HasMaxLength(30);
            builder.Entity<Traveler>().Property(p => p.Phone).IsRequired().HasMaxLength(9);
            builder.Entity<Traveler>().Property(p => p.Dni).IsRequired().HasMaxLength(8);
            builder.Entity<Traveler>().Property(p => p.Photo);
            //
            // // Relationships
            // builder.Entity<Category>()
            //     .HasMany(p => p.Tutorials)
            //     .WithOne(p => p.Category)
            //     .HasForeignKey(p => p.CategoryId);
            //
            builder.Entity<Agency>().ToTable("agencies");
            builder.Entity<Agency>().HasKey(p => p.Id);
            builder.Entity<Agency>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Agency>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Agency>().Property(p => p.Ruc).HasMaxLength(3);
            builder.Entity<Agency>().Property(p => p.Email).HasMaxLength(50);
            builder.Entity<Agency>().Property(p => p.Password).HasMaxLength(30);
        
        
            // Apply Snake Case Naming Convention
        
            builder.UseSnakeCaseNamingConvention();
        }
    }
}