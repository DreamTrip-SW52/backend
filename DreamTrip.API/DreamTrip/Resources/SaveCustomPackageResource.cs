using System.ComponentModel.DataAnnotations;

namespace DreamTrip.API.DreamTrip.Resources;

public class SaveCustomPackageResource
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public decimal Price { get; set; }
        
    [Required]
    public int TravelerId { get; set; }
    
    [Required]
    public int LocationId { get; set; }
    
    public int RentCarId { get; set; }
    
    public int AccommodationId { get; set; }
    
    public int TourId { get; set; }
    
    public int RoundTripId { get; set; }
    
    public int OneWayId { get; set; }
}