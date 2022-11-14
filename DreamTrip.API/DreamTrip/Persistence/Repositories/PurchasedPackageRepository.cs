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

    public async Task<PurchasedPackage> FindByIdAsync(int id)
    {
        return await _context.PurchasedPackages.FindAsync(id);
    }

    public async Task<PurchasedPackage> FindActive()
    {
        return await _context.PurchasedPackages.FirstOrDefaultAsync(x => x.Active == true);
    }
    
    public async Task AddAsync(PurchasedPackage purchasedPackage)
    {
        await _context.PurchasedPackages.AddAsync(purchasedPackage);
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
