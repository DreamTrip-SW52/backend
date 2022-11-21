using AutoMapper;
using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services;
using DreamTrip.API.DreamTrip.Resources;
using DreamTrip.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DreamTrip.API.DreamTrip.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class AccommodationController : ControllerBase
{
    private readonly IAccommodationService _accommodationService;
    private readonly IMapper _mapper;

    public AccommodationController(IAccommodationService accommodationService, IMapper mapper)
    {
        _accommodationService = accommodationService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<AccommodationResource>> GetAllAsync()
    {
        var accommodations = await _accommodationService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Accommodation>, IEnumerable<AccommodationResource>>(accommodations);

        return resources;
    }

    [HttpGet("packageId/{packageId}")]
    public async Task<AccommodationResource> GetByPackageId(int packageId)
    {
        var accommodation = await _accommodationService.FindByPackageIdAsync(packageId);
        var resource = _mapper.Map<Accommodation, AccommodationResource>(accommodation);

        return resource;
    }

    [HttpGet("filters/{locationId}/{priceMin}/{priceMax}")]
    public async Task<IEnumerable<AccommodationResource>> FilterAccomodation(int locationId, int priceMin, int priceMax)
    {
        var accommodations = await _accommodationService.FindByFilters(locationId, priceMin, priceMax);
        var resources = _mapper.Map<IEnumerable<Accommodation>, IEnumerable<AccommodationResource>>(accommodations);

        return resources;
    }


    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveAccommodationResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var accommodation = _mapper.Map<SaveAccommodationResource, Accommodation>(resource);

        var result = await _accommodationService.SaveAsync(accommodation);

        if (!result.Success)
            return BadRequest(result.Message);
        var accommodationResource = _mapper.Map<Accommodation, AccommodationResource>(result.Resource);

        return Ok(accommodationResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAccommodationResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var accommodation = _mapper.Map<SaveAccommodationResource, Accommodation>(resource);

        var result = await _accommodationService.UpdateAsync(id, accommodation);

        if (!result.Success)
            return BadRequest(result.Message);

        var accommodationResource = _mapper.Map<Accommodation, AccommodationResource>(result.Resource);

        return Ok(accommodationResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _accommodationService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var accommodationResource = _mapper.Map<Accommodation, AccommodationResource>(result.Resource);

        return Ok(accommodationResource);
    }
}
