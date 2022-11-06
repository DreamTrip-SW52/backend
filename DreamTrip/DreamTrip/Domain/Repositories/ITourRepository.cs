using DreamTrip.DreamTrip.Domain.Models;

namespace DreamTrip.DreamTrip.Domain.Repositories;

public interface ITourRepository
{
    Task<IEnumerable<Tour>> ListAsync();
    Task AddAsync(Tour tour);
    Task<Tour> FindByIdAsync(int id);
    void Update(Tour tour);
    void Remove(Tour tour);
}