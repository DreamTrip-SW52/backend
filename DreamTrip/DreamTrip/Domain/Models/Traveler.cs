namespace DreamTrip.DreamTrip.Domain.Models;

public class Traveler
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string Photo { get; set; }
    public string Dni { get; set; }
    
    // Relationships
    // public IList<Tutorial> Tutorials { get; set; } = new List<Tutorial>();
}
