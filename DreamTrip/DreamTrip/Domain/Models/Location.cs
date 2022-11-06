namespace DreamTrip.DreamTrip.Domain.Models;

public class Location
{
    public int Id { get; set; }
    public string Department { get; set; }
    public string Abbr { get; set; }

    // Relationships

    // Police Stations
    public List<PoliceStation> PoliceStations { get; set; }
    // Health Centers
    public List<HealthCenter> HealthCenters { get; set; }
    // Trips Go
    public List<TripGo> TripsGo { get; set; }
    // Trips Back
    public List<TripBack> TripsBack { get; set; }
}
