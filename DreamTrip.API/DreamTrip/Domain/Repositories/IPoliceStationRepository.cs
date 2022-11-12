using DreamTrip.API.DreamTrip.Domain.Models;

namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface IPoliceStationRepository
{
    Task<IEnumerable<PoliceStation>> ListAsync();
    Task AddAsync(PoliceStation policeStation);
    Task<PoliceStation> FindByIdAsync(int id);
    void Update(PoliceStation policeStation);
    void Remove(PoliceStation policeStation);
}