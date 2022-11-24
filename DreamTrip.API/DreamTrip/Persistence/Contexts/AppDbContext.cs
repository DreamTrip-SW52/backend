using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

// namespace for the context
namespace DreamTrip.API.DreamTrip.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<HealthCenter> HealthCenters { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<OneWay> OneWays { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PoliceStation> PoliceStations { get; set; }
        public DbSet<PurchasedPackage> PurchasedPackages { get; set; }
        public DbSet<RentCar> RentCars { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<RoundTrip> RoundTrips { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServicesPerAccommodation> ServicesPerAccommodations { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<TransportClass> TransportClasses { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<AgencyCard> AgencyCards { get; set; }
        public DbSet<TravelerCard> TravelerCards { get; set; }
        public DbSet<Traveler> Travelers { get; set; }
        public DbSet<TripBack> TripsBack { get; set; }
        public DbSet<TripGo> TripsGo { get; set; }
        public DbSet<EconomicFollowing> EconomicFollowings { get; set; }
        public DbSet<CustomPackage> CustomPackages { get; set; }

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
            builder.Entity<Accommodation>().Property(p => p.Details).IsRequired();
            builder.Entity<Accommodation>().Property(p => p.CheckIn).IsRequired();
            builder.Entity<Accommodation>().Property(p => p.CheckOut).IsRequired();
            builder.Entity<Accommodation>().Property(p => p.Location).IsRequired();
            builder.Entity<Accommodation>().Property(p => p.Price).IsRequired();
            // Relationship (One to One)
            builder.Entity<Accommodation>()
                .HasOne(p => p.Package)
                .WithOne(p => p.Accommodation)
                .HasForeignKey<Accommodation>(p => p.PackageId);
            // Relationship (One to Many)
            builder.Entity<Accommodation>()
                .HasMany(p => p.ServicesPerAccommodations)
                .WithOne(p => p.Accommodation)
                .HasForeignKey(p => p.AccommodationId);
            builder.Entity<Accommodation>()
                .HasMany(p => p.CustomPackages)
                .WithOne(p => p.Accommodation)
                .HasForeignKey(p => p.AccommodationId);

            // Health Center
            builder.Entity<HealthCenter>().ToTable("health_centers");
            builder.Entity<HealthCenter>().HasKey(p => p.Id);
            builder.Entity<HealthCenter>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<HealthCenter>().Property(p => p.Type).IsRequired().HasMaxLength(50);
            builder.Entity<HealthCenter>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<HealthCenter>().Property(p => p.Address).IsRequired();
            builder.Entity<HealthCenter>().Property(p => p.Phone).IsRequired().HasMaxLength(9);
            // Relationship (Many to One)
            builder.Entity<HealthCenter>()
                .HasOne(p => p.Location)
                .WithMany(p => p.HealthCenters)
                .HasForeignKey(p => p.LocationId);

            // Location
            builder.Entity<Location>().ToTable("locations");
            builder.Entity<Location>().HasKey(p => p.Id);
            builder.Entity<Location>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Location>().Property(p => p.Department).IsRequired().HasMaxLength(40);
            builder.Entity<Location>().Property(p => p.Abbr).IsRequired().HasMaxLength(10);
            // Relationships (One to Many)
            builder.Entity<Location>()
                .HasMany(p => p.PoliceStations)
                .WithOne(p => p.Location)
                .HasForeignKey(p => p.LocationId);
            builder.Entity<Location>()
                .HasMany(p => p.HealthCenters)
                .WithOne(p => p.Location)
                .HasForeignKey(p => p.LocationId);
            builder.Entity<Location>()
                .HasMany(p => p.Packages)
                .WithOne(p => p.Location)
                .HasForeignKey(p => p.LocationId);
            builder.Entity<Location>()
                .HasMany(p => p.TripsBack)
                .WithOne(p => p.Location)
                .HasForeignKey(p => p.LocationId);
            builder.Entity<Location>()
                .HasMany(p => p.TripsGo)
                .WithOne(p => p.Location)
                .HasForeignKey(p => p.LocationId);
            builder.Entity<Location>()
                .HasMany(p => p.CustomPackages)
                .WithOne(p => p.Location)
                .HasForeignKey(p => p.LocationId);

            // OneWay
            builder.Entity<OneWay>().ToTable("one_way");
            builder.Entity<OneWay>().HasKey(p => p.Id);
            builder.Entity<OneWay>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<OneWay>().Property(p => p.Price).IsRequired();
            builder.Entity<OneWay>().Property(p => p.DepartureDate).IsRequired();
            builder.Entity<OneWay>().Property(p => p.ReturnDate).IsRequired();
            // Relationships (One to One)
            builder.Entity<OneWay>()
                .HasOne(p => p.Package)
                .WithOne(p => p.OneWay)
                .HasForeignKey<OneWay>(p => p.PackageId);
            builder.Entity<OneWay>()
                .HasOne(p => p.TransportClass)
                .WithOne(p => p.OneWay)
                .HasForeignKey<OneWay>(p => p.TransportClassId);
            builder.Entity<OneWay>()
                .HasOne(p => p.TripGo)
                .WithOne(p => p.OneWay)
                .HasForeignKey<OneWay>(p => p.TripGoId);
            // Relationship (Many to One)
            builder.Entity<OneWay>()
                .HasOne(p => p.Transport)
                .WithMany(p => p.OneWays)
                .HasForeignKey(p => p.TransportId);
            // Relationship (One to Many)
            builder.Entity<OneWay>()
                .HasMany(p => p.CustomPackages)
                .WithOne(p => p.OneWay)
                .HasForeignKey(p => p.OneWayId);

            // Package
            builder.Entity<Package>().ToTable("packages");
            builder.Entity<Package>().HasKey(p => p.Id);
            builder.Entity<Package>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Package>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Package>().Property(p => p.Description).IsRequired();
            builder.Entity<Package>().Property(p => p.LocationAddress).IsRequired().HasMaxLength(20);
            builder.Entity<Package>().Property(p => p.Duration).IsRequired();
            builder.Entity<Package>().Property(p => p.Capacity).IsRequired();
            builder.Entity<Package>().Property(p => p.Price).IsRequired();
            builder.Entity<Package>().Property(p => p.Image).IsRequired();
            // Relationships (One to One)
            builder.Entity<Package>()
                .HasOne(p => p.RentCar)
                .WithOne(p => p.Package)
                .HasForeignKey<RentCar>(p => p.PackageId);
            builder.Entity<Package>()
                .HasOne(p => p.Accommodation)
                .WithOne(p => p.Package)
                .HasForeignKey<Accommodation>(p => p.PackageId);
            builder.Entity<Package>()
                .HasOne(p => p.Tour)
                .WithOne(p => p.Package)
                .HasForeignKey<Tour>(p => p.PackageId);
            builder.Entity<Package>()
                .HasOne(p => p.RoundTrip)
                .WithOne(p => p.Package)
                .HasForeignKey<RoundTrip>(p => p.PackageId);
            builder.Entity<Package>()
                .HasOne(p => p.OneWay)
                .WithOne(p => p.Package)
                .HasForeignKey<OneWay>(p => p.PackageId);
            // Relationships (One to Many)
            builder.Entity<Package>()
                .HasMany(p => p.Reviews)
                .WithOne(p => p.Package)
                .HasForeignKey(p => p.PackageId);
            builder.Entity<Package>()
                .HasMany(p => p.PurchasedPackages)
                .WithOne(p => p.Package)
                .HasForeignKey(p => p.PackageId);
            // Relationships (Many to One)
            builder.Entity<Package>()
                .HasOne(p => p.Agency)
                .WithMany(p => p.Packages)
                .HasForeignKey(p => p.AgencyId);
            builder.Entity<Package>()
                .HasOne(p => p.Location)
                .WithMany(p => p.Packages)
                .HasForeignKey(p => p.LocationId);

            // Police Station
            builder.Entity<PoliceStation>().ToTable("police_stations");
            builder.Entity<PoliceStation>().HasKey(p => p.Id);
            builder.Entity<PoliceStation>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<PoliceStation>().Property(p => p.Name).IsRequired().HasMaxLength(200);
            builder.Entity<PoliceStation>().Property(p => p.Address).IsRequired().HasMaxLength(100);
            builder.Entity<PoliceStation>().Property(p => p.Phone).IsRequired().HasMaxLength(200);
            // Relationship (Many to One)
            builder.Entity<PoliceStation>()
                .HasOne(p => p.Location)
                .WithMany(p => p.PoliceStations)
                .HasForeignKey(p => p.LocationId);

            // Purchased Package
            builder.Entity<PurchasedPackage>().ToTable("purchased_packages");
            builder.Entity<PurchasedPackage>().HasKey(p => p.TravelerId);
            builder.Entity<PurchasedPackage>().HasKey(p => p.PackageId);
            builder.Entity<PurchasedPackage>().Property(p => p.Active).IsRequired();
            // Relationship (Many to One)
            builder.Entity<PurchasedPackage>()
                .HasOne(p => p.Traveler)
                .WithMany(p => p.PurchasedPackages)
                .HasForeignKey(p => p.TravelerId);
            builder.Entity<PurchasedPackage>()
                .HasOne(p => p.Package)
                .WithMany(p => p.PurchasedPackages)
                .HasForeignKey(p => p.PackageId)
                .IsRequired(false);
            builder.Entity<PurchasedPackage>()
                .HasOne(p => p.CustomPackage)
                .WithMany(p => p.PurchasedPackages)
                .HasForeignKey(p => p.CustomPackageId)
                .IsRequired(false);

            // Rent Car
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
            // Relationship (One to One)
            builder.Entity<RentCar>()
                .HasOne(p => p.Package)
                .WithOne(p => p.RentCar)
                .HasForeignKey<RentCar>(p => p.PackageId);
            // Relationship (One to Many)
            builder.Entity<RentCar>()
                .HasMany(p => p.CustomPackages)
                .WithOne(p => p.RentCar)
                .HasForeignKey(p => p.RentCarId);

            // Review
            builder.Entity<Review>().ToTable("reviews");
            builder.Entity<Review>().HasKey(p => p.Id);
            builder.Entity<Review>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Review>().Property(p => p.Comment).IsRequired().HasMaxLength(200);
            builder.Entity<Review>().Property(p => p.Stars).IsRequired();
            // Relationship (Many to One)
            builder.Entity<Review>()
                .HasOne(p => p.Package)
                .WithMany(p => p.Reviews)
                .HasForeignKey(p => p.PackageId);
            builder.Entity<Review>()
                .HasOne(p => p.Traveler)
                .WithMany(p => p.Reviews)
                .HasForeignKey(p => p.TravelerId);

            // Round Trip
            builder.Entity<RoundTrip>().ToTable("round_trips");
            builder.Entity<RoundTrip>().HasKey(p => p.Id);
            builder.Entity<RoundTrip>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<RoundTrip>().Property(p => p.DepartureDate).IsRequired();
            builder.Entity<RoundTrip>().Property(p => p.ReturnDate).IsRequired();
            builder.Entity<RoundTrip>().Property(p => p.Price).IsRequired();
            // Relationship (One to One)
            builder.Entity<RoundTrip>()
                .HasOne(p => p.Package)
                .WithOne(p => p.RoundTrip)
                .HasForeignKey<RoundTrip>(p => p.PackageId);
            builder.Entity<RoundTrip>()
                .HasOne(p => p.TransportClass)
                .WithOne(p => p.RoundTrip)
                .HasForeignKey<RoundTrip>(p => p.TransportClassId);
            builder.Entity<RoundTrip>()
                .HasOne(p => p.TripGo)
                .WithOne(p => p.RoundTrip)
                .HasForeignKey<RoundTrip>(p => p.TripGoId);
            builder.Entity<RoundTrip>()
                .HasOne(p => p.TripBack)
                .WithOne(p => p.RoundTrip)
                .HasForeignKey<RoundTrip>(p => p.TripBackId);
            // Relationship (Many to One)
            builder.Entity<RoundTrip>()
                .HasOne(p => p.Transport)
                .WithMany(p => p.RoundTrips)
                .HasForeignKey(p => p.TransportId);
            // Relationship (One to Many)
            builder.Entity<RoundTrip>()
                .HasMany(p => p.CustomPackages)
                .WithOne(p => p.RoundTrip)
                .HasForeignKey(p => p.RoundTripId);

            // Service
            builder.Entity<Service>().ToTable("services");
            builder.Entity<Service>().HasKey(p => p.Id);
            builder.Entity<Service>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Service>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            // Relationship (One to Many)
            builder.Entity<Service>()
                .HasMany(p => p.ServicesPerAccommodations)
                .WithOne(p => p.Service)
                .HasForeignKey(p => p.ServiceId);

            // Service Per Accommodation
            builder.Entity<ServicesPerAccommodation>().ToTable("services_per_accommodation");
            builder.Entity<ServicesPerAccommodation>().HasKey(p => p.ServiceId);
            builder.Entity<ServicesPerAccommodation>().HasKey(p => p.AccommodationId);
            builder.Entity<ServicesPerAccommodation>().Property(p => p.ServiceId).IsRequired();
            builder.Entity<ServicesPerAccommodation>().Property(p => p.AccommodationId).IsRequired();
            // Relationships (Many to One)
            builder.Entity<ServicesPerAccommodation>()
                .HasOne(p => p.Service)
                .WithMany(p => p.ServicesPerAccommodations)
                .HasForeignKey(p => p.ServiceId);
            builder.Entity<ServicesPerAccommodation>()
                .HasOne(p => p.Accommodation)
                .WithMany(p => p.ServicesPerAccommodations)
                .HasForeignKey(p => p.AccommodationId);

            // Tour
            builder.Entity<Tour>().ToTable("tours");
            builder.Entity<Tour>().HasKey(p => p.Id);
            builder.Entity<Tour>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Tour>().Property(p => p.Details).IsRequired().HasMaxLength(200);
            builder.Entity<Tour>().Property(p => p.Location).IsRequired().HasMaxLength(100);
            builder.Entity<Tour>().Property(p => p.MeetingPoint).IsRequired().HasMaxLength(200);
            builder.Entity<Tour>().Property(p => p.Price).IsRequired();
            // Relationship (One to One)
            builder.Entity<Tour>()
                .HasOne(p => p.Package)
                .WithOne(p => p.Tour)
                .HasForeignKey<Tour>(p => p.PackageId);
            // Relationship (One to Many)
            builder.Entity<Tour>()
                .HasMany(p => p.CustomPackages)
                .WithOne(p => p.Tour)
                .HasForeignKey(p => p.TourId);

            // Transport
            builder.Entity<Transport>().ToTable("transports");
            builder.Entity<Transport>().HasKey(p => p.Id);
            builder.Entity<Transport>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Transport>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Transport>().Property(p => p.Type).IsRequired().HasMaxLength(50);
            // Relationships (One to Many)
            builder.Entity<Transport>()
                .HasMany(p => p.RoundTrips)
                .WithOne(p => p.Transport)
                .HasForeignKey(p => p.TransportId);
            builder.Entity<Transport>()
                .HasMany(p => p.OneWays)
                .WithOne(p => p.Transport)
                .HasForeignKey(p => p.TransportId);

            // Transport Class
            builder.Entity<TransportClass>().ToTable("transport_classes");
            builder.Entity<TransportClass>().HasKey(p => p.Id);
            builder.Entity<TransportClass>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<TransportClass>().Property(p => p.Name).IsRequired().HasMaxLength(20);
            // Relationships (One to One)
            builder.Entity<TransportClass>()
                .HasOne(p => p.RoundTrip)
                .WithOne(p => p.TransportClass)
                .HasForeignKey<RoundTrip>(p => p.TransportClassId);
            builder.Entity<TransportClass>()
                .HasOne(p => p.OneWay)
                .WithOne(p => p.TransportClass)
                .HasForeignKey<OneWay>(p => p.TransportClassId);

            // Agency
            builder.Entity<Agency>().ToTable("agencies");
            builder.Entity<Agency>().HasKey(p => p.Id);
            builder.Entity<Agency>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Agency>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Agency>().Property(p => p.Ruc).IsRequired().HasMaxLength(11);
            builder.Entity<Agency>().Property(p => p.Email).IsRequired().HasMaxLength(50);
            builder.Entity<Agency>().Property(p => p.Password).IsRequired().HasMaxLength(30);
            // Relationships (One to Many)
            builder.Entity<Agency>()
                .HasMany(p => p.Packages)
                .WithOne(p => p.Agency)
                .HasForeignKey(p => p.AgencyId);
            builder.Entity<Agency>()
                .HasMany(p => p.AgencyCards)
                .WithOne(p => p.Agency)
                .HasForeignKey(p => p.AgencyId);

            // AgencyCard
            builder.Entity<AgencyCard>().ToTable("agency_cards");
            builder.Entity<AgencyCard>().HasKey(p => p.Id);
            builder.Entity<AgencyCard>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<AgencyCard>().Property(p => p.HolderName).IsRequired().HasMaxLength(50);
            builder.Entity<AgencyCard>().Property(p => p.CardNumber).IsRequired().HasMaxLength(16);
            builder.Entity<AgencyCard>().Property(p => p.ExpirationDate).IsRequired();
            // Relationship (Many to One)
            builder.Entity<AgencyCard>()
                .HasOne(p => p.Agency)
                .WithMany(p => p.AgencyCards)
                .HasForeignKey(p => p.AgencyId);

            // TravelerCard
            builder.Entity<TravelerCard>().ToTable("traveler_cards");
            builder.Entity<TravelerCard>().HasKey(p => p.Id);
            builder.Entity<TravelerCard>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<TravelerCard>().Property(p => p.HolderName).IsRequired().HasMaxLength(50);
            builder.Entity<TravelerCard>().Property(p => p.CardNumber).IsRequired().HasMaxLength(16);
            builder.Entity<TravelerCard>().Property(p => p.ExpirationDate).IsRequired();
            // Relationship (Many to One)
            builder.Entity<TravelerCard>()
                .HasOne(p => p.Traveler)
                .WithMany(p => p.TravelerCards)
                .HasForeignKey(p => p.TravelerId);

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
            // Relationships (One to Many)
            builder.Entity<Traveler>()
                .HasMany(p => p.Reviews)
                .WithOne(p => p.Traveler)
                .HasForeignKey(p => p.TravelerId);
            builder.Entity<Traveler>()
                .HasMany(p => p.PurchasedPackages)
                .WithOne(p => p.Traveler)
                .HasForeignKey(p => p.TravelerId);
            builder.Entity<Traveler>()
                .HasMany(p => p.TravelerCards)
                .WithOne(p => p.Traveler)
                .HasForeignKey(p => p.TravelerId);
            builder.Entity<Traveler>()
                .HasMany(p => p.CustomPackages)
                .WithOne(p => p.Traveler)
                .HasForeignKey(p => p.TravelerId);

            // Trip Back
            builder.Entity<TripBack>().ToTable("trips_back");
            builder.Entity<TripBack>().HasKey(p => p.Id);
            builder.Entity<TripBack>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            // Relationship (One to One)
            builder.Entity<TripBack>()
                .HasOne(p => p.RoundTrip)
                .WithOne(p => p.TripBack)
                .HasForeignKey<RoundTrip>(p => p.TripBackId);
            // Relationship (Many to One)
            builder.Entity<TripBack>()
                .HasOne(p => p.Location)
                .WithMany(p => p.TripsBack)
                .HasForeignKey(p => p.LocationId);

            // Trip Go
            builder.Entity<TripGo>().ToTable("trips_go");
            builder.Entity<TripGo>().HasKey(p => p.Id);
            builder.Entity<TripGo>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            // Relationships (One to One)
            builder.Entity<TripGo>()
                .HasOne(p => p.RoundTrip)
                .WithOne(p => p.TripGo)
                .HasForeignKey<RoundTrip>(p => p.TripGoId);
            builder.Entity<TripGo>()
                .HasOne(p => p.OneWay)
                .WithOne(p => p.TripGo)
                .HasForeignKey<OneWay>(p => p.TripGoId);
            // Relationship (Many to One)
            builder.Entity<TripGo>()
                .HasOne(p => p.Location)
                .WithMany(p => p.TripsGo)
                .HasForeignKey(p => p.LocationId);

            // Economic Following
            builder.Entity<EconomicFollowing>().ToTable("economic_following");
            builder.Entity<EconomicFollowing>().HasKey(p => p.Id);
            builder.Entity<EconomicFollowing>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<EconomicFollowing>().Property(p => p.Name).IsRequired();
            builder.Entity<EconomicFollowing>().Property(p => p.Price).IsRequired();
            // Relationship (Many to One)
            builder.Entity<EconomicFollowing>()
                .HasOne(p => p.Traveler)
                .WithMany(p => p.EconomicFollowings)
                .HasForeignKey(p => p.TravelerId);

            // Custom Package
            builder.Entity<CustomPackage>().ToTable("custom_packages");
            builder.Entity<CustomPackage>().HasKey(p => p.Id);
            builder.Entity<CustomPackage>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<CustomPackage>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<CustomPackage>().Property(p => p.Price).IsRequired();
            // Relationships (Many to One)
            builder.Entity<CustomPackage>()
                .HasOne(p => p.Traveler)
                .WithMany(p => p.CustomPackages)
                .HasForeignKey(p => p.TravelerId);
            builder.Entity<CustomPackage>()
                .HasOne(p => p.Location)
                .WithMany(p => p.CustomPackages)
                .HasForeignKey(p => p.LocationId);
            builder.Entity<CustomPackage>()
                .HasOne(p => p.RentCar)
                .WithMany(p => p.CustomPackages)
                .HasForeignKey(p => p.RentCarId)
                .IsRequired(false);
            builder.Entity<CustomPackage>()
                .HasOne(p => p.Accommodation)
                .WithMany(p => p.CustomPackages)
                .HasForeignKey(p => p.AccommodationId)
                .IsRequired(false);
            builder.Entity<CustomPackage>()
                .HasOne(p => p.Tour)
                .WithMany(p => p.CustomPackages)
                .HasForeignKey(p => p.TourId)
                .IsRequired(false);
            builder.Entity<CustomPackage>()
                .HasOne(p => p.RoundTrip)
                .WithMany(p => p.CustomPackages)
                .HasForeignKey(p => p.RoundTripId)
                .IsRequired(false);
            builder.Entity<CustomPackage>()
                .HasOne(p => p.OneWay)
                .WithMany(p => p.CustomPackages)
                .HasForeignKey(p => p.OneWayId)
                .IsRequired(false);
            // Relationships (One to Many)
            builder.Entity<CustomPackage>()
                .HasMany(p => p.PurchasedPackages)
                .WithOne(p => p.CustomPackage)
                .HasForeignKey(p => p.CustomPackageId)
                .IsRequired(false);

            // Apply Snake Case Naming Convention
            builder.UseSnakeCaseNamingConvention();
        }
    }
}