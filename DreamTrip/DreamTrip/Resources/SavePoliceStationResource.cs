using System.ComponentModel.DataAnnotations;

namespace DreamTrip.DreamTrip.Resources;

public class SavePoliceStationResource
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    [MaxLength(9)]
    public string Phone { get; set; }

    [Required]
    public int LocationId { get; set; }
}
