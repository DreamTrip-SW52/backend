namespace DreamTrip.API.DreamTrip.Domain.Models;

public class EconomicFollowing
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    
    // Relationship 
    
    // Traveler
    public int TravelerId { get; set; }
    public Traveler Traveler { get; set; }
}