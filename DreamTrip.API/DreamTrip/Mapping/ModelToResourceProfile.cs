using AutoMapper;
using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Resources;

namespace DreamTrip.API.DreamTrip.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        // accommodation
        CreateMap<Accommodation, AccommodationResource>();
        CreateMap<Agency, AgencyResource>();
        // agencyCard
        CreateMap<AgencyCard, AgencyCardResource>();
        // healthCenter
        CreateMap<HealthCenter, HealthCenterResource>();
        // location
        CreateMap<Location, LocationResource>();
        // oneWay
        CreateMap<OneWay, OneWayResource>();
        // package
        CreateMap<Package, PackageResource>();
        // policeStation
        CreateMap<PoliceStation, PoliceStationResource>();
        // purchasedPackage
        CreateMap<PurchasedPackage, PurchasedPackageResource>();
        // rentCar
        CreateMap<RentCar, RentCarResource>();
        // review
        CreateMap<Review, ReviewResource>();
        // roundTrip
        CreateMap<RoundTrip, RoundTripResource>();
        // service
        CreateMap<Service, ServiceResource>();
        // servicesPerAccommodation
        CreateMap<ServicesPerAccommodation, ServicesPerAccommodationResource>();
        // tour
        CreateMap<Tour, TourResource>();
        // transport
        CreateMap<Transport, TransportResource>();
        // transportClass
        CreateMap<TransportClass, TransportClassResource>();
        // traveler
        CreateMap<Traveler, TravelerResource>();
        // travelerCard
        CreateMap<TravelerCard, TravelerCardResource>();
        // tripBack
        CreateMap<TripBack, TripBackResource>();
        // tripGo
        CreateMap<TripGo, TripGoResource>();
        // economicFollowing
        CreateMap<EconomicFollowing, EconomicFollowingResource>();
        // customPackage
        CreateMap<CustomPackage, CustomPackageResource>();
    }
}