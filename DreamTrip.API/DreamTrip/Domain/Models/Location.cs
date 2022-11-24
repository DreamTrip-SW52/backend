namespace DreamTrip.API.DreamTrip.Domain.Models;

public class Location
{
    public int Id { get; set; }
    public string Department { get; set; }
    public string Abbr { get; set; }

    // Relationships

    // Packages
    public List<Package> Packages { get; set; } = new List<Package>();
    // Custom Packages
    public List<CustomPackage> CustomPackages { get; set; } = new List<CustomPackage>();
    // Police Stations
    public List<PoliceStation> PoliceStations { get; set; } = new List<PoliceStation>();
    // Health Centers
    public List<HealthCenter> HealthCenters { get; set; } = new List<HealthCenter>();
    // Trips Go
    public List<TripGo> TripsGo { get; set; } = new List<TripGo>();
    // Trips Back
    public List<TripBack> TripsBack { get; set; } = new List<TripBack>();
}
