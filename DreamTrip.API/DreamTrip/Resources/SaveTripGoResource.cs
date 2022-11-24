using System.ComponentModel.DataAnnotations;

namespace DreamTrip.API.DreamTrip.Resources;

public class SaveTripGoResource
{
    [Required]
    public int LocationId { get; set; }
}
