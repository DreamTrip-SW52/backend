using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DreamTrip.API.DreamTrip.Persistence.Repositories;

public class PurchasedPackageRepository : BaseRepository, IPurchasedPackageRepository
{
    public PurchasedPackageRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<PurchasedPackage>> ListAsync()
    {
        return await _context.PurchasedPackages.ToListAsync();
    }

    public async Task AddAsync(PurchasedPackage purchasedPackage)
    {
        await _context.PurchasedPackages.AddAsync(purchasedPackage);
    }

    public async Task<PurchasedPackage> FindByIdAsync(int id)
    {
        return await _context.PurchasedPackages.FindAsync(id);
    }

    public void Update(PurchasedPackage purchasedPackage)
    {
        _context.PurchasedPackages.Update(purchasedPackage);
    }

    public void Remove(PurchasedPackage purchasedPackage)
    {
        _context.PurchasedPackages.Remove(purchasedPackage);
    }
}
