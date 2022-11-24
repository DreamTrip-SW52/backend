using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

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
    
    [AllowNull]
    public int? RentCarId { get; set; }
    
    [AllowNull]
    public int? AccommodationId { get; set; }
    
    [AllowNull]
    public int? TourId { get; set; }
    
    [AllowNull]
    public int? RoundTripId { get; set; }
    
    [AllowNull]
    public int? OneWayId { get; set; }
}