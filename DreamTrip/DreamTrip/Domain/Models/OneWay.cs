namespace DreamTrip.DreamTrip.Domain.Models;

public class OneWay
{
    public int Id { get; set; }
    public DateTime DepartDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public decimal Price { get; set; }

    // Relationships
    
    // Trip Go
    public int TripGoId { get; set; }
    public TripGo TripGo { get; set; }
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
