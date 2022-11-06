namespace DreamTrip.DreamTrip.Domain.Models;

public class ServicesPerAccommodation
{
    public int ServiceId { get; set; }
    public Service Service { get; set; }
    
    public int AccommodationId { get; set; }
    public Accommodation Accommodation { get; set; }
}
