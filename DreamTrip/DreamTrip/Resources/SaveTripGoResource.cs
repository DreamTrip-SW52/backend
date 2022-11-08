using System.ComponentModel.DataAnnotations;

namespace DreamTrip.DreamTrip.Resources;

public class SaveTripGoResource
{
    [Required]
    public int LocationId { get; set; }
}
