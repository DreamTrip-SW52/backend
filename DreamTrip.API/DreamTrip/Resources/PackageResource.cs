using Microsoft.Extensions.Primitives;

namespace DreamTrip.API.DreamTrip.Resources;

public class PackageResource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string LocationAddress { get; set; }
    public int Duration { get; set; }
    public int Capacity { get; set; }
    public int Price { get; set; }
    public string Image { get; set; }
    public int AgencyId { get; set; }
    public int LocationId { get; set; }
    public int Views { get; set; }
    public int Sales { get; set; }
    public string Category { get; set; }
}