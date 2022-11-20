using AutoMapper;
using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services;
using DreamTrip.API.DreamTrip.Resources;
using DreamTrip.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DreamTrip.API.DreamTrip.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class TripsBackController : ControllerBase
{
    private readonly ITripBackService _tripBackService;
    private readonly IMapper _mapper;

    public TripsBackController(ITripBackService tripBackService, IMapper mapper)
    {
        _tripBackService = tripBackService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<TripBackResource>> GetAllAsync()
    {
        var tripsBack = await _tripBackService.ListAsync();
        var resources = _mapper.Map<IEnumerable<TripBack>, IEnumerable<TripBackResource>>(tripsBack);

        return resources;
    }
    
    [HttpGet("{id}")]
    public async Task<TripBackResource> GetById(int id)
    {
        var tripBack = await _tripBackService.FindByIdAsync(id);
        var resource = _mapper.Map<TripBack, TripBackResource>(tripBack);
        
        return resource;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveTripBackResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var tripBack = _mapper.Map<SaveTripBackResource, TripBack>(resource);

        var result = await _tripBackService.SaveAsync(tripBack);

        if (!result.Success)
            return BadRequest(result.Message);
        var tripBackResource = _mapper.Map<TripBack, TripBackResource>(result.Resource);

        return Ok(tripBackResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveTripBackResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var tripBack = _mapper.Map<SaveTripBackResource, TripBack>(resource);

        var result = await _tripBackService.UpdateAsync(id, tripBack);

        if (!result.Success)
            return BadRequest(result.Message);

        var tripBackResource = _mapper.Map<TripBack, TripBackResource>(result.Resource);

        return Ok(tripBackResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _tripBackService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var tripBackResource = _mapper.Map<TripBack, TripBackResource>(result.Resource);

        return Ok(tripBackResource);
    }
}
