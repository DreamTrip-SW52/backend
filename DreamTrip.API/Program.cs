using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Domain.Services;
using DreamTrip.API.DreamTrip.Mapping;
using DreamTrip.API.DreamTrip.Persistence.Contexts;
using DreamTrip.API.DreamTrip.Persistence.Repositories;
using DreamTrip.API.DreamTrip.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("corsPolicy",
        build =>
        {
            build.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
        });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Database Connection

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

// Add lowercase routes

builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Dependency Injection Configuration

// accommodation
builder.Services.AddScoped<IAccommodationRepository, AccommodationRepository>();
builder.Services.AddScoped<IAccommodationService, AccommodationService>();
// agency
builder.Services.AddScoped<IAgencyRepository, AgencyRepository>();
builder.Services.AddScoped<IAgencyService, AgencyService>();
// agencyCard
builder.Services.AddScoped<IAgencyCardRepository, AgencyCardRepository>();
builder.Services.AddScoped<IAgencyCardService, AgencyCardService>();
// healthCenter
builder.Services.AddScoped<IHealthCenterRepository, HealthCenterRepository>();
builder.Services.AddScoped<IHealthCenterService, HealthCenterService>();
// location
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationService, LocationService>();
// oneway
builder.Services.AddScoped<IOneWayRepository, OneWayRepository>();
builder.Services.AddScoped<IOneWayService, OneWayService>();
// package
builder.Services.AddScoped<IPackageRepository, PackageRepository>();
builder.Services.AddScoped<IPackageService, PackageService>();
// policeStation
builder.Services.AddScoped<IPoliceStationRepository, PoliceStationRepository>();
builder.Services.AddScoped<IPoliceStationService, PoliceStationService>();
// purchasedPackage
builder.Services.AddScoped<IPurchasedPackageRepository, PurchasedPackageRepository>();
builder.Services.AddScoped<IPurchasedPackageService, PurchasedPackageService>();
// rentCar
builder.Services.AddScoped<IRentCarRepository, RentCarRepository>();
builder.Services.AddScoped<IRentCarService, RentCarService>();
// review
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewService, ReviewService>();
// roundTrip
builder.Services.AddScoped<IRoundTripRepository, RoundTripRepository>();
builder.Services.AddScoped<IRoundTripService, RoundTripService>();
// service
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IServiceService, ServiceService>();
// servicesPerAccommodation
builder.Services.AddScoped<IServicesPerAccommodationRepository, ServicesPerAccommodationRepository>();
builder.Services.AddScoped<IServicesPerAccommodationService, ServicesPerAccommodationService>();
// tour
builder.Services.AddScoped<ITourRepository, TourRepository>();
builder.Services.AddScoped<ITourService, TourService>();
// transport
builder.Services.AddScoped<ITransportRepository, TransportRepository>();
builder.Services.AddScoped<ITransportService, TransportService>();
// transportClass
builder.Services.AddScoped<ITransportClassRepository, TransportClassRepository>();
builder.Services.AddScoped<ITransportClassService, TransportClassService>();
// traveler
builder.Services.AddScoped<ITravelerRepository, TravelerRepository>();
builder.Services.AddScoped<ITravelerService, TravelerService>();
//travelerCard
builder.Services.AddScoped<ITravelerCardRepository, TravelerCardRepository>();
builder.Services.AddScoped<ITravelerCardService, TravelerCardService>();
// tripBack
builder.Services.AddScoped<ITripBackRepository, TripBackRepository>();
builder.Services.AddScoped<ITripBackService, TripBackService>();
// tripGo
builder.Services.AddScoped<ITripGoRepository, TripGoRepository>();
builder.Services.AddScoped<ITripGoService, TripGoService>();
// economicFollowing
builder.Services.AddScoped<IEconomicFollowingRepository, EconomicFollowingRepository>();
builder.Services.AddScoped<IEconomicFollowingService, EconomicFollowingService>();
// customPackage
builder.Services.AddScoped<ICustomPackageRepository, CustomPackageRepository>();
builder.Services.AddScoped<ICustomPackageService, CustomPackageService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// AutoMapper Configuration

builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile), 
    typeof(ResourceToModelProfile));


var app = builder.Build();

// Validation for ensuring Database Objects are created

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();