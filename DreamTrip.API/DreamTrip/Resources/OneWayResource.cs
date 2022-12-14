namespace DreamTrip.API.DreamTrip.Resources;

public class OneWayResource
{
    public int Id { get; set; }
    public DateTime DepartureDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public decimal Price { get; set; }
    public int TripGoId { get; set; }
    public int TransportClassId { get; set; }
    public int PackageId { get; set; }
    public int TransportId { get; set; }
}
