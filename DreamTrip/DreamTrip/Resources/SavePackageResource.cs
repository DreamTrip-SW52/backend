using System.ComponentModel.DataAnnotations;

namespace DreamTrip.DreamTrip.Resources;

public class SavePackageResource
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    [MaxLength(20)]
    public string LocationAddress { get; set; }

    [Required]
    public int Duration { get; set; }

    [Required]
    public int Capacity { get; set; }

    [Required]
    public int Price { get; set; }

    [Required]
    public string Image { get; set; }

    [Required]
    public bool Custom { get; set; }

    [Required]
    public int AgencyId { get; set; }

    [Required]
    public int LocationId { get; set; }
}