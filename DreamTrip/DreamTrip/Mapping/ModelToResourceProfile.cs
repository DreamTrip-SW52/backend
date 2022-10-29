using AutoMapper;
using DreamTrip.DreamTrip.Domain.Models;
using DreamTrip.DreamTrip.Resources;

namespace DreamTrip.DreamTrip.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Traveler, TravelerResource>();
        CreateMap<Agency, AgencyResource>();
    }
}