using System.ComponentModel.DataAnnotations;

namespace DreamTrip.DreamTrip.Resources;

public class SaveServicesPerAccommodationResource
{
    [Required]
    public int ServiceId { get; set; }

    [Required]
    public int AccommodationId { get; set; }
}
