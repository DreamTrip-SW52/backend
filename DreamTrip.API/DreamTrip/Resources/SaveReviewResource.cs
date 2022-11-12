using System.ComponentModel.DataAnnotations;

namespace DreamTrip.API.DreamTrip.Resources;

public class SaveReviewResource
{
    [Required]
    [MaxLength(200)]
    public string Comment { get; set; }

    [Required]
    public int Stars { get; set; }

    [Required]
    public int PackageId { get; set; }

    [Required]
    public int TravelerId { get; set; }
}

