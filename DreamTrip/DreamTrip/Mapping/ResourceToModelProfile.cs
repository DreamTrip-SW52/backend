using AutoMapper;
using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Resources;

namespace DreamTrip.DreamTrip.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveAgencyResource, Agency>();
        CreateMap<SaveTravelerResource, Traveler>();
    }
}