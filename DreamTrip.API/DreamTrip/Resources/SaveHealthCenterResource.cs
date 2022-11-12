using System.ComponentModel.DataAnnotations;

namespace DreamTrip.API.DreamTrip.Resources;

public class SaveHealthCenterResource
{
    [Required]
    [MaxLength(50)]
    public string Type { get; set; }

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
