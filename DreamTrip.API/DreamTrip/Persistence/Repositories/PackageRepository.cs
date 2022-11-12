using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.API.DreamTrip.Persistence.Repositories;

public class PackageRepository : BaseRepository, IPackageRepository
{
    public PackageRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Package>> ListAsync()
    {
        return await _context.Packages.ToListAsync();
    }

    public async Task AddAsync(Package package)
    {
        await _context.Packages.AddAsync(package);
    }

    public async Task<Package> FindByIdAsync(int id)
    {
        return await _context.Packages.FindAsync(id);
    }

    public void Update(Package package)
    {
        _context.Packages.Update(package);
    }

    public void Remove(Package package)
    {
        _context.Packages.Remove(package);
    }
}
