using DreamTrip.API.DreamTrip.Domain.Models;

namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface IPoliceStationRepository
{
    Task<IEnumerable<PoliceStation>> ListAsync();
    Task<PoliceStation> FindByIdAsync(int id);
    Task<IEnumerable<PoliceStation>> FindByLocationId(int locationId);
    Task AddAsync(PoliceStation policeStation);
    void Update(PoliceStation policeStation);
    void Remove(PoliceStation policeStation);
}