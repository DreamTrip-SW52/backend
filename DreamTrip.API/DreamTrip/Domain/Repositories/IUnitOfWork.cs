namespace DreamTrip.API.DreamTrip.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}