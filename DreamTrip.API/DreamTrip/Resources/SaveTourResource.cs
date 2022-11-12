using System.ComponentModel.DataAnnotations;

namespace DreamTrip.API.DreamTrip.Resources;

public class SaveTourResource
{
    [Required]
    public string Details { get; set; }

    [Required]
    public string Location { get; set; }

    [Required]
    public string MeetingPoint { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public int PackageId { get; set; }
}
