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
        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<RentCar> RentCard { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // ServicesPerAccomodations
            //builder.Entity<ServicesPerAccommodation>().HasKey(x => { x.AccommodationId, x.ServiceId});

            // Accommodation
            builder.Entity<Accommodation>().ToTable("accommodations");
            builder.Entity<Accommodation>().HasKey(p => p.Id);
            builder.Entity<Accommodation>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Accommodation>().Property(p => p.Details).IsRequired().HasMaxLength(200);
            builder.Entity<Accommodation>().Property(p => p.CheckIn).IsRequired();
            builder.Entity<Accommodation>().Property(p => p.CheckOut).IsRequired();
            builder.Entity<Accommodation>().Property(p => p.Location).IsRequired();
            builder.Entity<Accommodation>().Property(p => p.Price).IsRequired();
            builder.Entity<Accommodation>()
            .HasOne(p => p.Package)
            .WithOne(p => p.Accommodation)
            .HasForeignKey(p => p.AccommodationId);

            // RentCar
            builder.Entity<RentCar>().ToTable("rent_cars");
            builder.Entity<RentCar>().HasKey(p => p.Id);
            builder.Entity<RentCar>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<RentCar>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Entity<RentCar>().Property(p => p.Brand).IsRequired().HasMaxLength(100);
            builder.Entity<RentCar>().Property(p => p.Address).IsRequired().HasMaxLength(100);
            builder.Entity<RentCar>().Property(p => p.Capacity).IsRequired();
            builder.Entity<RentCar>().Property(p => p.Photo).IsRequired();
            builder.Entity<RentCar>().Property(p => p.Price).IsRequired();
            builder.Entity<RentCar>().Property(p => p.PickUpHour).IsRequired();
            builder.Entity<RentCar>().Property(p => p.DropOffHour).IsRequired();
            builder.Entity<RentCar>()
            .HasOne(p => p.Package)
            .WithOne(p => p.RentCar)
            .HasForeignKey(p => p.RentCarId);

            // Tours
            builder.Entity<Tour>().ToTable("tours");
            builder.Entity<Tour>().HasKey(p => p.Id);
            builder.Entity<Tour>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Tour>().Property(p => p.Details).IsRequired().HasMaxLength(200);
            builder.Entity<Tour>().Property(p => p.Location).IsRequired().HasMaxLength(100);
            builder.Entity<Tour>().Property(p => p.MeetingPoint).IsRequired().HasMaxLength(200); ;
            builder.Entity<Tour>().Property(p => p.Price).IsRequired();
            builder.Entity<Tour>()
            .HasOne(p => p.Package)
            .WithOne(p => p.Tour)
            .HasForeignKey(p => p.TourId);

            // PoliceStations
            builder.Entity<PoliceStation>().ToTable("police_stations");
            builder.Entity<PoliceStation>().HasKey(p => p.Id);
            builder.Entity<PoliceStation>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<PoliceStation>().Property(p => p.Name).IsRequired().HasMaxLength(200);
            builder.Entity<PoliceStation>().Property(p => p.Address).IsRequired().HasMaxLength(100);
            builder.Entity<PoliceStation>().Property(p => p.Phone).IsRequired().HasMaxLength(200); ;
            builder.Entity<PoliceStation>()
            .HasOne(p => p.Location)
            .WithOne(p => p.PoliceStation)
            .HasForeignKey(p => p.PoliceStationId);

            // HealthCenters
            builder.Entity<HealthCenter>().ToTable("health_centers");
            builder.Entity<HealthCenter>().HasKey(p => p.Id);
            builder.Entity<HealthCenter>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<HealthCenter>().Property(p => p.Type).IsRequired().HasMaxLength(200);
            builder.Entity<HealthCenter>().Property(p => p.Name).IsRequired().HasMaxLength(200);
            builder.Entity<HealthCenter>().Property(p => p.Address).IsRequired().HasMaxLength(100);
            builder.Entity<HealthCenter>().Property(p => p.Phone).IsRequired().HasMaxLength(200); ;
            builder.Entity<HealthCenter>()
            .HasOne(p => p.Location)
            .WithOne(p => p.HealthCenter)
            .HasForeignKey(p => p.HealthCenterId);

            // Reviews
            builder.Entity<Review>().ToTable("reviews");
            builder.Entity<Review>().HasKey(p => p.Id);
            builder.Entity<Review>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Review>().Property(p => p.Comment).IsRequired().HasMaxLength(200);
            builder.Entity<Review>().Property(p => p.Stars).IsRequired();
            builder.Entity<Review>()
            .HasOne(p => p.Package)
            .WithOne(p => p.Review)
            .HasForeignKey(p => p.ReviewId);
            builder.Entity<Review>()
            .HasOne(p => p.Traveler)
            .WithOne(p => p.Review)
            .HasForeignKey(p => p.ReviewId);

            // Location
            builder.Entity<Location>().ToTable("locations");
            builder.Entity<Location>().HasKey(p => p.Id);
            builder.Entity<Location>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Location>().Property(p => p.Department).IsRequired().HasMaxLength(100);
            builder.Entity<Location>().Property(p => p.Abrr).IsRequired().HasMaxLength(100);
            // Relationships
            builder.Entity<Location>()
                .HasMany(p => p.PoliceStations)
                .WithOne(p => p.Location)
                .HasForeignKey(p => p.LocationId);
            builder.Entity<Location>()
                .HasMany(p => p.HealthCenters)
                .WithOne(p => p.Location)
                .HasForeignKey(p => p.LocationId);
            builder.Entity<Location>()
                .HasMany(p => p.PoliceStations)
                .WithOne(p => p.Location)
                .HasForeignKey(p => p.LocationId);
            builder.Entity<Location>()
                .HasMany(p => p.PoliceStations)
                .WithOne(p => p.Location)
                .HasForeignKey(p => p.LocationId);

            // Travelers
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

            // Agencies
            builder.Entity<Agency>().ToTable("agencies");
            builder.Entity<Agency>().HasKey(p => p.Id);
            builder.Entity<Agency>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Agency>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Agency>().Property(p => p.Ruc).IsRequired().HasMaxLength(11);
            builder.Entity<Agency>().Property(p => p.Email).IsRequired().HasMaxLength(50);
            builder.Entity<Agency>().Property(p => p.Password).IsRequired().HasMaxLength(30);
        
        
            // Apply Snake Case Naming Convention
        
            builder.UseSnakeCaseNamingConvention();
        }
    }
}