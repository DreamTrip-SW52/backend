namespace DreamTrip.DreamTrip.Domain.Models;

public class Agency
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Ruc { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    // Relationships
    // public int CategoryId { get; set; }
    // public Category Category { get; set; }
}