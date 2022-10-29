namespace DreamTrip.DreamTrip.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}