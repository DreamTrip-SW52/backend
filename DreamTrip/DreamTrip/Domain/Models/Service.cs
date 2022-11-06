namespace DreamTrip.DreamTrip.Domain.Models;

public class Service
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Relationship
    
    // Services Per Accomodation
    List<ServicesPerAccommodation> ServicesPerAccommodations { get; set; }
}
