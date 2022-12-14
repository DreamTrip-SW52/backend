using AutoMapper;
using DreamTrip.API.DreamTrip.Domain.Models;
using DreamTrip.API.DreamTrip.Domain.Services;
using DreamTrip.API.DreamTrip.Resources;
using DreamTrip.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DreamTrip.API.DreamTrip.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class TripsGoController : ControllerBase
{
    private readonly ITripGoService _tripGoService;
    private readonly IMapper _mapper;

    public TripsGoController(ITripGoService tripGoService, IMapper mapper)
    {
        _tripGoService = tripGoService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<TripGoResource>> GetAllAsync()
    {
        var tripsGo = await _tripGoService.ListAsync();
        var resources = _mapper.Map<IEnumerable<TripGo>, IEnumerable<TripGoResource>>(tripsGo);

        return resources;
    }

    [HttpGet("{id}")]
    public async Task<TripGoResource> GetById(int id)
    {
        var tripGo = await _tripGoService.FindByIdAsync(id);
        var resource = _mapper.Map<TripGo, TripGoResource>(tripGo);
        
        return resource;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveTripGoResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var tripGo = _mapper.Map<SaveTripGoResource, TripGo>(resource);

        var result = await _tripGoService.SaveAsync(tripGo);

        if (!result.Success)
            return BadRequest(result.Message);
        var tripGoResource = _mapper.Map<TripGo, TripGoResource>(result.Resource);

        return Ok(tripGoResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveTripGoResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var tripGo = _mapper.Map<SaveTripGoResource, TripGo>(resource);

        var result = await _tripGoService.UpdateAsync(id, tripGo);

        if (!result.Success)
            return BadRequest(result.Message);

        var tripGoResource = _mapper.Map<TripGo, TripGoResource>(result.Resource);

        return Ok(tripGoResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _tripGoService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var tripGoResource = _mapper.Map<TripGo, TripGoResource>(result.Resource);

        return Ok(tripGoResource);
    }
}
