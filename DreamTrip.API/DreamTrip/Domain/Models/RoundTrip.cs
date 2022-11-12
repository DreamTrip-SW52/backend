namespace DreamTrip.API.DreamTrip.Domain.Models;

public class RoundTrip
{
    public int Id { get; set; }
    public DateTime DepartureDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public decimal Price { get; set; }

    // Relationships

    // Trip Go
    public int TripGoId { get; set; }
    public TripGo TripGo { get; set; }
    // Trip Back
    public int TripBackId { get; set; }
    public TripBack TripBack { get; set; }
    // Transport Class
    public int TransportClassId { get; set; }
    public TransportClass TransportClass { get; set; }
    // Package
    public int PackageId { get; set; }
    public Package Package { get; set; }
    // Transport
    public int TransportId { get; set; }
    public Transport Transport { get; set; }
}
