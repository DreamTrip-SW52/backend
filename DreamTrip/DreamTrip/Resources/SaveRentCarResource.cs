using System.ComponentModel.DataAnnotations;

namespace DreamTrip.DreamTrip.Resources;

public class SaveRentCarResource
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [MaxLength(50)]
    public string Brand{ get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public int Capacity { get; set; }

    [Required]
    public string Photo { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public DateTime PickUpHour { get; set; }

    [Required]
    public DateTime DropOffHour { get; set; }

    [Required]
    public int PackageId { get; set; }
}
