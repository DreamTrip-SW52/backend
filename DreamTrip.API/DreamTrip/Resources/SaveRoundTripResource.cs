using System.ComponentModel.DataAnnotations;

namespace DreamTrip.API.DreamTrip.Resources;

public class SaveRoundTripResource
{
    [Required]
    public DateTime DepartureDate { get; set; }

    [Required]
    public DateTime ReturnDate { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public int TripGoId { get; set; }

    [Required]
    public int TripBackId { get; set; }

    [Required]
    public int TransportClassId { get; set; }

    [Required]
    public int PackageId { get; set; }

    [Required]
    public int TransportId { get; set; }
}
