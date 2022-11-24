using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Repositories;
using DreamTrip.API.DreamTrip.Domain.Services;
using DreamTrip.API.DreamTrip.Domain.Services.Communication;

namespace DreamTrip.API.DreamTrip.Services;

public class AgencyService : IAgencyService
{
    private readonly IAgencyRepository _agencyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AgencyService(IAgencyRepository agencyRepository, IUnitOfWork unitOfWork)
    {
        _agencyRepository = agencyRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Agency>> ListAsync()
    {
        return await _agencyRepository.ListAsync();
    }
    
    public async Task<Agency> FindByIdAsync(int id)
    {
        return await _agencyRepository.FindByIdAsync(id);
    }
    
    public async Task<Agency> FindByEmailAndPasswordAsync(string email, string password)
    {
        return await _agencyRepository.FindByEmailAndPassword(email, password);
    }

    public async Task<AgencyResponse> SaveAsync(Agency agency)
    {
        try
        {
            await _agencyRepository.AddAsync(agency);
            await _unitOfWork.CompleteAsync();
            return new AgencyResponse(agency);
        }
        catch (Exception e)
        {
            return new AgencyResponse($"An error occurred while saving the agency: {e.Message}");
        }
    }

    public async Task<AgencyResponse> UpdateAsync(int id, Agency agency)
    {
        var existingAgency = await _agencyRepository.FindByIdAsync(id);

        if (existingAgency == null)
            return new AgencyResponse("Agency not found.");

        existingAgency.Name = agency.Name;
		existingAgency.Ruc = agency.Ruc;
		existingAgency.Email = agency.Email;
		existingAgency.Password = agency.Password;

        try
        {
            _agencyRepository.Update(existingAgency);
            await _unitOfWork.CompleteAsync();

            return new AgencyResponse(existingAgency);
        }
        catch (Exception e)
        {
            return new AgencyResponse($"An error occurred while updating the agency: {e.Message}");
        }
    }

    public async Task<AgencyResponse> DeleteAsync(int id)
    {
        var existingAgency = await _agencyRepository.FindByIdAsync(id);

        if (existingAgency == null)
            return new AgencyResponse("Agency not found.");

        try
        {
            _agencyRepository.Remove(existingAgency);
            await _unitOfWork.CompleteAsync();

            return new AgencyResponse(existingAgency);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new AgencyResponse($"An error occurred while deleting the agency: {e.Message}");
        }
    }
}