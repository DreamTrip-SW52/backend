using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.API.DreamTrip.Persistence.Repositories;

public class CustomPackageRepository : BaseRepository, ICustomPackageRepository
{
    public CustomPackageRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<CustomPackage>> ListAsync()
    {
        return await _context.CustomPackages.ToListAsync();
    }

    public async Task<CustomPackage> FindByIdAsync(int id)
    {
        return await _context.CustomPackages.FindAsync(id);
    }

    public async Task AddAsync(CustomPackage customPackage)
    {
        await _context.CustomPackages.AddAsync(customPackage);
    }

    public void Update(CustomPackage customPackage)
    {
        _context.CustomPackages.Update(customPackage);
    }

    public void Remove(CustomPackage customPackage)
    {
        _context.CustomPackages.Remove(customPackage);
    }
}