using DreamTrip.API.DreamTrip.Domain.Models;

namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface IOneWayRepository
{
    Task<IEnumerable<OneWay>> ListAsync();
    Task<OneWay> FindByIdAsync(int id);
    Task<OneWay> FindByPackageId(int packageId);
    Task<IEnumerable<OneWay>> FindByFilters(string to, DateTime departureDate,
        DateTime returnDate, string transportClass, string transportType);
    Task AddAsync(OneWay oneWay);
    void Update(OneWay oneWay);
    void Remove(OneWay oneWay);
}