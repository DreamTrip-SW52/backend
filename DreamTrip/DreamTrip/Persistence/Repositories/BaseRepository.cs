using DreamTrip.DreamTrip.Persistence.Contexts;

namespace DreamTrip.DreamTrip.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}