using DreamTrip.API.DreamTrip.Domain.Models;

namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface IOneWayRepository
{
    Task<IEnumerable<OneWay>> ListAsync();
    Task<OneWay> FindByIdAsync(int id);
    Task<OneWay> FindByPackageId(int packageId);
    Task AddAsync(OneWay oneWay);
    void Update(OneWay oneWay);
    void Remove(OneWay oneWay);
}