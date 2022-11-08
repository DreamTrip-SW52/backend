using System.ComponentModel.DataAnnotations;

namespace DreamTrip.DreamTrip.Resources;

public class SaveAccommodationResource
{
    [Required]
    public string Details { get; set; }

    [Required]
    public DateTime CheckIn { get; set; }

    [Required]
    public DateTime CheckOut { get; set; }

    [Required]
    public string Location { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public int PackageId { get; set; }
}
