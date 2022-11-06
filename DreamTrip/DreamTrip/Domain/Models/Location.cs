namespace DreamTrip.DreamTrip.Domain.Models;

public class Location
{
    public int Id { get; set; }
    public string Department { get; set; }
    public string Abbr { get; set; }

    // Relationships

    // Police Stations
    public List<PoliceStation> PoliceStations { get; set; } = new List<PoliceStation>();
    // Health Centers
    public List<HealthCenter> HealthCenters { get; set; } = new List<HealthCenters>();
    // Trips Go
    public List<TripGo> TripsGo { get; set; } = new List<TripsGo>();
    // Trips Back
    public List<TripBack> TripsBack { get; set; } = new List<TripsBack>();
}
