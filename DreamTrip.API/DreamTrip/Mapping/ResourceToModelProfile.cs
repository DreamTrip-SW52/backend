using AutoMapper;
using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Resources;

namespace DreamTrip.API.DreamTrip.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        // accommodation
        CreateMap<SaveAccommodationResource, Accommodation>();
        // agency
        CreateMap<SaveAgencyResource, Agency>();
        // agencyCard
        CreateMap<SaveAgencyCardResource, AgencyCard>();
        // healthCenter
        CreateMap<SaveHealthCenterResource, HealthCenter>();
        // location
        CreateMap<SaveLocationResource, Location>();
        // oneWay
        CreateMap<SaveOneWayResource, OneWay>();
        // package
        CreateMap<SavePackageResource, Package>();
        // policeStation
        CreateMap<SavePoliceStationResource, PoliceStation>();
        // purchasedPackage
        CreateMap<SavePurchasedPackageResource, PurchasedPackage>();
        // rentCar
        CreateMap<SaveRentCarResource, RentCar>();
        // review
        CreateMap<SaveReviewResource, Review>();
        // roundTrip
        CreateMap<SaveRoundTripResource, RoundTrip>();
        // service
        CreateMap<SaveServiceResource, Service>();
        // servicesPerAccommodation
        CreateMap<SaveServicesPerAccommodationResource, ServicesPerAccommodation>();
        // tour
        CreateMap<SaveTourResource, Tour>();
        // transport
        CreateMap<SaveTransportResource, Transport>();
        // transportClass
        CreateMap<SaveTransportClassResource, TransportClass>();
        // traveler
        CreateMap<SaveTravelerResource, Traveler>();
        // travelerCard
        CreateMap<SaveTravelerCardResource, TravelerCard>();
        // tripBack
        CreateMap<SaveTripBackResource, TripBack>();
        // tripGo
        CreateMap<SaveTripGoResource, TripGo>();
    }
}