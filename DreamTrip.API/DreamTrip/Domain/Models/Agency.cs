namespace DreamTrip.API.DreamTrip.Domain.Models;

public class Agency
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Ruc { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    // Relationships

    // Packages
    public List<Package> Packages { get; set; }
    // AgencyCards
    public List<AgencyCard> AgencyCards { get; set; }
}