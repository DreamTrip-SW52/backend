namespace DreamTrip.API.DreamTrip.Domain.Models;

public class Service
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Relationship

    // Services Per Accomodation
    public List<ServicesPerAccommodation> ServicesPerAccommodations { get; set; } = new List<ServicesPerAccommodation>();
}
